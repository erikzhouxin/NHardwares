using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Cobber;
using System.Data.ShenBanReader;
using System.Drawing;
using System.IO.Ports;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ShenBanReader.WinForm.Views
{
    public partial class AutoReaderFlew : UserControl
    {
        private int _readId;
        private bool _isAuto;
        IR600Reader _reader;

        public AutoReaderFlew()
        {
            InitializeComponent();
        }

        private void BtnConnection_Click(object sender, EventArgs e)
        {
            MessageBox.Show("根据危险请求条例来说，暂时不允许此次操作！", "危险警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //return;
            var com = this.CbxSerialPort.Text;
            var rate = this.CbxPortRate.Text.ToPInt32();
            if (com.StartsWith("COM"))
            {
                if (_reader.Connect(com, rate, out string exception))
                {
                    AppendSuccess(exception);
                }
                else
                {
                    AppendError(exception);
                }
            }
            else
            {
                IPAddress.TryParse(com, out IPAddress address);
                if (_reader.Connect(address, rate, out string exception))
                {
                    AppendSuccess(exception);
                }
                else
                {
                    AppendError(exception);
                }
            }
            _reader.SetAutoRead(_isAuto = !_isAuto);
        }

        private void AutoReaderForm_Load(object sender, EventArgs e)
        {
            _reader ??= ReaderBuilder.GetR600Reader(new R600CallAction
            {
                ReceiveCallback = ReceiveCallback,
                SendCallback = SendCallback,
                AlertCallbackError = AlertCallbackError,
                AlertError = AlertError,
                FastSwitchInventory = InventoryReal,
                FastSwitchInventoryEnd = InventoryRealEnd,
                InventoryReal = InventoryReal,
                InventoryRealEnd = InventoryRealEnd,
                SetWorkAntenna = SetWorkAntenna
            });
            if (_tagTable.Columns.Count == 0)
            {
                _tagTable.Columns.Add(new DataColumn("Epc"));
                _tagTable.Columns.Add(new DataColumn("Text"));
                _tagTable.Columns.Add(new DataColumn("Result"));
                this.DgvReadResult.DataSource = _tagTable;
            }
            BtnRefreshPort_Click(sender, e);
        }
        private void InventoryRealEnd(IReadMessage msg, int arg2, int arg3)
        {
            _readId = msg.ReadId;
        }

        private void AlertError(ReadAlertError alert)
        {
            this.Invoke((Action)(() =>
            {
                AppendError(alert.Message).AppendError(alert.GetJsonString());
            }));
        }
        private void AlertCallbackError(Exception ex)
        {
            this.Invoke((Action)(() =>
            {
                Append(ex);
            }));
        }
        private void ReceiveCallback(byte[] aryData)
        {

        }
        private void SendCallback(byte[] aryData)
        {
            this.Invoke((Action)(() =>
            {
                AppendSuccess(aryData.GetHexString());
            }));
        }
        private void SetWorkAntenna(IReadMessage obj)
        {
            _readId = obj.ReadId;
        }
        HashSet<string> _tags = new HashSet<string>();
        DataTable _tagTable = new DataTable();
        private void InventoryReal(IReadMessage msg, R600TagInfo tag)
        {
            _readId = msg.ReadId;
            this.Invoke((Action)(() =>
            {
                if (!_tags.Contains(tag.Key))
                {
                    _tags.Add(tag.Key);
                    var row = _tagTable.NewRow();
                    row[0] = tag.Key;
                    row[1] = tag.EPC.GetHexString();
                    row[2] = tag.GetJsonString();
                    _tagTable.Rows.Add(row);
                }
            }));
        }

        public void AppendTextEx(string strText, Color clAppend)
        {
            int nLen = this.TxtLogger.TextLength;

            if (nLen != 0)
            {
                TxtLogger.AppendText(Environment.NewLine + System.DateTime.Now.ToString() + " " + strText);
            }
            else
            {
                TxtLogger.AppendText(System.DateTime.Now.ToString() + " " + strText);
            }

            TxtLogger.Select(nLen, this.TxtLogger.TextLength - nLen);
            this.TxtLogger.SelectionColor = clAppend;
        }
        public AutoReaderFlew AppendError(string message)
        {
            AppendTextEx(message, Color.Red);
            return this;
        }
        public AutoReaderFlew AppendSuccess(string message)
        {
            AppendTextEx(message, Color.Green);
            return this;
        }
        public AutoReaderFlew AppendInfo(string message)
        {
            AppendTextEx(message, Color.Blue);
            return this;
        }
        public AutoReaderFlew Append(IAlertMsg alert)
        {
            if (alert.IsSuccess)
            {
                AppendTextEx(alert.Message, Color.Green);
            }
            else
            {
                AppendTextEx(alert.Message, Color.Red);
            }
            return this;
        }
        public AutoReaderFlew Append(Exception alert)
        {
            var sb = new StringBuilder().AppendLine(alert.Message).AppendLine(alert.StackTrace);
            AppendTextEx(sb.ToString(), Color.Red);
            return this;
        }

        private void TxtLogger_TextChanged(object sender, EventArgs e)
        {
            TxtLogger.Select(TxtLogger.TextLength, 0);
            TxtLogger.ScrollToCaret();
        }

        private void BtnRefreshPort_Click(object sender, EventArgs e)
        {
            this.CbxSerialPort.Items.Clear();
            var ports = SerialPort.GetPortNames();
            foreach (var item in ports)
            {
                this.CbxSerialPort.Items.Add(item);
            }
            if (string.IsNullOrEmpty(this.CbxSerialPort.Text))
            {
                if (this.CbxSerialPort.Items.Count > 0)
                {
                    this.CbxSerialPort.SelectedIndex = 0;
                }
            }
        }
    }
}
