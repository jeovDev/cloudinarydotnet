using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using MySql.Data.MySqlClient;
namespace CLOUDINARYDOTNET
{
    public partial class Form1 : Form
    {

        public Cloudinary cloudinary;
        public const string CLOUD_NAME = "jeovdev";
        public const string API_KEY = "751447631666916";
        public const string API_SECRET = "UYu65tHoC872hEB_Kg_OnS7ArA0";
        public string imagePath,publicid,link;
        public string connstring = "server=localhost;user id=root;password=admin;database=cloudinary;sslmode=none";
        public Form1()
        {
            InitializeComponent();
            getTheme(); //theme
        }
        #region UI
        private System.Drawing.Point _mouseLoc;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int dx = e.Location.X - _mouseLoc.X;
                int dy = e.Location.Y - _mouseLoc.Y;
                this.Location = new System.Drawing.Point(this.Location.X + dx, this.Location.Y + dy);

            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            int dx = e.Location.X - _mouseLoc.X;

        }
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Minimized;
        }

        private void maximize_Click(object sender, EventArgs e)
        {

            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
        }
        bool isDarkmode = false;
        private void mode_Click(object sender, EventArgs e)
        {
            Theme set = new Theme();
            if (isDarkmode == true)
            {

                set.writeIni("SECTION", "key", "dark");
                label1.Text = "DARK";
                this.BackColor = Color.FromArgb(36, 36, 36);
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                image.BackColor = Color.FromArgb(51, 51, 51);
                panel2.BackColor = Color.FromArgb(51, 51, 51);
                mode.BackColor = Color.FromArgb(36, 36, 36);

                isDarkmode = false;
                mode.Image = mode.InitialImage;

                fb.BackColor = Color.FromArgb(51, 51, 51);
                tk.BackColor = Color.FromArgb(51, 51, 51);
                ig.BackColor = Color.FromArgb(51, 51, 51);
                yt.BackColor = Color.FromArgb(51, 51, 51);
                minimize.BackColor = Color.FromArgb(51, 51, 51);
                maximize.BackColor = Color.FromArgb(51, 51, 51);

                minimize.Image = minimize.InitialImage;
                maximize.Image = maximize.InitialImage;


                dataGridView1.BackgroundColor = Color.FromArgb(51, 51, 51);

                foreach (DataGridViewRow row in dataGridView1.Rows)

                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(36, 36, 36);
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 51, 51);
                }
            }
            else
            {

                set.writeIni("SECTION", "key", "light");
                label1.Text = "LIGHT";
                this.BackColor = Color.White;
                label1.ForeColor = Color.FromArgb(36, 36, 36);
                label2.ForeColor = Color.FromArgb(36, 36, 36);
                mode.BackColor = Color.White;
                image.BackColor = Color.FromArgb(240, 240, 240);
                panel2.BackColor = Color.FromArgb(240, 240, 240);
                isDarkmode = true;
                mode.Image = mode.ErrorImage;


                fb.BackColor = Color.White;
                tk.BackColor = Color.White;
                ig.BackColor = Color.White;
                yt.BackColor = Color.White;
                minimize.BackColor = Color.FromArgb(240, 240, 240);
                maximize.BackColor = Color.FromArgb(240, 240, 240);
                minimize.Image = minimize.ErrorImage;
                maximize.Image = maximize.ErrorImage;

                dataGridView1.BackgroundColor = Color.FromArgb(240, 240, 240);

                foreach (DataGridViewRow row in dataGridView1.Rows)

                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.DefaultCellStyle.SelectionBackColor = Color.Silver;
                }
            }
        }
        private void getTheme()
        {
            Theme get = new Theme();
            get.readIni();
            if (get.theme.Equals("dark"))
            {


                label1.Text = "DARK";
                this.BackColor = Color.FromArgb(36, 36, 36);
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                image.BackColor = Color.FromArgb(51, 51, 51);
                panel2.BackColor = Color.FromArgb(51, 51, 51);
                mode.BackColor = Color.FromArgb(36, 36, 36);

                isDarkmode = false;
                mode.Image = mode.InitialImage;

                fb.BackColor = Color.FromArgb(51, 51, 51);
                tk.BackColor = Color.FromArgb(51, 51, 51);
                ig.BackColor = Color.FromArgb(51, 51, 51);
                yt.BackColor = Color.FromArgb(51, 51, 51);
                minimize.BackColor = Color.FromArgb(51, 51, 51);
                maximize.BackColor = Color.FromArgb(51, 51, 51);

                minimize.Image = minimize.InitialImage;
                maximize.Image = maximize.InitialImage;


                dataGridView1.BackgroundColor = Color.FromArgb(51, 51, 51);

                foreach (DataGridViewRow row in dataGridView1.Rows)

                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(36, 36, 36);
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 51, 51);
                }

            }
            if (get.theme.Equals("light"))
            {

                dataGridView1.BackgroundColor = Color.FromArgb(240, 240, 240);

                foreach (DataGridViewRow row in dataGridView1.Rows)

                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.DefaultCellStyle.SelectionBackColor = Color.Silver;
                }

                label1.Text = "LIGHT";
                this.BackColor = Color.White;
                label1.ForeColor = Color.FromArgb(36, 36, 36);
                label2.ForeColor = Color.FromArgb(36, 36, 36);
                mode.BackColor = Color.White;
                image.BackColor = Color.FromArgb(240, 240, 240);
                panel2.BackColor = Color.FromArgb(240, 240, 240);
                isDarkmode = true;
                mode.Image = mode.ErrorImage;


                fb.BackColor = Color.White;
                tk.BackColor = Color.White;
                ig.BackColor = Color.White;
                yt.BackColor = Color.White;
                minimize.BackColor = Color.FromArgb(240, 240, 240);
                maximize.BackColor = Color.FromArgb(240, 240, 240);
                minimize.Image = minimize.ErrorImage;
                maximize.Image = maximize.ErrorImage;


            }
        }















        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            displayDatagrid();
        }
        private void displayDatagrid() {
            MySqlConnection conn = new MySqlConnection(connstring);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand(); 
            cmd.CommandText = "SELECT publicid,link FROM cloudinarytbl";
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.Dispose();
            conn.Close();
        }
        private void save() {
            MySqlConnection conn = new MySqlConnection(connstring);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO cloudinarytbl(publicid,link)VALUES('" + publicid + "','" +link +"')";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }
        private void cloudinaryStorage() {
            Account account = new Account(CLOUD_NAME,API_KEY,API_SECRET);
            cloudinary = new Cloudinary(account);
            uploadImage(imagePath);
        }
        private void uploadImage(string path) {
            var uploadParams = new ImageUploadParams() { 
            File = new FileDescription(path),
            };
            var res = cloudinary.Upload(uploadParams);
            publicid = res.PublicId.ToString();
            link = res.Uri.ToString();
        }
        private void btnchoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image | *.jpg;*.jpeg;*.png";
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK) {
                image.Image = new Bitmap(dlg.FileName);
                imagePath = dlg.FileName;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            cloudinaryStorage();
        }
        public static string linkHolder, publicIDHolder;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                linkHolder = row.Cells["link"].Value.ToString();
                publicIDHolder = row.Cells["publicid"].Value.ToString();

                Form2 fr = new Form2();
                fr.Show();
            
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            save();
            displayDatagrid();
            MessageBox.Show("Complete");
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
