using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace YuShiITSSDK.Builder
{
    static class Program
    {
        public static String Src { get; private set; }
        static string NUSPEC_VERSION { get; } = string.Format("2021.11.11", DateTime.Now);
        static string ASSEMBLY_VERSION { get; } = string.Format("{0}.{1}", NUSPEC_VERSION, (int)(DateTime.Now - new DateTime(2020, 1, 1)).TotalDays);
        static string COPYRIGHT { get; } = $"Copyright 2020-{DateTime.Now.Year}";
        static string AUTHORS { get; } = "ErikZhouXin";
        static string SUMMARY { get; } = "宇视SDK集成项目";
        static string PACKAGE_TAGS { get; } = "宇视;宇视SDK;ITSSDK;";
        public static String Proj_Name { get; private set; }
        public static String Config = "Debug";

        static void Main(string[] args)
        {
            var current = Directory.GetCurrentDirectory();
            Proj_Name = "YuShiITSSDK";
            Src = Path.GetFullPath(Path.Combine(current, "..", "..", "..", "..", "..", Proj_Name));
            // 生成信息
            Directory.CreateDirectory(Path.Combine(Src, "bin"));
            foreach (var s in Directory.GetFiles(Src, "*.nupkg", SearchOption.AllDirectories))
            {
                File.Delete(s);
            }
            // 创建生成
            GenDirectoryBuildProps(Src);
            // 生成包
            GenNuspecLib(Src);
            // 编译生成版本
            ReplaceVersion(Path.GetFullPath(Path.Combine(Src, $"{Proj_Name}.csproj")));
            Exec("dotnet", $"pack -c {Config}", Program.Src);
            // 还原包内容
            Exec("dotnet", "restore", Program.Src);
            Exec(@"C:\Program Files\Microsoft Visual Studio 2019\MSBuild\Current\Bin\msbuild.exe", $"/p:Configuration={Config} /t:pack", Program.Src);
            // 编译生成
            //var path_empty = Path.Combine(Program.Src, "_._");
            //if (!File.Exists(path_empty)) { File.WriteAllText(path_empty, ""); }
            Exec("dotnet", "pack", Program.Src);
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
        #region // Version

        private static void GenDirectoryBuildProps(string root)
        {
            using (XmlWriter f = XmlWriter.Create(Path.Combine(root, "Directory.Build.props"), new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            }))
            {
                f.WriteStartDocument();

                f.WriteComment("此文件自动生成");
                f.WriteStartElement("Project");
                f.WriteStartElement("PropertyGroup");

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
                f.WriteElementString("RepositoryUrl", "https://github.com/ErikZhouXin/YuShiITSSDK");
                f.WriteElementString("RepositoryType", "git");
                f.WriteElementString("PackageOutputPath", "$([System.IO.Path]::Combine($(MSBuildThisFileDirectory), 'bin'))");

                f.WriteElementString("cb_bin_path", "$([System.IO.Path]::Combine($(MSBuildThisFileDirectory), 'beans'))");
                f.WriteElementString("src_path", "$(MSBuildThisFileDirectory)");

                f.WriteEndElement(); // PropertyGroup
                f.WriteEndElement(); // project

                f.WriteEndDocument();
            }
        }
        #endregion
        #region // Generator Creater
        private static void write_nuspec_file_entry(string src, string target, XmlWriter f)
        {
            f.WriteStartElement("file");
            f.WriteAttributeString("src", src);
            f.WriteAttributeString("target", target);
            f.WriteEndElement(); // file
        }

        private static void GenNuspecLib(string dir_src)
        {
            string id = "NSystem.Data.YuShiITSSDK";
            string proj = "YuShiITSSDK";
            var sdks = new List<string> { "net40", "net45", "netstandard2.1", "netcoreapp3.1", "net6.0" };
            using (XmlWriter f = XmlWriter.Create(Path.Combine(dir_src, $"{proj}.csproj"), new XmlWriterSettings
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
                f.WriteElementString("NoBuild", "true");
                f.WriteElementString("GenerateDocumentationFile", "true");
                f.WriteElementString("EmbedAllSources", "true");
                f.WriteElementString("IncludeBuildOutput", "false");
                f.WriteElementString("NuspecFile", $"{id}.nuspec");
                f.WriteElementString("NuspecProperties", "version=$(version);src_path=$(src_path);cb_bin_path=$(cb_bin_path);authors=$(Authors);copyright=$(Copyright);summary=$(Description)");

                f.WriteEndElement(); // PropertyGroup

                f.WriteStartElement("ItemGroup");

                f.WriteStartElement("Compile");
                f.WriteAttributeString("Remove", "beans\\**");
                f.WriteEndElement();
                f.WriteStartElement("EmbeddedResource");
                f.WriteAttributeString("Remove", "beans\\**");
                f.WriteEndElement();
                f.WriteStartElement("None");
                f.WriteAttributeString("Remove", "beans\\**");
                f.WriteEndElement();
                f.WriteStartElement("None");
                f.WriteAttributeString("Remove", "Directory.Build.props");
                f.WriteEndElement();

                f.WriteEndElement(); // ItemGroup

                f.WriteEndElement(); // Project

                f.WriteEndDocument();
            }

            using (XmlWriter f = XmlWriter.Create(Path.Combine(dir_src, string.Format("{0}.nuspec", id)), new XmlWriterSettings
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
                f.WriteElementString("version", "$version$");
                f.WriteElementString("authors", "$authors$");
                f.WriteElementString("copyright", "$copyright$");
                f.WriteElementString("requireLicenseAcceptance", "false");
                f.WriteStartElement("license");
                f.WriteAttributeString("type", "expression");
                f.WriteString("MIT");
                f.WriteEndElement();
                f.WriteStartElement("repository");
                f.WriteAttributeString("type", "git");
                f.WriteAttributeString("url", "https://github.com/ErikZhouXin/YuShiITSSDK");
                f.WriteEndElement(); // repository
                f.WriteElementString("summary", "$summary$");
                f.WriteElementString("tags", PACKAGE_TAGS);

                f.WriteElementString("description", "宇视SDK");

                f.WriteEndElement(); // metadata

                f.WriteStartElement("files");

                var cpuTags = new List<string> { "win-x86", "win-x64", "win-arm", "win-arm64", "win10-x86", "win10-x64", "win10-arm", "win10-arm64", "x86", "x64" };
                foreach (var cpuTag in cpuTags)
                {
                    var platform = cpuTag.IndexOf("64") > 0 ? "x64" : "x86";
                    foreach (var item in Directory.GetFiles(Path.Combine(Src, "beans", platform)))
                    {
                        var fileName = Path.GetFileName(item);
                        write_nuspec_file_entry(Path.Combine("$cb_bin_path$", platform, fileName), $"runtimes\\{cpuTag}\\native\\{fileName}", f);
                    }
                }

                var tname = string.Format("{0}.targets", id);
                var path_targets = Path.Combine(dir_src, tname);
                var relpath_targets = Path.Combine(".", tname);

                using (XmlWriter ftar = XmlWriter.Create(path_targets, new XmlWriterSettings
                {
                    NewLineChars = "\n",
                    Indent = true,
                    OmitXmlDeclaration = false
                }))
                {
                    ftar.WriteStartDocument();
                    ftar.WriteComment("自动生成");

                    ftar.WriteStartElement("Project", "http://schemas.microsoft.com/developer/msbuild/2003");
                    ftar.WriteAttributeString("ToolsVersion", "4.0");

                    ftar.WriteStartElement("ItemGroup");
                    //ftar.WriteAttributeString("Condition", " '$(RuntimeIdentifier)' == '' AND '$(OS)' == 'Windows_NT' ");

                    foreach (var cpuTag in cpuTags)
                    {
                        var platform = cpuTag.IndexOf("64") > 0 ? "x64" : "x86";
                        foreach (var item in Directory.GetFiles(Path.Combine(Src, "beans", platform)))
                        {
                            var fileName = Path.GetFileName(item);
                            ftar.WriteStartElement("Content");
                            ftar.WriteAttributeString("Include", $"$(MSBuildThisFileDirectory)..\\..\\runtimes\\{cpuTag}\\native\\{fileName}");
                            ftar.WriteElementString("Link", $"runtimes\\{cpuTag}\\native\\{fileName}");
                            ftar.WriteElementString("CopyToOutputDirectory", "PreserveNewest");
                            ftar.WriteElementString("Pack", "false");
                            ftar.WriteEndElement(); // Content
                        }
                    }

                    ftar.WriteEndElement(); // ItemGroup

                    ftar.WriteEndElement(); // Project

                    ftar.WriteEndDocument();
                }

                //write_nuspec_file_entry(relpath_targets, string.Format("build\\net45"), f);
                //write_nuspec_file_entry(relpath_targets, string.Format("build\\net40"), f);
                //write_nuspec_file_entry(relpath_targets, string.Format("build\\netstandard2.0"), f);
                // 支持的SDK
                foreach (var sdkName in sdks)
                {
                    try
                    {
                        foreach (var file in Directory.GetFiles(Path.Combine(dir_src, "bin", Config, sdkName)))
                        {
                            var fileName = Path.GetFileName(file);
                            f.WriteStartElement("file");
                            f.WriteAttributeString("src", $"bin\\{Config}\\{sdkName}\\{fileName}");
                            f.WriteAttributeString("target", $"lib/{sdkName}/{fileName}");
                            f.WriteEndElement(); // file
                        }
                    }
                    catch { }
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
