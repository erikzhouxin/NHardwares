using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace VzClientSDKDemo
{
    public partial class BaseConfig_From : Form
    {
        public BaseConfig_From()
        {
            InitializeComponent();           
        }

        private int m_hLPRClient = 0;
        public void SetLPRHandle(int hLPRClient)
        {
            m_hLPRClient = hLPRClient;
        }
        //获取识别类型
        private void getPlateRecType()
        {
            int uBitsRecType = 0;
            VzClientSDK.VzLPRClient_GetPlateRecType(m_hLPRClient, ref uBitsRecType);            
            m_chkBlue.Checked       = Convert.ToBoolean((int)uBitsRecType & VzClientSDK.VZ_LPRC_REC_BLUE);
            m_chkYellow.Checked = Convert.ToBoolean((int)uBitsRecType & VzClientSDK.VZ_LPRC_REC_YELLOW);
            m_chkBlack.Checked = Convert.ToBoolean((int)uBitsRecType & VzClientSDK.VZ_LPRC_REC_BLACK);
            m_chkCoach.Checked = Convert.ToBoolean((int)uBitsRecType & VzClientSDK.VZ_LPRC_REC_COACH);
            m_chkTablets.Checked = Convert.ToBoolean((int)uBitsRecType & VzClientSDK.VZ_LPRC_REC_POLICE);
            m_chkArm.Checked = Convert.ToBoolean((int)uBitsRecType & VzClientSDK.VZ_LPRC_REC_AMPOL);
            m_chkTag.Checked = Convert.ToBoolean((int)uBitsRecType & VzClientSDK.VZ_LPRC_REC_ARMY);
            m_chkHK.Checked = Convert.ToBoolean((int)uBitsRecType & VzClientSDK.VZ_LPRC_REC_GANGAO);
            m_chkEC.Checked = Convert.ToBoolean((int)uBitsRecType & VzClientSDK.VZ_LPRC_REC_EMBASSY);
            m_chkAviation.Checked = Convert.ToBoolean((int)uBitsRecType & VzClientSDK.VZ_LPRC_REC_AVIATION);
            m_chkEnergy.Checked = Convert.ToBoolean((int)uBitsRecType & VzClientSDK.VZ_LPRC_REC_ENERGY);
            m_chkNoPlate.Checked = Convert.ToBoolean((int)uBitsRecType & VzClientSDK.VZ_LPRC_REC_NO_PLATE);
        }
        //设置识别类型
        private bool setPlateRecType()
        {
            Int32 uBitsRecType = 0;            
            uBitsRecType |= m_chkBlue.Checked       ? VzClientSDK.VZ_LPRC_REC_BLUE : 0;
            uBitsRecType |= m_chkYellow.Checked     ? VzClientSDK.VZ_LPRC_REC_YELLOW : 0;
            uBitsRecType |= m_chkBlack.Checked      ? VzClientSDK.VZ_LPRC_REC_BLACK : 0;
            uBitsRecType |= m_chkCoach.Checked      ? VzClientSDK.VZ_LPRC_REC_COACH : 0;
            uBitsRecType |= m_chkTablets.Checked    ? VzClientSDK.VZ_LPRC_REC_POLICE : 0;
            uBitsRecType |= m_chkArm.Checked        ? VzClientSDK.VZ_LPRC_REC_AMPOL : 0;
            uBitsRecType |= m_chkTag.Checked        ? VzClientSDK.VZ_LPRC_REC_ARMY : 0;
            uBitsRecType |= m_chkHK.Checked         ? VzClientSDK.VZ_LPRC_REC_GANGAO : 0;
            uBitsRecType |= m_chkEC.Checked         ? VzClientSDK.VZ_LPRC_REC_EMBASSY : 0;
            uBitsRecType |= m_chkAviation.Checked   ? VzClientSDK.VZ_LPRC_REC_AVIATION : 0;
            uBitsRecType |= m_chkEnergy.Checked     ? VzClientSDK.VZ_LPRC_REC_ENERGY : 0;
            uBitsRecType |= m_chkNoPlate.Checked    ? VzClientSDK.VZ_LPRC_REC_NO_PLATE : 0;
            int nRet = VzClientSDK.VzLPRClient_SetPlateRecType(m_hLPRClient, (UInt32)uBitsRecType);
            bool bFuncRet = true;
            if (nRet != 0)
            {
                MessageBox.Show("设置识别类型失败！");
                bFuncRet = false;
            }
            return bFuncRet;
        }
        //获取车牌识别类型
        private void getTrigType()
        {
            int uBitsTrigType = 0;           
            VzClientSDK.VzLPRClient_GetPlateTrigType(m_hLPRClient, ref uBitsTrigType);
            m_chkStableTri.Checked = Convert.ToBoolean((int)uBitsTrigType & VzClientSDK.VZ_LPRC_TRIG_ENABLE_STABLE);
            m_chkVirtualTri.Checked = Convert.ToBoolean((int)uBitsTrigType & VzClientSDK.VZ_LPRC_TRIG_ENABLE_VLOOP);
            m_chkIO1.Checked = Convert.ToBoolean((int)uBitsTrigType & VzClientSDK.VZ_LPRC_TRIG_ENABLE_IO_IN1);
            m_chkIO2.Checked = Convert.ToBoolean((int)uBitsTrigType & VzClientSDK.VZ_LPRC_TRIG_ENABLE_IO_IN2);
            m_chkIO3.Checked = Convert.ToBoolean((int)uBitsTrigType & VzClientSDK.VZ_LPRC_TRIG_ENABLE_IO_IN3);            
        }
        //设置车牌识别类型
        private bool setTrigType()
        {
            Int32 uBitsTrigType = 0;            
            uBitsTrigType |= m_chkStableTri.Checked  ? VzClientSDK.VZ_LPRC_TRIG_ENABLE_STABLE : 0;
            uBitsTrigType |= m_chkVirtualTri.Checked ? VzClientSDK.VZ_LPRC_TRIG_ENABLE_VLOOP : 0;
            uBitsTrigType |= m_chkIO1.Checked        ? VzClientSDK.VZ_LPRC_TRIG_ENABLE_IO_IN1 : 0;
            uBitsTrigType |= m_chkIO2.Checked        ? VzClientSDK.VZ_LPRC_TRIG_ENABLE_IO_IN2 : 0;
            uBitsTrigType |= m_chkIO3.Checked        ? VzClientSDK.VZ_LPRC_TRIG_ENABLE_IO_IN3 : 0;
            int nRet = VzClientSDK.VzLPRClient_SetPlateTrigType(m_hLPRClient, Convert.ToUInt32(uBitsTrigType));
            bool bFuncRet = true;
            if (nRet != 0)
            {
                MessageBox.Show("设置输出结果失败！");
                bFuncRet = false;
            }
            return bFuncRet;            
        }
        //获取实时显示
        private void getRealTimeResult()
        {
            VzClientSDK.VZ_LPRC_DRAWMODE drawMode = new VzClientSDK.VZ_LPRC_DRAWMODE();
            int nRet = VzClientSDK.VzLPRClient_GetDrawMode(m_hLPRClient, ref drawMode);
            m_chkVirtualAndReco.Checked = Convert.ToBoolean(drawMode.byDspAddRule);
            m_chkResult.Checked         = Convert.ToBoolean(drawMode.byDspAddTarget);
            m_chkPlatePos.Checked       = Convert.ToBoolean(drawMode.byDspAddTrajectory);
        }
        //设置实时显示
        private bool setRealTimeResult()
        {
            VzClientSDK.VZ_LPRC_DRAWMODE drawMode = new VzClientSDK.VZ_LPRC_DRAWMODE();
            drawMode.byDspAddRule       = Convert.ToByte(m_chkVirtualAndReco.Checked);
            drawMode.byDspAddTarget     = Convert.ToByte(m_chkResult.Checked);
            drawMode.byDspAddTrajectory = Convert.ToByte(m_chkPlatePos.Checked);
            int nRet = VzClientSDK.VzLPRClient_SetDrawMode(m_hLPRClient, ref drawMode);
            bool bFuncRet = true;
            if (nRet != 0)
            {
                MessageBox.Show("设置实时显示失败！");
                bFuncRet = false;
            }
            return bFuncRet;
        }

        private void m_btnOK_Click(object sender, EventArgs e)
        {
            bool bRecRet  = setPlateRecType();
            bool bTrigRet = setTrigType();
            bool bRealRet = setRealTimeResult();
            if (bRecRet && bTrigRet && bRealRet)
                MessageBox.Show("设置基本配置成功！");
        }

        private void BaseConfig_From_Load(object sender, EventArgs e)
        {
            getPlateRecType();
            getTrigType();
            getRealTimeResult();
        }
    }
}
