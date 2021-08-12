using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnionBase
{
    public partial class Form1 : Form
    {
        string ActiveFolderPath = String.Empty;
        List<string> listFileInFoler = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            label2.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void CloseProgramm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InfoProgramm_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.Show();
        }

        private void btn_SelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                ActiveFolderPath = FBD.SelectedPath.ToString();
                lbl_countFileFolder.Text = Directory.GetFiles(ActiveFolderPath).Length.ToString();

            }
        }
        public string getFileExtension(string fileName)
        {
            return fileName.Substring(fileName.LastIndexOf(".") + 1);
        }

        private void btn_LoadFile_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in Directory.GetFiles(ActiveFolderPath))
                {
                    listFileInFoler.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
