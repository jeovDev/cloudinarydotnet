using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace CLOUDINARYDOTNET
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            getIni(); //theme
        }

        #region
        private void getIni()
        {
            Theme get = new Theme();
            get.readIni();
            if (get.theme == "dark")
            {


                this.BackColor = Color.FromArgb(36, 36, 36);
                image.BackColor = Color.FromArgb(51, 51, 51);



            }
            else
            {


                this.BackColor = Color.White;
                image.BackColor = Color.FromArgb(240, 240, 240);



            }
        }
        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
        private void Form2_Load(object sender, EventArgs e)
        {
            image.ImageLocation = Form1.linkHolder;

        }
        private void downloadFile(string downloadlink,string targetPath) {

            Stream remoteStream = null;
            Stream localStream = null;
            WebResponse response = null;
            WebRequest request = WebRequest.Create(downloadlink);
            if (request != null) {
                double TotalBytesToReceive = 0;
                var SizewebRequest = HttpWebRequest.Create(new Uri(downloadlink));
                SizewebRequest.Method = "HEAD";

                response = request.GetResponse();
                if (response != null) {
                    remoteStream = response.GetResponseStream();
                    String filepath = targetPath;
                    localStream = File.Create(filepath);
                    byte[] buffer = new byte[1024];
                    int bytesRead = 0;
                    do {
                        bytesRead = remoteStream.Read(buffer, 0, buffer.Length);
                        localStream.Write(buffer, 0, bytesRead);
                    } while (bytesRead > 0);
                }
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            downloadFile(downloadImagelink, @"C:\Users\smsi\Downloads\dl\" + Form1.publicIDHolder + ".jpg");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Download Complete");
        }
        string downloadImagelink;
        private void btnDownload_Click(object sender, EventArgs e)
        {
            downloadImagelink = Form1.linkHolder.Insert(47,"fl_attachment/");
             backgroundWorker1.RunWorkerAsync();
          //  MessageBox.Show(downloadImagelink);
        }
    }
}
