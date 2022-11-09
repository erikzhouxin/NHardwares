using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace VzClientSDKDemo
{
    public partial class PlateQuery_Form : Form
    {
        string m_strPlate;
        string m_strPageMsg;

        string m_strStartTime;
        string m_strEndTime;
        string txtPicPath;

        int m_nTotalCount;
        int m_nCurPage;
        int m_nPageCount;
        private int m_hLPRClient = 0;
        private int ONE_PAGE_COUNT = 50;

        private VzClientSDK.VZLPRC_PLATE_INFO_CALLBACK OnQueryPlateInfo = null;
        public PlateQuery_Form()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e) 
        {
            this.listView1.Columns.Add("记录 ID");
            this.listView1.Columns.Add("车牌号");
            this.listView1.Columns.Add("记录时间");
            this.listView1.Columns.Add("识别类型");
            this.listView1.Columns.Add("车牌颜色");
            this.listView1.View = System.Windows.Forms.View.Details;
            listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            listView1.LabelEdit = true;
            // Allow the user to rearrange columns.
            listView1.AllowColumnReorder = true;
            listView1.Columns[0].Width = 85;
            listView1.Columns[1].Width = 85;
            listView1.Columns[2].Width = 140;
            listView1.Columns[3].Width = 85;
            listView1.Columns[4].Width = 85;
        }

        private int gOnQueryPlateInfo(int handle, IntPtr pUserData,
                                                    IntPtr pResult, uint uNumPlates,
                                                    VzClientSDK.VZ_LPRC_RESULT_TYPE eResultType,
                                                    IntPtr pImgFull,
                                                    IntPtr pImgPlateClip)
        {
            if (pUserData != null && pResult != null)
            {
                VzClientSDK.TH_PlateResult result = (VzClientSDK.TH_PlateResult)Marshal.PtrToStructure(pResult, typeof(VzClientSDK.TH_PlateResult));
                if (pResult != null)
                {
                    string strPlateID = result.uId.ToString();
                    string license = new string(result.license);
                    string time = result.struBDTime.bdt_year + "-" + result.struBDTime.bdt_mon.ToString().PadLeft(2, '0') +
                        "-" + result.struBDTime.bdt_mday.ToString().PadLeft(2, '0') + " " + result.struBDTime.bdt_hour.ToString().PadLeft(2, '0') +
                        ":" + result.struBDTime.bdt_min.ToString().PadLeft(2, '0') + ":" +
                        result.struBDTime.bdt_sec.ToString().PadLeft(2, '0');

                    ListViewShow(strPlateID, license, time, eResultType.ToString(), result.nColor);
                }
            }
            return 0;
        }

        private delegate void ListViewShowThread();
        //触发结果显示
        public void ListViewShow(string ID,string license,string time,string type,int nColor)
        {
            ListViewShowThread ListViewShowDelegate = delegate()
            {
                ListViewItem item = new ListViewItem();
                item.SubItems[0].Text = (ID);
                item.SubItems.Add(license);
                item.SubItems.Add(time);
                if (type == "VZ_LPRC_RESULT_STABLE")
                {
                    item.SubItems.Add("稳定结果");
                }
                else if (type == "VZ_LPRC_RESULT_FORCE_TRIGGER")
                {
                    item.SubItems.Add("手动触发");
                }
                else if (type == "VZ_LPRC_RESULT_IO_TRIGGER")
                {
                    item.SubItems.Add("地感触发");
                }
                else if (type == "VZ_LPRC_RESULT_VLOOP_TRIGGER")
                {
                    item.SubItems.Add("虚拟线圈");
                }
                else if (type == "VZ_LPRC_RESULT_MULTI_TRIGGER")
                {
                    item.SubItems.Add("多重触发");
                }

                if(nColor == 0)
                {
                    item.SubItems.Add("未知");
                }
                if (nColor == 1)
                {
                    item.SubItems.Add("蓝色");
                }
                if (nColor == 2)
                {
                    item.SubItems.Add("黄色");
                }
                if (nColor == 3)
                {
                    item.SubItems.Add("白色");
                }
                if (nColor == 4)
                {
                    item.SubItems.Add("黑色");
                }
                if (nColor == 5)
                {
                    item.SubItems.Add("绿色");
                }
                listView1.Items.Add(item);
            };
            listView1.Invoke(ListViewShowDelegate);
        }

        public void SetLPRHandle(int m_hLPRClient_,string picpath)
        {
            txtPicPath = picpath;
            m_hLPRClient = m_hLPRClient_;
            OnQueryPlateInfo = new VzClientSDK.VZLPRC_PLATE_INFO_CALLBACK(gOnQueryPlateInfo);
            VzClientSDK.VzLPRClient_SetQueryPlateCallBack(m_hLPRClient, OnQueryPlateInfo, IntPtr.Zero);
        }

        private delegate void ListViewClearThread();
        //触发结果显示
        public void ListViewClear()
        {
            ListViewClearThread ListViewClearDelegate = delegate()
            {
                listView1.Items.Clear();
            };
            listView1.Invoke(ListViewClearDelegate);
        }

        private void QueryByPage(int nPageIndex)
        {
            ListViewClear();
            VzClientSDK.VzLPRClient_QueryPageRecordByTimeAndPlate(m_hLPRClient, m_strStartTime, m_strEndTime, m_strPlate, nPageIndex * ONE_PAGE_COUNT, (nPageIndex + 1) * ONE_PAGE_COUNT);
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            ListViewClear();
            m_nTotalCount = 0;
            m_nCurPage = 0;
            m_nPageCount = 0;

            string szStartTime = starttimeday.Value.Year + "-" + starttimeday.Value.Month.ToString().PadLeft(2,'0') + "-" +
                starttimeday.Value.Day.ToString().PadLeft(2, '0') + " " + starttimehour.Value.Hour.ToString().PadLeft(2,'0') + ":" +
                starttimehour.Value.Minute.ToString().PadLeft(2, '0') + ":" + starttimehour.Value.Second.ToString().PadLeft(2, '0');

            string szEndTime = endtimeday.Value.Year + "-" + endtimeday.Value.Month.ToString().PadLeft(2, '0') + "-" +
                endtimeday.Value.Day.ToString().PadLeft(2, '0') + " " + endtimehour.Value.Hour.ToString().PadLeft(2, '0') + ":" +
                endtimehour.Value.Minute.ToString().PadLeft(2, '0') + ":" + endtimehour.Value.Second.ToString().PadLeft(2, '0');

            m_strPlate = plateedit.Text.ToString();
            int count = VzClientSDK.VzLPRClient_QueryCountByTimeAndPlate(m_hLPRClient, szStartTime, szEndTime, plateedit.Text.ToString());
            string szPageMsg;
            if(count > 0)
            {
                int pageSize = count / ONE_PAGE_COUNT;
                int nPageCount = (count % ONE_PAGE_COUNT == 0) ? pageSize : (pageSize + 1);
                szPageMsg = "共" + count.ToString() + "条记录,1/" + nPageCount.ToString();
                m_nTotalCount = count;
                m_nPageCount = nPageCount;
                m_strStartTime = szStartTime;
                m_strEndTime = szEndTime;

                QueryByPage(0);
            }
            else
            {
                szPageMsg = "共 0 条记录";
            }
            m_strPageMsg = szPageMsg;
            PlatePageMsgShow();
        }

        private delegate void PlatePageMsgShowThread();
        //触发结果显示
        public void PlatePageMsgShow()
        {
            PlatePageMsgShowThread PlatePageMsgShowDelegate = delegate()
            {
                platemsglabel.Text = m_strPageMsg;
            };
            platemsglabel.Invoke(PlatePageMsgShowDelegate);
        }

        private void nextpage_Click(object sender, EventArgs e)
        {
            int nCurPage = m_nCurPage + 1;
            if(nCurPage < m_nPageCount)
            {
                QueryByPage(nCurPage);
                m_nCurPage++;
                m_strPageMsg = "共" + m_nTotalCount.ToString() + "条记录," + (m_nCurPage + 1).ToString() + "/" + m_nPageCount.ToString();
                PlatePageMsgShow();
            }
            else
            {
                MessageBox.Show("无下一页记录！");
            }
        }

        private void prepage_Click(object sender, EventArgs e)
        {
            int nCurPage = m_nCurPage - 1;
            if(nCurPage >= 0)
            {
                QueryByPage(nCurPage);
                m_nCurPage--;
                m_strPageMsg = "共" + m_nTotalCount.ToString() + "条记录," + (m_nCurPage + 1).ToString() + "/" + m_nPageCount.ToString();
                PlatePageMsgShow(); 
            }
            else
            {
                MessageBox.Show("无上一页记录！");
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            
            int id = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            int[] picsize = new int[1];
            picsize[0] = 1024 * 1024;
            GCHandle hObjectsize = GCHandle.Alloc(picsize, GCHandleType.Pinned);
            IntPtr pObjectsize = hObjectsize.AddrOfPinnedObject();

            byte[] picdata = new byte[1024 * 1024];
            GCHandle hObject = GCHandle.Alloc(picdata, GCHandleType.Pinned);
            IntPtr pObject = hObject.AddrOfPinnedObject();
            int ret = VzClientSDK.VzLPRClient_LoadImageById(m_hLPRClient, id, pObject, pObjectsize);

            string path = txtPicPath + id.ToString() + ".jpg";
            if (ret == 0 && picsize[0] > 0 && picsize[0] < 1024 * 1024)
            {
                FileStream aFile = new FileStream(path, FileMode.Create);
                // Move file pointer to beginning of file.
                aFile.Seek(0, SeekOrigin.Begin);
                aFile.Write(picdata, 0, picdata.Length);
                aFile.Close();
            }
            else
            {
                MessageBox.Show("图片已被删除！");
                return;
            }

            QueryPicShow Pic_Form = new QueryPicShow();
            Pic_Form.Show();
            Pic_Form.SetPicPath(path);
            //Pic_Form.pictureBox1.Image = Image.FromFile(path);

            if (hObjectsize.IsAllocated)
                hObjectsize.Free();
            if (hObject.IsAllocated)
                hObject.Free();
        }

    }
}
