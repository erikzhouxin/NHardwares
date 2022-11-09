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
    public partial class Form3 : Form
    {

        private int m_hLPRClient = 0;
        Form2 form2;
        public Form3()
        {
            InitializeComponent();
        }

        public void GetForm2(Form2 form2_)
        {
            form2 = form2_;
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
            if(isalarm.Checked)
                wlistVehicle.bAlarm = 1;
            else
                wlistVehicle.bAlarm = 0;
            if(isenable.Checked)
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
            //string data = datalist.Value.ToString();
            wlistVehicle.bUsingTimeSeg = 1;

            VzClientSDK.VZ_LPR_WLIST_ROW wlist = new VzClientSDK.VZ_LPR_WLIST_ROW();
            wlist.pVehicle = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VzClientSDK.VZ_LPR_WLIST_VEHICLE)));
            Marshal.StructureToPtr(wlistVehicle, wlist.pVehicle, true);

            VzClientSDK.VZ_LPR_WLIST_IMPORT_RESULT importResult = new VzClientSDK.VZ_LPR_WLIST_IMPORT_RESULT();

            VzClientSDK.VzLPRClient_WhiteListImportRows(m_hLPRClient, 1, ref wlist, ref importResult);

            Marshal.FreeHGlobal(wlistVehicle.pStruTMOverdule);
            Marshal.FreeHGlobal(wlist.pVehicle);
            form2.SearchText();
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
