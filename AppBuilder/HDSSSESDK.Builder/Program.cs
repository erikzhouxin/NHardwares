using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace HDSSSESDK.Builder
{
    static class Program
    {
        public static String Proj_Name { get; } = "HDSSSESDK";
        public static String SrcDir { get; } = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..", "..", Proj_Name));
        public static String ProjDir { get; } = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..", "..", Proj_Name, Proj_Name));
        static string NUSPEC_VERSION { get; } = string.Format("{0:yyyy.M.d}", DateTime.Now);
        static string ASSEMBLY_VERSION { get; } = string.Format("{0}.{1}", NUSPEC_VERSION, (int)(DateTime.Now - new DateTime(2020, 1, 1)).TotalDays);
        static string COPYRIGHT { get; } = $"Copyright 2020-{DateTime.Now.Year}";
        static string AUTHORS { get; } = "ErikZhouXin";
        static string SUMMARY { get; } = "华大HD100的HDSSSE32读写器命名管道实现64位使用32位SDK";
        static string PACKAGE_TAGS { get; } = "华大;HD-100;HDSSSE;";
        public static String Config = "Release";

        static void Main(string[] args)
        {
            // 生成信息
            Directory.CreateDirectory(Path.Combine(ProjDir, "bin"));
            foreach (var s in Directory.GetFiles(ProjDir, "*.nupkg", SearchOption.AllDirectories))
            {
                File.Delete(s);
            }
            // 生成包
            GenNuspecLib(SrcDir);
            // 编译生成版本
            ReplaceVersion(Path.GetFullPath(Path.Combine(ProjDir, $"{Proj_Name}.csproj")));
            Exec("dotnet", $"pack -c {Config}", ProjDir);
            // 还原包内容
            Exec("dotnet", "restore", ProjDir);
            Exec(@"C:\Program Files\Microsoft Visual Studio 2019\MSBuild\Current\Bin\msbuild.exe", $"/p:Configuration={Config} /t:pack", ProjDir);
            // 编译生成
            //var path_empty = Path.Combine(Program.Src, "_._");
            //if (!File.Exists(path_empty)) { File.WriteAllText(path_empty, ""); }
            Exec("dotnet", "pack", ProjDir);
            var packFile = $"NSystem.Data.{Proj_Name}.{NUSPEC_VERSION}.nupkg";
            try
            {
                File.Copy(Path.Combine(ProjDir, "bin", Config, packFile), Path.Combine(@"E:\Apptmp\Nuget\packages\NSystem.Data.HDSSSESDK\", packFile), true);
                Directory.Delete(Path.Combine(@"C:\Users\Admin\.nuget\packages", $"NSystem.Data.{Proj_Name}", $"{NUSPEC_VERSION}"), true);
            }
            catch { }
        }

        #region // MSBuilder
        public static void Exec(string fileName, string args, string startDir)
        {
            var wd = System.IO.Path.GetFullPath(startDir);
            var procStartInfo = new ProcessStartInfo
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                FileName = fileName,
                Arguments = args,
                WorkingDirectory = wd
            };

            var p = new Process()
            {
                StartInfo = procStartInfo
            };
            p.OutputDataReceived += P_OutputDataReceived;
            p.ErrorDataReceived += P_ErrorDataReceived;

            var desc = $"{fileName} {args} in {wd}";
            //printfn "-------- %s" desc
            p.Start(); //|> ignore
                       //printfn "Started %s with pid %i" p.ProcessName p.Id
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            p.WaitForExit();

            //printfn "Finished %s after %A milliseconds" desc timer.ElapsedMilliseconds
            var rc = p.ExitCode;
            //if (rc != 0)
            //throw new Exception();
        }

        private static void P_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            System.Console.Error.WriteLine(e.Data);
        }

        private static void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            System.Console.WriteLine(e.Data);
        }
        #endregion
        #region // Generator Creater
        private static void GenNuspecLib(string dir_src)
        {
            string id = $"NSystem.Data.{Proj_Name}";
            var sdks = new List<string> { "net40", "net45", "netstandard2.1", "netcoreapp3.1", "net6.0" };
            using (XmlWriter f = XmlWriter.Create(Path.Combine(ProjDir, $"{Proj_Name}.csproj"), new XmlWriterSettings
            {
                NewLineChars = "\n",
                Indent = true,
                OmitXmlDeclaration = false
            }))
            {
                f.WriteStartDocument();
                f.WriteComment("自动生成");

                f.WriteStartElement("Project");
                f.WriteAttributeString("Sdk", "Microsoft.NET.Sdk");

                f.WriteStartElement("PropertyGroup");

                f.WriteElementString("TargetFrameworks", string.Join(";", sdks));
                f.WriteElementString("AssemblyName", id);
                f.WriteElementString("RootNamespace", id.Substring(1));
                f.WriteElementString("NoBuild", "false");
                f.WriteElementString("GenerateDocumentationFile", "true");
                f.WriteElementString("IncludeBuildOutput", "true");
                f.WriteElementString("Copyright", COPYRIGHT);
                f.WriteElementString("Company", "EZhouXin");
                f.WriteElementString("Authors", AUTHORS);
                f.WriteElementString("Version", NUSPEC_VERSION);
                f.WriteElementString("AssemblyVersion", ASSEMBLY_VERSION);
                f.WriteElementString("FileVersion", ASSEMBLY_VERSION);
                f.WriteElementString("Description", SUMMARY);
                f.WriteElementString("ProviderLangVersion", "7.3");
                f.WriteElementString("GenerateAssemblyProductAttribute", "false");
                f.WriteElementString("PackageLicenseExpression", "MIT");
                f.WriteElementString("PackageRequireLicenseAcceptance", "false");
                f.WriteElementString("PackageTags", PACKAGE_TAGS);
                f.WriteElementString("RepositoryUrl", "https://github.com/ErikZhouXin/NHardwares");
                f.WriteElementString("RepositoryType", "git");
                f.WriteElementString("NuspecFile", $"{id}.nuspec");

                f.WriteEndElement(); // PropertyGroup

                f.WriteStartElement("ItemGroup");

                f.WriteStartElement("Compile");
                f.WriteAttributeString("Include", @"..\HDSSSEEXE\PiperSwapModel.cs");
                f.WriteAttributeString("Link", @"PiperSwapModel.cs");
                f.WriteEndElement();
                f.WriteStartElement("PackageReference");
                f.WriteAttributeString("Include", "Newtonsoft.Json");
                f.WriteAttributeString("Version", "13.0.1");
                f.WriteEndElement();

                f.WriteEndElement(); // ItemGroup

                f.WriteStartElement("ItemGroup");

                f.WriteStartElement("Compile");
                f.WriteAttributeString("Update", @"Properties\Resources.Designer.cs");
                f.WriteElementString("DesignTime", "True");
                f.WriteElementString("AutoGen", "True");
                f.WriteElementString("DependentUpon", "Resources.resx");
                f.WriteEndElement();
                f.WriteStartElement("EmbeddedResource");
                f.WriteAttributeString("Update", @"Properties\Resources.resx");
                f.WriteElementString("Generator", "ResXFileCodeGenerator");
                f.WriteElementString("LastGenOutput", "Resources.Designer.cs");
                f.WriteEndElement();

                f.WriteEndElement(); // ItemGroup

                f.WriteEndElement(); // Project

                f.WriteEndDocument();
            }

            using (XmlWriter f = XmlWriter.Create(Path.Combine(ProjDir, string.Format("{0}.nuspec", id)), new XmlWriterSettings
            {
                NewLineChars = "\n",
                Indent = true,
                OmitXmlDeclaration = false
            }))
            {
                f.WriteStartDocument();
                f.WriteComment("自动生成");

                f.WriteStartElement("package", "http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd");

                f.WriteStartElement("metadata");


                f.WriteAttributeString("minClientVersion", "2.12"); // TODO not sure this is right

                f.WriteElementString("id", id);
                f.WriteElementString("title", id);
                f.WriteElementString("version", NUSPEC_VERSION);
                f.WriteElementString("authors", AUTHORS);
                f.WriteElementString("copyright", COPYRIGHT);
                f.WriteElementString("requireLicenseAcceptance", "false");
                f.WriteStartElement("license");
                f.WriteAttributeString("type", "expression");
                f.WriteString("MIT");
                f.WriteEndElement();
                f.WriteStartElement("repository");
                f.WriteAttributeString("type", "git");
                f.WriteAttributeString("url", "https://www.gitee.com/ErikZhouXin/NHardwares");
                f.WriteEndElement(); // repository
                f.WriteElementString("summary", SUMMARY);
                f.WriteElementString("tags", PACKAGE_TAGS);

                f.WriteElementString("description", SUMMARY);

                f.WriteStartElement("dependencies");

                f.WriteStartElement("dependency");
                f.WriteAttributeString("id", "Newtonsoft.Json");
                f.WriteAttributeString("version", "13.0.1");
                f.WriteEndElement();

                f.WriteEndElement(); // dependencies

                f.WriteEndElement(); // metadata

                f.WriteStartElement("files");

                // 支持的SDK
                foreach (var sdkName in sdks)
                {
                    try
                    {
                        foreach (var file in Directory.GetFiles(Path.Combine(ProjDir, "bin", Config, sdkName)))
                        {
                            var ext = Path.GetExtension(file)?.ToLower();
                            switch (ext)
                            {
                                case ".xml":
                                case ".dll":
                                    break;
                                default:
                                    continue;
                            }
                            var fileName = Path.GetFileName(file);
                            if (fileName.Equals("Newtonsoft.Json.dll", StringComparison.OrdinalIgnoreCase))
                            {
                                continue;
                            }
                            f.WriteStartElement("file");
                            f.WriteAttributeString("src", $"bin\\{Config}\\{sdkName}\\{fileName}");
                            f.WriteAttributeString("target", $"lib/{sdkName}/{fileName}");
                            f.WriteEndElement(); // file
                        }
                    }
                    catch { }
                    f.WriteStartElement("file");
                    f.WriteAttributeString("src", $"..\\beans\\HDSSSE32.dll");
                    f.WriteAttributeString("target", $"lib/{sdkName}/HDSSSE32.dll");
                    f.WriteEndElement(); // file
                    //var path = Path.Combine(SrcDir, "HDSSSEEXE", "bin", Config, sdkName);
                    //var tagPath = Path.Combine(ProjDir, "bin", Config);
                    //try
                    //{
                    //    if (!Directory.Exists(tagPath)) { Directory.CreateDirectory(tagPath); }
                    //    foreach (var file in Directory.GetFiles(path))
                    //    {
                    //        var fileName = Path.GetFileName(file);
                    //        File.Copy(file, Path.Combine(tagPath, sdkName, fileName), true);
                    //        f.WriteStartElement("file");
                    //        f.WriteAttributeString("src", $"bin\\{Config}\\{sdkName}\\{fileName}");
                    //        f.WriteAttributeString("target", $"content/{sdkName}/{fileName}");
                    //        f.WriteEndElement(); // file
                    //    }
                    //}
                    //catch { }
                }

                f.WriteEndElement(); // files

                f.WriteEndElement(); // package

                f.WriteEndDocument();
            }
        }

        private static void ReplaceVersion(string projFile)
        {
            var coreProj = Path.GetFullPath(projFile);
            var content = File.ReadAllText(coreProj, Encoding.UTF8);
            // 忽略大小写
            Regex versionReg = new Regex(@"(<Version>)\d+[\.\d+]+(</Version>)", RegexOptions.IgnoreCase);
            Regex fileReg = new Regex(@"(<FileVersion>)\d+[\.\d+]+(</FileVersion>)", RegexOptions.IgnoreCase);
            Regex assemblyReg = new Regex(@"(<AssemblyVersion>)\d+[\.\d+]+(</AssemblyVersion>)", RegexOptions.IgnoreCase);
            var targetContent = versionReg.Replace(content, "<Version>" + NUSPEC_VERSION + "</Version>");
            targetContent = fileReg.Replace(targetContent, "<FileVersion>" + ASSEMBLY_VERSION + "</FileVersion>");
            targetContent = assemblyReg.Replace(targetContent, "<AssemblyVersion>" + ASSEMBLY_VERSION + "</AssemblyVersion>");
            File.WriteAllText(coreProj, targetContent, Encoding.UTF8);
        }
        #endregion
    }
}
