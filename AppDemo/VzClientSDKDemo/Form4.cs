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
    public partial class Form4 : Form
    {
        private int m_hLPRClient = 0;
        private uint Update_lVehicleID;
        Form2 form2;
        public Form4()
        {
            InitializeComponent();
        }
        public void GetForm2(Form2 form2_){
            form2 = form2_;
        }
        public void UpdatePalate(uint lVehicleID,string PlateID,bool bEnable,
            string strOverdule,bool bAlarm){
            Update_lVehicleID = lVehicleID;
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

        public void Setm_hLPRClient(int m_hLPRClient_)
        {
            m_hLPRClient = m_hLPRClient_;
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
            VzClientSDK.VZ_TM struTMOverdule = new VzClientSDK.VZ_TM();
            struTMOverdule.nHour = Int16.Parse(datalist.Value.Hour.ToString());
            struTMOverdule.nMin = Int16.Parse(datalist.Value.Minute.ToString());
            struTMOverdule.nSec = Int16.Parse(datalist.Value.Second.ToString());
            struTMOverdule.nYear = Int16.Parse(datalist.Value.Year.ToString());
            struTMOverdule.nMonth = Int16.Parse(datalist.Value.Month.ToString());
            struTMOverdule.nMDay = Int16.Parse(datalist.Value.Day.ToString());
            wlistVehicle.pStruTMOverdule = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VzClientSDK.VZ_TM)));
            Marshal.StructureToPtr(struTMOverdule, wlistVehicle.pStruTMOverdule, true);
            wlistVehicle.bUsingTimeSeg = 1;

            VzClientSDK.VzLPRClient_WhiteListUpdateVehicleByID(m_hLPRClient, ref wlistVehicle);
            Marshal.FreeHGlobal(wlistVehicle.pStruTMOverdule);

            form2.SearchText();

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
