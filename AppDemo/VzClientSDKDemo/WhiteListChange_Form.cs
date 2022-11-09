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
    public partial class WhiteListChange_Form : Form
    {
        private int m_hLPRClient = 0;
        private int m_nCurPage = 0;

        private uint Update_lVehicleID;
        WhiteList_Form form2;
        public WhiteListChange_Form()
        {
            InitializeComponent();
        }
        public void GetForm2(WhiteList_Form form2_){
            form2 = form2_;
        }
        public void UpdatePalate(uint lVehicleID,string PlateID,bool bEnable,
            string strOverdule,bool bAlarm){
            Update_lVehicleID = lVehicleID;
            if(string.Compare(strOverdule," ") == 0)
                ShowView(PlateID, bEnable, "2015年01月01日 00:00:00", bAlarm);
            else
                ShowView(PlateID, bEnable, strOverdule, bAlarm);
        }

        private delegate void ShowThread();
        //显示所选信息
        public void ShowView(string PlateID, bool bEnable,
            string strOverdule, bool bAlarm)
        {
            ShowThread ShowDelegate = delegate()
            {
                strPalatID.Text = PlateID;
                if (bEnable)
                    isenable.Checked = true;
                if(bAlarm)
                    isalarm.Checked = true;
                //DateTime dt1 = Convert.ToDateTime(strOverdule);
                DateTime dte = Convert.ToDateTime(strOverdule); 
                datalist.Text = dte.ToString();
            };
            this.Invoke(ShowDelegate);
        }

        public void SetLPRHandle(int m_hLPRClient_)
        {
            m_hLPRClient = m_hLPRClient_;
        }

        public void SetWLCurPage(int nCurPage)
        {
            m_nCurPage = nCurPage;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            VzClientSDK.VZ_LPR_WLIST_VEHICLE wlistVehicle = new VzClientSDK.VZ_LPR_WLIST_VEHICLE();
            wlistVehicle.uVehicleID = Update_lVehicleID;
            if (isalarm.Checked)
                wlistVehicle.bAlarm = 1;
            else
                wlistVehicle.bAlarm = 0;
            if (isenable.Checked)
                wlistVehicle.bEnable = 1;
            else
                wlistVehicle.bEnable = 0;
            wlistVehicle.uCustomerID = 1;
            wlistVehicle.strPlateID = strPalatID.Text.ToString();
            wlistVehicle.struTMOverdule.nHour = Int16.Parse(datalist.Value.Hour.ToString());
            wlistVehicle.struTMOverdule.nMin = Int16.Parse(datalist.Value.Minute.ToString());
            wlistVehicle.struTMOverdule.nSec = Int16.Parse(datalist.Value.Second.ToString());
            wlistVehicle.struTMOverdule.nYear = Int16.Parse(datalist.Value.Year.ToString());
            wlistVehicle.struTMOverdule.nMonth = Int16.Parse(datalist.Value.Month.ToString());
            wlistVehicle.struTMOverdule.nMDay = Int16.Parse(datalist.Value.Day.ToString());
            wlistVehicle.bUsingTimeSeg = 1;
            wlistVehicle.bEnableTMOverdule = 1;

            VzClientSDK.VzLPRClient_WhiteListUpdateVehicleByID(m_hLPRClient, ref wlistVehicle);

            form2.SearchText(m_nCurPage);

            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
