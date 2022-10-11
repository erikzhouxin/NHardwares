using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Cobber;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System.Data.ShenBanReader.WinForm
{
    public partial class AutoReaderForm : Form
    {
        private int _readId;
        private bool _isAuto;
        /// <summary>
        /// 读写器
        /// </summary>
        IR600Reader _reader;

        public AutoReaderForm()
        {
            InitializeComponent();
        }

        private void BtnConnection_Click(object sender, EventArgs e)
        {
            var com = this.CbxSerialPort.Text;
            var rate = this.CbxPortRate.Text.ToPInt32();
            if (_reader.Connect(com, rate, out string exception))
            {
                this.TxtLogArea.AppendSuccess(exception);
            }
            else
            {
                this.TxtLogArea.AppendError(exception);
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
        }
        private void InventoryRealEnd(IReadMessage msg, int arg2, int arg3)
        {
            _readId = msg.ReadId;
        }

        private void AlertError(ReadAlertError alert)
        {
            this.Invoke((Action)(() =>
            {
                TxtLogArea.AppendError(alert.Message).AppendError(alert.GetJsonString());
            }));
        }
        private void AlertCallbackError(Exception ex)
        {
            this.Invoke((Action)(() =>
            {
                TxtLogArea.Append(ex);
            }));
        }
        private void ReceiveCallback(byte[] aryData)
        {

        }
        private void SendCallback(byte[] aryData)
        {
            this.Invoke((Action)(() =>
            {
                TxtLogArea.AppendSuccess(aryData.GetHexString());
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
    }
}
