using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ForgeUIQueue
{
    public partial class CfrmHistory : Form
    {
        ContextMenuStrip _cms;

        public CfrmHistory()
        {
            InitializeComponent();

            Prepare();
        }

        void Prepare()
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dgvQueue, new object[] { true });

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
            _cms.Items.Add("-");
            _cms.Items.Add("Delete", null, Cms_Delete);

            Display();
        }

        void Display()
        {
            dgvQueue.Rows.Clear();

            for (int i = 0; i < Info._settings.HistoricalPayloads.Count; i++)
            {
                var payload = Info._settings.HistoricalPayloads[i];
                dgvQueue.Rows.Add(new string[] { payload.Prompt, payload.Width.ToString(), payload.Height.ToString(), payload.Steps.ToString() });
            }
        }

        void Delete()
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                return;
            }

            List<int> selectedRowIndexes = new List<int>();
            foreach (DataGridViewRow row in dgvQueue.SelectedRows)
            {
                selectedRowIndexes.Add(row.Index);
            }

            selectedRowIndexes.Sort();
            selectedRowIndexes.Reverse();

            for (int i = 0; i < selectedRowIndexes.Count; i++)
            {
                Info._settings.HistoricalPayloads.RemoveAt(selectedRowIndexes[i]);
                dgvQueue.Rows.RemoveAt(selectedRowIndexes[i]);
            }

            Info.SaveSettings();
        }

        private void DgvQueue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Delete();
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

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear history?", "ForgeUI Queue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dgvQueue.SelectAll();
                Delete();
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Cms_Copy_All(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count != 1)
            {
                return;
            }

            DataGridViewRow row = dgvQueue.SelectedRows[0];
            string prompt = row.Cells[0].Value.ToString();
            int width = int.Parse(row.Cells[1].Value.ToString());
            int height = int.Parse(row.Cells[2].Value.ToString());
            int steps = int.Parse(row.Cells[3].Value.ToString());
            Info._main.ApplyConfig(prompt, width, height, steps);
        }

        private void Cms_Copy_Settings(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count != 1)
            {
                return;
            }

            DataGridViewRow row = dgvQueue.SelectedRows[0];
            int width = int.Parse(row.Cells[1].Value.ToString());
            int height = int.Parse(row.Cells[2].Value.ToString());
            int steps = int.Parse(row.Cells[3].Value.ToString());
            Info._main.ApplyConfig(width: width, height: height, steps: steps);
        }

        private void Cms_Copy_Prompt(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count != 1)
            {
                return;
            }

            DataGridViewRow row = dgvQueue.SelectedRows[0];
            string prompt = row.Cells[0].Value.ToString();
            Info._main.ApplyConfig(prompt);
        }

        private void Cms_Copy_WidthHeight(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count != 1)
            {
                return;
            }

            DataGridViewRow row = dgvQueue.SelectedRows[0];
            int width = int.Parse(row.Cells[1].Value.ToString());
            int height = int.Parse(row.Cells[2].Value.ToString());
            Info._main.ApplyConfig(width: width, height: height);
        }

        private void Cms_Copy_Width(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count != 1)
            {
                return;
            }

            DataGridViewRow row = dgvQueue.SelectedRows[0];
            int width = int.Parse(row.Cells[1].Value.ToString());
            Info._main.ApplyConfig(width: width);
        }

        private void Cms_Copy_Height(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count != 1)
            {
                return;
            }

            DataGridViewRow row = dgvQueue.SelectedRows[0];
            int height = int.Parse(row.Cells[2].Value.ToString());
            Info._main.ApplyConfig(height: height);
        }

        private void Cms_Copy_Steps(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count != 1)
            {
                return;
            }

            DataGridViewRow row = dgvQueue.SelectedRows[0];
            int steps = int.Parse(row.Cells[3].Value.ToString());
            Info._main.ApplyConfig(steps: steps);
        }

        private void Cms_Delete(object sender, EventArgs e)
        {
            Delete();
        }
    }
}
