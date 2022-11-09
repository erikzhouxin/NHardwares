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
    public partial class WhiteList_Form : Form
    {
        private const int IMPORT_COUNT = 1000;
        private const int ONE_PAGE_COUNT = 20;

        private int m_hLPRClient = 0;

        private int m_nTotalCount = 0;
        private int m_nCurPage = 0;
        private int m_nPageCount = 0;


	
        private VzClientSDK.VZ_LPR_WLIST_VEHICLE[] m_arrVehicle;
        private VzClientSDK.VZ_LPR_WLIST_ROW[] m_arrWlistRow;
        private VzClientSDK.VZ_LPR_WLIST_IMPORT_RESULT[] m_arrImportResult;


        private VzClientSDK.VZLPRC_WLIST_QUERY_CALLBACK m_wlistCB = null;

        public WhiteList_Form()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.listView1.Columns.Add("车牌 ID");
            this.listView1.Columns.Add("车牌号");
            this.listView1.Columns.Add("是否启用");
            this.listView1.Columns.Add("过期时间");
            this.listView1.Columns.Add("是否报警");
            this.listView1.View = System.Windows.Forms.View.Details;
            listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            listView1.LabelEdit = true;
            // Allow the user to rearrange columns.
            listView1.AllowColumnReorder = true;
            listView1.Columns[0].Width = 70;
            listView1.Columns[1].Width = 90;
            listView1.Columns[2].Width = 70;
            listView1.Columns[3].Width = 155;
            listView1.Columns[4].Width = 70;

            m_arrVehicle = new VzClientSDK.VZ_LPR_WLIST_VEHICLE[IMPORT_COUNT];
            m_arrWlistRow = new VzClientSDK.VZ_LPR_WLIST_ROW[IMPORT_COUNT];
            m_arrImportResult = new VzClientSDK.VZ_LPR_WLIST_IMPORT_RESULT[IMPORT_COUNT];
        }

        public void SetLPRHandle(int m_hLPRClient_){
            m_hLPRClient = m_hLPRClient_;
            //SearchText();
        }


        private void addbt_Click(object sender, EventArgs e)
        {
            WhiteListAdd_Form listform = new WhiteListAdd_Form();
            listform.SetLPRHandle(m_hLPRClient);
            listform.SetWLAddPage(m_nPageCount -1);
            listform.StartPosition = FormStartPosition.CenterScreen;
            listform.GetForm2(this);
            listform.Show();
        }

        private void changebt_Click(object sender, EventArgs e)
        {
            
            WhiteListChange_Form listform = new WhiteListChange_Form();
            listform.SetLPRHandle(m_hLPRClient);
            listform.SetWLCurPage(m_nCurPage);

            int index = 0;
            if (this.listView1.SelectedItems.Count > 0)
            {
                index = this.listView1.SelectedItems[0].Index;
            }
            else
            {
                return;
            }
            int bEnable = Int32.Parse(listView1.Items[index].SubItems[2].Text.ToString());
            int bAlarm = Int32.Parse(listView1.Items[index].SubItems[4].Text.ToString());
            listform.GetForm2(this);
            listform.StartPosition = FormStartPosition.CenterScreen;
            listform.Show();
            listform.UpdatePalate(UInt32.Parse(listView1.Items[index].SubItems[0].Text.ToString()),
                listView1.Items[index].SubItems[1].Text.ToString(),
                bEnable == 0 ? false:true,
                listView1.Items[index].SubItems[3].Text.ToString(),
                bAlarm == 0 ? false:true
                );
        }

        private void deletebt_Click(object sender, EventArgs e)
        {
            int index = -1;
            if (this.listView1.SelectedItems.Count > 0){
                index = this.listView1.SelectedItems[0].Index;
            }
            if (index != -1)
            {
                string strPlateID = listView1.Items[index].SubItems[1].Text.ToString();
                VzClientSDK.VzLPRClient_WhiteListDeleteVehicle(m_hLPRClient, strPlateID);
                ShowDeleteResult(strPlateID);
            }
        }
        private delegate void ShowDeleteCrossThread();
        //查询结果显示
        public void ShowDeleteResult(String strPlateID)
        {
            ShowDeleteCrossThread DeleteDelegate = delegate()
             {
                 int index = 0;
                 if(this.listView1.SelectedItems.Count > 0){
                     index = this.listView1.SelectedItems[0].Index;
                     listView1.Items[index].Remove();
                 }
             };
            listView1.Invoke(DeleteDelegate);
        }
        private delegate void ClearListViewThread();
        //查询清除显示
        public void ClearListView()
        {
            ClearListViewThread ClearDelegate = delegate()
            {
                listView1.Items.Clear();
            };
            listView1.Invoke(ClearDelegate);
        }

        private void OnWlistQueryResult(VzClientSDK.VZLPRC_WLIST_CB_TYPE type, IntPtr pLP,
                                                  IntPtr pCustomer,
                                                  IntPtr pUserData)
        {
            if (pLP != IntPtr.Zero)
            {
                ShowSearchResult(pLP);
            }
            if (pCustomer != IntPtr.Zero)
            {
                VzClientSDK.VZ_LPR_WLIST_CUSTOMER wlistCustomer = (VzClientSDK.VZ_LPR_WLIST_CUSTOMER)Marshal.PtrToStructure(pCustomer, typeof(VzClientSDK.VZ_LPR_WLIST_CUSTOMER));
            }
        }

        private delegate void ShowSearchCrossThread();
        //查询结果显示
        public void ShowSearchResult(IntPtr pLP)
        {
            VzClientSDK.VZ_LPR_WLIST_VEHICLE wlistVehicle = (VzClientSDK.VZ_LPR_WLIST_VEHICLE)Marshal.PtrToStructure(pLP, typeof(VzClientSDK.VZ_LPR_WLIST_VEHICLE));
            ShowSearchCrossThread SearchDelegate = delegate()
            {
                ListViewItem item = new ListViewItem();
                item.SubItems[0].Text = (wlistVehicle.uVehicleID.ToString());
                item.SubItems.Add(wlistVehicle.strPlateID.ToString());
                item.SubItems.Add(wlistVehicle.bEnable.ToString());

                //item.SubItems.Add(wlistVehicle.uVehicleID.ToString());
                item.SubItems.Add(wlistVehicle.struTMOverdule.nYear.ToString() + "-" + wlistVehicle.struTMOverdule.nMonth.ToString()
                    + "-" + wlistVehicle.struTMOverdule.nMDay + " " + wlistVehicle.struTMOverdule.nHour.ToString()
                    + ":" + wlistVehicle.struTMOverdule.nMin.ToString() + ":" + wlistVehicle.struTMOverdule.nSec.ToString());

                item.SubItems.Add(wlistVehicle.bAlarm.ToString());
                listView1.Items.Add(item);
            };

            listView1.Invoke(SearchDelegate);
        }

        public void SearchText(int nPageIndex)
        {
            ClearListView();

            //设置一体机白名单结果回调
            m_wlistCB = new VzClientSDK.VZLPRC_WLIST_QUERY_CALLBACK(OnWlistQueryResult);
            VzClientSDK.VzLPRClient_WhiteListSetQueryCallBack(m_hLPRClient, m_wlistCB, IntPtr.Zero);

            VzClientSDK.VZ_LPR_WLIST_LIMIT limit = new VzClientSDK.VZ_LPR_WLIST_LIMIT();
            limit.limitType = VzClientSDK.VZ_LPR_WLIST_LIMIT_TYPE.VZ_LPR_WLIST_LIMIT_TYPE_RANGE;

            //limit.pRangeLimit = null;
            // 起始范围的定义
            VzClientSDK.VZ_LPR_WLIST_RANGE_LIMIT rangLimit = new VzClientSDK.VZ_LPR_WLIST_RANGE_LIMIT();
            rangLimit.startIndex = nPageIndex * ONE_PAGE_COUNT;
            rangLimit.count = ONE_PAGE_COUNT;
            //rangLimit.startIndex = 0;
            //rangLimit.count = 200;


            limit.pRangeLimit = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VzClientSDK.VZ_LPR_WLIST_RANGE_LIMIT)));
            Marshal.StructureToPtr(rangLimit, limit.pRangeLimit, true);

           
            //conditions.pSortType = null;

            VzClientSDK.VZ_LPR_WLIST_SEARCH_CONSTRAINT searchConstraint = new VzClientSDK.VZ_LPR_WLIST_SEARCH_CONSTRAINT();
            searchConstraint.key = "PlateID";
            searchConstraint.search_string = searchtext.Text.ToString();

            VzClientSDK.VZ_LPR_WLIST_SEARCH_WHERE searchWhere = new VzClientSDK.VZ_LPR_WLIST_SEARCH_WHERE();
            searchWhere.pSearchConstraints = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VzClientSDK.VZ_LPR_WLIST_SEARCH_CONSTRAINT)));
            Marshal.StructureToPtr(searchConstraint, searchWhere.pSearchConstraints, true);
            searchWhere.searchConstraintCount = 1;
            searchWhere.searchType = VzClientSDK.VZ_LPR_WLIST_SEARCH_TYPE.VZ_LPR_WLIST_SEARCH_TYPE_LIKE;

            VzClientSDK.VZ_LPR_WLIST_LOAD_CONDITIONS conditions = new VzClientSDK.VZ_LPR_WLIST_LOAD_CONDITIONS();
            conditions.pLimit = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VzClientSDK.VZ_LPR_WLIST_LIMIT)));
            Marshal.StructureToPtr(limit, conditions.pLimit, true);
            conditions.pSearchWhere = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VzClientSDK.VZ_LPR_WLIST_SEARCH_WHERE)));
            Marshal.StructureToPtr(searchWhere, conditions.pSearchWhere, true);

            int nRecordCount = 0;
            int ret0 = VzClientSDK.VzLPRClient_WhiteListGetRowCount(m_hLPRClient,ref nRecordCount, ref searchWhere);

            int ret = VzClientSDK.VzLPRClient_WhiteListLoadVehicle(m_hLPRClient, ref conditions);

            Marshal.FreeHGlobal(conditions.pLimit);
            Marshal.FreeHGlobal(searchWhere.pSearchConstraints);
            Marshal.FreeHGlobal(conditions.pSearchWhere);

        }


        private void searchbt_Click(object sender, EventArgs e)
        {
            //m_nTotalCount = 0;
            //m_nCurPage = 0;
            //m_nPageCount = 0;

            //VzClientSDK.VZ_LPR_WLIST_SEARCH_CONSTRAINT searchConstraint = new VzClientSDK.VZ_LPR_WLIST_SEARCH_CONSTRAINT();
            //searchConstraint.key = "PlateID";
            //searchConstraint.search_string = searchtext.Text.ToString();

            //VzClientSDK.VZ_LPR_WLIST_SEARCH_WHERE searchWhere = new VzClientSDK.VZ_LPR_WLIST_SEARCH_WHERE();
            //searchWhere.pSearchConstraints = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VzClientSDK.VZ_LPR_WLIST_SEARCH_CONSTRAINT)));
            //Marshal.StructureToPtr(searchConstraint, searchWhere.pSearchConstraints, true);
            //searchWhere.searchConstraintCount = 1;
            //searchWhere.searchType = VzClientSDK.VZ_LPR_WLIST_SEARCH_TYPE.VZ_LPR_WLIST_SEARCH_TYPE_LIKE;


            ////获取记录的条数
            //uint nRecordCount = 0;
            //int ret = VzClientSDK.VzLPRClient_WhiteListGetVehicleCount(m_hLPRClient, ref nRecordCount, ref searchWhere);

            //int pageSize = (int)nRecordCount / ONE_PAGE_COUNT;
            //int nPageCount = (nRecordCount % ONE_PAGE_COUNT == 0) ? pageSize : pageSize + 1;

            //string szPageMsg = "第" + (m_nPageCount + 1).ToString() + "/" + nPageCount.ToString() + "页";
            //lblPageMsg.Text = szPageMsg;

            //string szCountMsg = "共" + nRecordCount.ToString() + "条记录";
            //lblCountMsg.Text = szCountMsg;

            //m_nTotalCount = (int)nRecordCount;
            //m_nPageCount = nPageCount;

            GetTotalCount();

            SearchText(0);
        }


        private void btnImportWL_Click(object sender, EventArgs e)
        {

            //选择.csv文件
            string strFilePath = "";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "csv files|*.csv";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                strFilePath = fileDialog.FileName;
                MessageBox.Show("已选择文件:" + strFilePath, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //csv文件读取到DataTable中
            if (strFilePath.Length == 0)
            {
                return;
            }
            DataTable csvDt = OpenCSV(strFilePath);

            //将DataTable数据传入WL参数
            dtToWL(csvDt);

            //查询数据
            SearchText(0);
            
            //获得页数、总条数
            GetTotalCount();


        }
        public void GetTotalCount()
        {
            m_nTotalCount = 0;
            m_nCurPage = 0;
            m_nPageCount = 0;

            VzClientSDK.VZ_LPR_WLIST_SEARCH_CONSTRAINT searchConstraint = new VzClientSDK.VZ_LPR_WLIST_SEARCH_CONSTRAINT();
            searchConstraint.key = "PlateID";
            searchConstraint.search_string = searchtext.Text.ToString();

            VzClientSDK.VZ_LPR_WLIST_SEARCH_WHERE searchWhere = new VzClientSDK.VZ_LPR_WLIST_SEARCH_WHERE();
            searchWhere.pSearchConstraints = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VzClientSDK.VZ_LPR_WLIST_SEARCH_CONSTRAINT)));
            Marshal.StructureToPtr(searchConstraint, searchWhere.pSearchConstraints, true);
            searchWhere.searchConstraintCount = 1;
            searchWhere.searchType = VzClientSDK.VZ_LPR_WLIST_SEARCH_TYPE.VZ_LPR_WLIST_SEARCH_TYPE_LIKE;


            //获取记录的条数
            uint nRecordCount = 0;
            int ret = VzClientSDK.VzLPRClient_WhiteListGetVehicleCount(m_hLPRClient, ref nRecordCount, ref searchWhere);

            int pageSize = (int)nRecordCount / ONE_PAGE_COUNT;
            int nPageCount = (nRecordCount % ONE_PAGE_COUNT == 0) ? pageSize : pageSize + 1;

            string szPageMsg = "第" + (m_nPageCount + 1).ToString() + "/" + nPageCount.ToString() + "页";
            lblPageMsg.Text = szPageMsg;

            string szCountMsg = "共" + nRecordCount.ToString() + "条记录";
            lblCountMsg.Text = szCountMsg;

            m_nTotalCount = (int)nRecordCount;
            m_nPageCount = nPageCount;

        }

        private  void dtToWL(DataTable dt)
        {
            //将DataTable转到白名单参数
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string szValue = dt.Rows[i][j].ToString();
                    switch (j)
                    {                       
                        case 0:
                            if(szValue != "")
                            m_arrVehicle[i].uVehicleID = uint.Parse(szValue); break;
                        case 1:
                            m_arrVehicle[i].strPlateID = szValue; break;
                        case 2:
                            m_arrVehicle[i].bEnable = (uint)(string.Equals(szValue,"是")?1:0);break;
                        case 3:
                            if (szValue.Length != 0)
                            {
                                DateTime datetime = Convert.ToDateTime(szValue); 
                                m_arrVehicle[i].bEnableTMEnable = 1;
                                m_arrVehicle[i].struTMEnable.nYear   = Int16.Parse(datetime.Year.ToString());
                                m_arrVehicle[i].struTMEnable.nMonth  = Int16.Parse(datetime.Month.ToString());
                                m_arrVehicle[i].struTMEnable.nMDay   = Int16.Parse(datetime.Day.ToString());
                                m_arrVehicle[i].struTMEnable.nHour   = Int16.Parse(datetime.Hour.ToString());
                                m_arrVehicle[i].struTMEnable.nMin    = Int16.Parse(datetime.Minute.ToString());
                                m_arrVehicle[i].struTMEnable.nSec    = Int16.Parse(datetime.Second.ToString());

                                break;
                            }
                            break;
                        case 4:
                            if (szValue.Length != 0)
                            {
                                DateTime datetime = Convert.ToDateTime(szValue);
                                m_arrVehicle[i].bEnableTMOverdule = 1;
                                m_arrVehicle[i].struTMOverdule.nYear = Int16.Parse(datetime.Year.ToString());
                                m_arrVehicle[i].struTMOverdule.nMonth = Int16.Parse(datetime.Month.ToString());
                                m_arrVehicle[i].struTMOverdule.nMDay = Int16.Parse(datetime.Day.ToString());
                                m_arrVehicle[i].struTMOverdule.nHour = Int16.Parse(datetime.Hour.ToString());
                                m_arrVehicle[i].struTMOverdule.nMin = Int16.Parse(datetime.Minute.ToString());
                                m_arrVehicle[i].struTMOverdule.nSec = Int16.Parse(datetime.Second.ToString());

                                break;
                            }
                            break;
                        case 5:
                            m_arrVehicle[i].bUsingTimeSeg = (uint)(string.Equals(szValue, "是") ? 1 : 0); break;
                        case 6:
                            break;
                        case 7:
                            m_arrVehicle[i].bAlarm = (uint)(string.Equals(szValue, "是") ? 1 : 0); break;
                        case 8:
                            m_arrVehicle[i].strCode = szValue; break;
                        case 9:
                            m_arrVehicle[i].strComment = szValue; break;

                        default:
                            break;
                    }
                }
            }

            uint count = (uint)dt.Rows.Count;
            for (int k = 0; k < count; k++)
            {
                m_arrWlistRow[k].pVehicle = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VzClientSDK.VZ_LPR_WLIST_VEHICLE)));
                Marshal.StructureToPtr(m_arrVehicle[k], m_arrWlistRow[k].pVehicle, true);
            }
            
            int nRet = VzClientSDK.VzLPRClient_WhiteListImportRows(m_hLPRClient, count, ref m_arrWlistRow[0], ref m_arrImportResult[0]);

            for (int i = 0; i < count; i++)
            {
                Marshal.FreeHGlobal(m_arrWlistRow[i].pVehicle);
            }
           
        }

        private  DataTable OpenCSV(string strFilePath)
        {
            string strLine = "";
            string[] aryLine;
            int columnCount = 0;
            bool IsFirst = true;

            DataTable dt = new DataTable();
            FileStream fs = new FileStream(strFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);

            while ((strLine = sr.ReadLine()) != null)
            {
                aryLine = strLine.Split(',');
                if (IsFirst == true)//读取标题栏
                {
                    IsFirst = false;
                    columnCount = aryLine.Length;

                    for (int i = 0; i < columnCount; i++)
                    {
                        DataColumn dc = new DataColumn(aryLine[i]);
                        dt.Columns.Add(dc);
                    }
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < columnCount; j++)
                    {
                        dr[j] = aryLine[j];
                    }
                    dt.Rows.Add(dr);
                }
            }
            sr.Close();
            fs.Close();

            return dt;

        }

        private delegate void ListViewClearThread();
       
        private void btnClearWL_Click(object sender, EventArgs e)
        {
            int nRet = VzClientSDK.VzLPRClient_WhiteListClearCustomersAndVehicles(m_hLPRClient);
            if (nRet != 0)
            {
                MessageBox.Show("白名单清空失败，请重试!");
                return;
            }
            MessageBox.Show("清空白名单成功!");

            m_nCurPage = 0;
            m_nPageCount = 0;
            m_nTotalCount = 0;

            ShowPageMsg(m_nCurPage);

            ShowTotalCount(m_nTotalCount);

            ClearListView();
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            SearchText(0);

            m_nCurPage = 0;

            ShowPageMsg(m_nCurPage);

        }

        private void btnPrePage_Click(object sender, EventArgs e)
        {
            int nCurPage = m_nCurPage - 1;
            if (nCurPage >= 0)
            {
                SearchText(nCurPage);

                m_nCurPage--;

                ShowPageMsg(m_nCurPage);
            }
            else
            {
                MessageBox.Show("无上一页记录!");
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            int nCurPage = m_nCurPage + 1;
            if (nCurPage < m_nPageCount)
            {
                m_nCurPage++;

                SearchText(nCurPage);

                ShowPageMsg(m_nCurPage);

            }
            else
            {
                MessageBox.Show("无下一条记录!");
            }
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            m_nCurPage = m_nPageCount - 1;

            SearchText(m_nCurPage);

            ShowPageMsg(m_nCurPage);
        }

        private void ShowPageMsg(int nCurPage)
        {
            string szPageMsg = "第" + (nCurPage + 1).ToString() + "/" + m_nPageCount.ToString() + "页";
            lblPageMsg.Text = szPageMsg;
        }

        private void ShowTotalCount(int nCount)
        {
            string szCountMsg = "共" + nCount.ToString() + "条记录";
            lblCountMsg.Text = szCountMsg;
        }
        
    }
}
