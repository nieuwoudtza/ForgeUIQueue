using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ForgeUIQueue
{
    public partial class CfrmMain : Form
    {
        // TODO:
        // Total Images
        // Total Prompts
        // Average time
        // Current item ETA

        CfrmHistory history;

        ForgeUI _forgeUI;

        ContextMenuStrip _cms;

        public CfrmMain()
        {
            InitializeComponent();

            Prepare();
        }

        void Prepare()
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dgvQueue, new object[] { true });

            Info._main = this;
            Info.LoadSettings();

            txtPath.Text = Info._settings.OutputDirectory;
            _forgeUI = new ForgeUI();

            _cms = new ContextMenuStrip();
            _cms.Items.Add("Copy");
            var itemCopy = (ToolStripMenuItem)_cms.Items[_cms.Items.Count - 1];
            itemCopy.DropDownItems.Add("All", null, Cms_Copy_All);
            itemCopy.DropDownItems.Add("Settings", null, Cms_Copy_Settings);
            itemCopy.DropDownItems.Add("Prompt", null, Cms_Copy_Prompt);
            itemCopy.DropDownItems.Add("Width && Height", null, Cms_Copy_WidthHeight);
            itemCopy.DropDownItems.Add("Width", null, Cms_Copy_Width);
            itemCopy.DropDownItems.Add("Height", null, Cms_Copy_Height);
            itemCopy.DropDownItems.Add("Steps", null, Cms_Copy_Steps);
            itemCopy.DropDownItems.Add("Count", null, Cms_Copy_Count);
            _cms.Items.Add("-");
            _cms.Items.Add("Up", null, Cms_Up);
            _cms.Items.Add("Down", null, Cms_Down);
            _cms.Items.Add("-");
            _cms.Items.Add("Delete", null, Cms_Delete);

            LoadPayloads();
        }

        public void UpdateText(string text = null)
        {
            if (!string.IsNullOrEmpty(text))
            {
                Text = "";
            }
            else
            {

            }
        }

        void LoadPayloads()
        {
//#if DEBUG
//            Info._paused = true;
//#endif

            if (Info._settings.Payloads.Count != 0)
            {
                Info._paused = true;
            }

            foreach (var payload in Info._settings.Payloads)
            {
                int id = _forgeUI.AddPayload(payload);
                dgvQueue.Rows.Add(new string[] { id.ToString(), payload.Prompt, payload.Width.ToString(), payload.Height.ToString(), payload.Steps.ToString(), payload.Count.ToString() });
            }
        }

        public void UpdatePayload(Payload payload)
        {
            for (int i = 0; i < dgvQueue.RowCount; i++)
            {
                var row = dgvQueue.Rows[i];
                string id = payload.ID.ToString();
                if (row.Cells[0].Value.ToString() == id)
                {
                    if (payload.Count != 0)
                    {
                        row.Cells[1].Value = payload.Prompt;
                        row.Cells[2].Value = payload.Width;
                        row.Cells[3].Value = payload.Height;
                        row.Cells[4].Value = payload.Steps;
                        row.Cells[5].Value = payload.Count;
                    }
                    else
                    {
                        dgvQueue.Rows.RemoveAt(i);
                    }
                }
            }
        }

        public void ApplyConfig(string prompt = null, int? width = null, int? height = null, int? steps = null)
        {
            if (prompt != null)
            {
                txtPrompts.Text = prompt;
                txtPrompts.SelectionStart = txtPrompts.TextLength;
            }
            if (width != null)
            {
                numWidth.Value = width.Value;
            }
            if (height != null)
            {
                numHeight.Value = height.Value;
            }
            if (steps != null)
            {
                numSteps.Value = steps.Value;
            }
        }

        void Delete()
        {
            List<int> ids = new List<int>();
            for (int i = 0; i < dgvQueue.SelectedRows.Count; i++)
            {
                int id = int.Parse(dgvQueue.SelectedRows[i].Cells[0].Value.ToString());
                ids.Add(id);
            }

            foreach (int id in ids)
            {
                _forgeUI.DeletePayload(id);
            }
        }

        void Up()
        {
            // Check that there is at least one row selected.
            if (dgvQueue.SelectedRows.Count == 0)
                return;

            // If any selected row is already at the top, we cannot move up.
            if (dgvQueue.SelectedRows.Cast<DataGridViewRow>().Any(r => r.Index == 0))
                return;

            // Process the selected rows in ascending order.
            var selectedRows = dgvQueue.SelectedRows.Cast<DataGridViewRow>()
                                    .OrderBy(r => r.Index)
                                    .ToList();

            List<DataGridViewRow> rowsToSelect = new List<DataGridViewRow>(selectedRows);
            foreach (DataGridViewRow row in selectedRows)
            {
                int id = int.Parse(row.Cells[0].Value.ToString());
                _forgeUI.PayloadUp(id);

                int currentIndex = row.Index;
                // Remove the row from its current position.
                dgvQueue.Rows.RemoveAt(currentIndex);
                // Insert the row one position up.
                dgvQueue.Rows.Insert(currentIndex - 1, row);
            }

            dgvQueue.ClearSelection();
            foreach (DataGridViewRow row in rowsToSelect)
            {
                row.Selected = true;
            }
        }

        void Down()
        {
            // Check that there is at least one row selected.
            if (dgvQueue.SelectedRows.Count == 0)
                return;

            int lastRowIndex = dgvQueue.Rows.Count - 1;
            // If any selected row is the last row, we cannot move down.
            if (dgvQueue.SelectedRows.Cast<DataGridViewRow>().Any(r => r.Index == lastRowIndex))
                return;

            // Process the selected rows in descending order.
            var selectedRows = dgvQueue.SelectedRows.Cast<DataGridViewRow>()
                                    .OrderByDescending(r => r.Index)
                                    .ToList();

            List<DataGridViewRow> rowsToSelect = new List<DataGridViewRow>(selectedRows);
            foreach (DataGridViewRow row in selectedRows)
            {
                int id = int.Parse(row.Cells[0].Value.ToString());
                _forgeUI.PayloadDown(id);

                int currentIndex = row.Index;
                // Remove the row from its current position.
                dgvQueue.Rows.RemoveAt(currentIndex);
                // Insert the row one position down.
                dgvQueue.Rows.Insert(currentIndex + 1, row);
            }

            dgvQueue.ClearSelection();
            foreach (DataGridViewRow row in rowsToSelect)
            {
                row.Selected = true;
            }
        }

        void ShowHistory()
        {
            if (history != null && !history.IsDisposed)
            {
                history.Close();
            }

            history = new CfrmHistory();
            history.Show(this);
        }

        private void CfrmMain_Shown(object sender, EventArgs e)
        {
            if (Info._paused)
            {
                if (MessageBox.Show("Resume queue?", "ForgeUI Queue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Info._paused = false;
                }
                else
                {
                    picState.Image = Properties.Resources.Resume;
                    toolTip.SetToolTip(picState, "Resume");
                }
            }
        }

        private void CfrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_forgeUI.Running)
            {
                if (MessageBox.Show("Are you sure you want to exit?", "ForgeUI Queue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void BtnQueue_Click(object sender, EventArgs e)
        {
            string[] prompts = txtPrompts.Lines.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            foreach (string prompt in prompts)
            {
                string _prompt = prompt.Trim();
                int width = (int)numWidth.Value;
                int height = (int)numHeight.Value;
                int steps = (int)numSteps.Value;
                int count = (int)numCount.Value;
                int id = _forgeUI.AddPayload(new Payload(_prompt, width, height, steps, count));
                dgvQueue.Rows.Add(new string[] { id.ToString(), _prompt, width.ToString(), height.ToString(), steps.ToString(), count.ToString() });
            }

            txtPrompts.Clear();
            txtPrompts.Focus();
        }

        private void LblPrompts_Click(object sender, EventArgs e)
        {
            ShowHistory();
        }

        private void TxtPath_Leave(object sender, EventArgs e)
        {
            try
            {
                Path.GetFullPath(txtPath.Text);
                Info._settings.OutputDirectory = txtPath.Text;
                Info.SaveSettings();
            }
            catch
            {
                txtPath.Text = Info._settings.OutputDirectory;
            }
        }

        private void DgvQueue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Delete();
            }
            else if (e.Control && e.KeyCode == Keys.NumPad8)
            {
                Up();
            }
            else if (e.Control && e.KeyCode == Keys.NumPad2)
            {
                Down();
            }
            else if (e.Control && e.KeyCode == Keys.H)
            {
                ShowHistory();
            }
        }

        private void DgvQueue_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo hittest = dgvQueue.HitTest(e.X, e.Y);
                if (hittest.RowIndex == -1)
                {
                    dgvQueue.CurrentCell = null;
                    dgvQueue.ClearSelection();
                }
            }
        }

        private void DgvQueue_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hittest = dgvQueue.HitTest(e.X, e.Y);
                if (hittest.RowIndex != -1 && dgvQueue.Rows[hittest.RowIndex].Selected == false)
                {
                    for (int i = 0; i < dgvQueue.Rows.Count; i++)
                    {
                        dgvQueue.Rows[i].Selected = false;
                    }

                    if (hittest.RowIndex != -1)
                    {
                        dgvQueue.CurrentCell = null;
                        dgvQueue.Rows[hittest.RowIndex].Selected = true;
                    }
                }
                else if (hittest.RowIndex == -1)
                {
                    dgvQueue.CurrentCell = null;
                    dgvQueue.ClearSelection();
                }

                if (dgvQueue.SelectedRows.Count != 0)
                {
                    _cms.Items[0].Visible = _cms.Items[1].Visible = dgvQueue.SelectedRows.Count == 1;
                    _cms.Show(Cursor.Position);
                }
            }
        }

        private void DgvQueue_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dgvQueue.Rows[e.RowIndex].Cells[0].Value.ToString());
            switch (e.ColumnIndex)
            {
                case 1:
                    if (dgvQueue.Rows[e.RowIndex].Cells[1].Value != null)
                    {
                        _forgeUI.UpdatePayload(id, prompt: dgvQueue.Rows[e.RowIndex].Cells[1].Value.ToString());
                    }
                    break;
                case 2:
                    if (int.TryParse(dgvQueue.Rows[e.RowIndex].Cells[2].Value.ToString(), out int _width))
                    {
                        _forgeUI.UpdatePayload(id, width: _width);
                    }
                    break;
                case 3:
                    if (int.TryParse(dgvQueue.Rows[e.RowIndex].Cells[3].Value.ToString(), out int _height))
                    {
                        _forgeUI.UpdatePayload(id, height: _height);
                    }
                    break;
                case 4:
                    if (int.TryParse(dgvQueue.Rows[e.RowIndex].Cells[4].Value.ToString(), out int _steps))
                    {
                        _forgeUI.UpdatePayload(id, steps: _steps);
                    }
                    break;
                case 5:
                    if (int.TryParse(dgvQueue.Rows[e.RowIndex].Cells[5].Value.ToString(), out int _count))
                    {
                        _forgeUI.UpdatePayload(id, count: _count);
                    }
                    break;
            }
            _forgeUI.UpdatePayload(id);
        }

        private void PicState_Click(object sender, EventArgs e)
        {
            Info._paused = !Info._paused;
            if (Info._paused)
            {
                picState.Image = Properties.Resources.Resume;
                toolTip.SetToolTip(picState, "Resume");
            }
            else
            {
                picState.Image = Properties.Resources.Pause;
                toolTip.SetToolTip(picState, "Pause");
            }
        }

        private void PicSkip_Click(object sender, EventArgs e)
        {
            _forgeUI.SkipCurrentGeneration();
        }

        private void PicWeb_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://localhost:" + Info._settings.Port);
            }
            catch { }
        }

        private void Cms_Copy_All(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                return;
            }

            var payload = _forgeUI.GetPayload(int.Parse(dgvQueue.SelectedRows[0].Cells[0].Value.ToString()));
            txtPrompts.Text = payload.Prompt;
            txtPrompts.SelectionStart = txtPrompts.TextLength;
            numWidth.Value = payload.Width;
            numHeight.Value = payload.Height;
            numSteps.Value = payload.Steps;
            numCount.Value = payload.Count;
        }

        private void Cms_Copy_Settings(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                return;
            }

            var payload = _forgeUI.GetPayload(int.Parse(dgvQueue.SelectedRows[0].Cells[0].Value.ToString()));
            txtPrompts.Text = payload.Prompt;
            txtPrompts.SelectionStart = txtPrompts.TextLength;
            numWidth.Value = payload.Width;
            numHeight.Value = payload.Height;
            numSteps.Value = payload.Steps;
            numCount.Value = payload.Count;
        }

        private void Cms_Copy_Prompt(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                return;
            }

            var payload = _forgeUI.GetPayload(int.Parse(dgvQueue.SelectedRows[0].Cells[0].Value.ToString()));
            txtPrompts.Text = payload.Prompt;
            txtPrompts.SelectionStart = txtPrompts.TextLength;
        }

        private void Cms_Copy_WidthHeight(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                return;
            }

            var payload = _forgeUI.GetPayload(int.Parse(dgvQueue.SelectedRows[0].Cells[0].Value.ToString()));
            numWidth.Value = payload.Width;
            numHeight.Value = payload.Height;
        }

        private void Cms_Copy_Width(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                return;
            }

            var payload = _forgeUI.GetPayload(int.Parse(dgvQueue.SelectedRows[0].Cells[0].Value.ToString()));
            numWidth.Value = payload.Width;
        }

        private void Cms_Copy_Height(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                return;
            }

            var payload = _forgeUI.GetPayload(int.Parse(dgvQueue.SelectedRows[0].Cells[0].Value.ToString()));
            numHeight.Value = payload.Height;
        }

        private void Cms_Copy_Steps(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                return;
            }

            var payload = _forgeUI.GetPayload(int.Parse(dgvQueue.SelectedRows[0].Cells[0].Value.ToString()));
            numSteps.Value = payload.Steps;
        }

        private void Cms_Copy_Count(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                return;
            }

            var payload = _forgeUI.GetPayload(int.Parse(dgvQueue.SelectedRows[0].Cells[0].Value.ToString()));
            numCount.Value = payload.Count;
        }

        private void Cms_Up(object sender, EventArgs e)
        {
            Up();
        }

        private void Cms_Down(object sender, EventArgs e)
        {
            Down();
        }

        private void Cms_Delete(object sender, EventArgs e)
        {
            Delete();
        }
    }
}
