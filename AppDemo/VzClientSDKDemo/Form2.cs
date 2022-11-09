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

namespace VzClientSDKDemo
{
    public partial class Form2 : Form
    {

        private int m_hLPRClient = 0;
        private int m_nPlayHandle = 0;

        private VzClientSDK.VZLPRC_WLIST_QUERY_CALLBACK m_wlistCB = null;

        public Form2()
        {
            InitializeComponent();
        }
        
        public void Setm_hLPRClient(int m_hLPRClient_){
            m_hLPRClient = m_hLPRClient_;
            SearchText();
        }
        public void Setm_nPlayHandle(int m_nPlayHandle_){
            m_nPlayHandle = m_nPlayHandle_;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addbt_Click(object sender, EventArgs e)
        {
            Form3 listform = new Form3();
            listform.Setm_hLPRClient(m_hLPRClient);
            listform.StartPosition = FormStartPosition.CenterScreen;
            listform.GetForm2(this);
            listform.Show();
        }

        private void changebt_Click(object sender, EventArgs e)
        {
            
            Form4 listform = new Form4();
            listform.Setm_hLPRClient(m_hLPRClient);

            int index = 0;
            if (this.listView1.SelectedItems.Count > 0)
            {
                index = this.listView1.SelectedItems[0].Index;
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
                //listView1.Clear();
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
            VzClientSDK.VZ_TM struTMOverdule = (VzClientSDK.VZ_TM)Marshal.PtrToStructure(wlistVehicle.pStruTMOverdule, typeof(VzClientSDK.VZ_TM));
            ShowSearchCrossThread SearchDelegate = delegate()
            {
                ListViewItem item = new ListViewItem();
                item.SubItems[0].Text = (wlistVehicle.uVehicleID.ToString());
                item.SubItems.Add(wlistVehicle.strPlateID.ToString());
                item.SubItems.Add(wlistVehicle.bEnable.ToString());

                //item.SubItems.Add(wlistVehicle.uVehicleID.ToString());
                item.SubItems.Add(struTMOverdule.nYear.ToString() + "-" + struTMOverdule.nMonth.ToString()
                    + "-" + struTMOverdule.nMDay + " " + struTMOverdule.nHour.ToString()
                    + ":" + struTMOverdule.nMin.ToString() + ":" + struTMOverdule.nSec.ToString());

                item.SubItems.Add(wlistVehicle.bAlarm.ToString());
                listView1.Items.Add(item);
            };

            listView1.Invoke(SearchDelegate);
        }

        public void SearchText(){

            ClearListView();
            // 设置一体机白名单结果回调
            m_wlistCB = new VzClientSDK.VZLPRC_WLIST_QUERY_CALLBACK(OnWlistQueryResult);
            VzClientSDK.VzLPRClient_WhiteListSetQueryCallBack(m_hLPRClient, m_wlistCB, IntPtr.Zero);

            VzClientSDK.VZ_LPR_WLIST_LIMIT limit = new VzClientSDK.VZ_LPR_WLIST_LIMIT();
            VzClientSDK.VZ_LPR_WLIST_LOAD_CONDITIONS conditions = new VzClientSDK.VZ_LPR_WLIST_LOAD_CONDITIONS();
            limit.limitType = VzClientSDK.VZ_LPR_WLIST_LIMIT_TYPE.VZ_LPR_WLIST_LIMIT_TYPE_ALL;
            //limit.pRangeLimit = null;
            conditions.pLimit = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VzClientSDK.VZ_LPR_WLIST_LIMIT)));
            Marshal.StructureToPtr(limit, conditions.pLimit, true);
            //conditions.pSortType = null;

            VzClientSDK.VZ_LPR_WLIST_SEARCH_CONSTRAINT searchConstraint = new VzClientSDK.VZ_LPR_WLIST_SEARCH_CONSTRAINT();
            searchConstraint.key = "PlateID";
            searchConstraint.search_string = searchtext.Text.ToString();
            VzClientSDK.VZ_LPR_WLIST_SEARCH_WHERE searchWhere = new VzClientSDK.VZ_LPR_WLIST_SEARCH_WHERE();
            searchWhere.pSearchConstraints = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VzClientSDK.VZ_LPR_WLIST_SEARCH_CONSTRAINT)));
            Marshal.StructureToPtr(searchConstraint, searchWhere.pSearchConstraints, true);
            searchWhere.searchConstraintCount = 1;
            searchWhere.searchType = VzClientSDK.VZ_LPR_WLIST_SEARCH_TYPE.VZ_LPR_WLIST_SEARCH_TYPE_LIKE;

            conditions.pSearchWhere = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VzClientSDK.VZ_LPR_WLIST_SEARCH_WHERE)));
            Marshal.StructureToPtr(searchWhere, conditions.pSearchWhere, true);

            VzClientSDK.VzLPRClient_WhiteListLoadVehicle(m_hLPRClient, ref conditions);

            Marshal.FreeHGlobal(conditions.pLimit);
            Marshal.FreeHGlobal(searchWhere.pSearchConstraints);
            Marshal.FreeHGlobal(conditions.pSearchWhere);

        }

        private void searchbt_Click(object sender, EventArgs e)
        {
            SearchText();
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
