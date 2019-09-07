using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FineUICoder
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            rtbRazor.AllowDrop = true;
            rtbRazor.DragEnter += RtbRazor_DragEnter;
            rtbRazor.DragDrop += RtbRazor_DragDrop;
        }

        private void RtbRazor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void RtbRazor_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length > 0)
            {
                if (Path.GetExtension(files[0]) == ".cshtml")  //只接受cshtml文件
                {
                    LoadFile(files[0]);
                }
            }
        }

        private void BtFormat_Click(object sender, EventArgs e)
        {
            string[] ss= new FineUI_cshtml().Format(rtbRazor.Lines);
            rtbRazor.Lines = ss;
        }

        private void BtOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { InitialDirectory = Application.StartupPath, Filter = "cshtml文件(*.cshtml)|*.cshtml", Multiselect = false };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadFile(ofd.FileName);
            }
        }
        
        void LoadFile(string filename)
        {
            if (!File.Exists(filename))
                return;
            if (Path.GetExtension(filename).ToUpper() != ".CSHTML")
                return;

            rtbRazor.Text = File.ReadAllText(filename);
            Application.DoEvents();
            if (cbAutoSaveFile.Checked)
            {
                BtFormat_Click(null, null);
                Application.DoEvents();

                File.WriteAllText(filename, rtbRazor.Text, Encoding.UTF8);
                Application.DoEvents();
            }
        }
    }
}
