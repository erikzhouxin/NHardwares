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
    public partial class WhiteListAdd_Form : Form
    {

        private int m_hLPRClient = 0;
        private int m_nAddPage = 0;
        WhiteList_Form form2;
        public WhiteListAdd_Form()
        {
            InitializeComponent();
        }

        public void GetForm2(WhiteList_Form form2_)
        {
            form2 = form2_;
        }
        public void SetLPRHandle(int m_hLPRClient_)
        {
            m_hLPRClient = m_hLPRClient_;
        }

        public void SetWLAddPage(int nCurPage)
        {
            m_nAddPage = nCurPage;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            VzClientSDK.VZ_LPR_WLIST_VEHICLE wlistVehicle = new VzClientSDK.VZ_LPR_WLIST_VEHICLE();

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

            //string data = datalist.Value.ToString();
            wlistVehicle.bUsingTimeSeg = 1;
            wlistVehicle.bEnableTMOverdule = 1;
            wlistVehicle.iColor = 0;											/**<车辆颜色*/
            wlistVehicle.iPlateType = 0;

            wlistVehicle.strCode = strPalatID.Text.ToString();
            wlistVehicle.strComment = "";

            VzClientSDK.VZ_LPR_WLIST_ROW wlist = new VzClientSDK.VZ_LPR_WLIST_ROW();
            wlist.pVehicle = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VzClientSDK.VZ_LPR_WLIST_VEHICLE)));
            Marshal.StructureToPtr(wlistVehicle, wlist.pVehicle, true);

            VzClientSDK.VZ_LPR_WLIST_IMPORT_RESULT importResult = new VzClientSDK.VZ_LPR_WLIST_IMPORT_RESULT();

            int ret = VzClientSDK.VzLPRClient_WhiteListImportRows(m_hLPRClient, 1, ref wlist, ref importResult);

            Marshal.FreeHGlobal(wlist.pVehicle);

            form2.GetTotalCount();

            form2.SearchText(m_nAddPage);
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void isalarm_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void datalist_ValueChanged(object sender, EventArgs e)
        {

        }

        private void isenable_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void strPalatID_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
