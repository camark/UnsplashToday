using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace UnsplashToday
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private int scr_height;
        private int scr_width;

        private string url = "https://source.unsplash.com/{0}x{1}/?nature,water";
        private void Form1_Load(object sender, EventArgs e)
        {
            scr_height = Screen.PrimaryScreen.Bounds.Height;
            scr_width = Screen.PrimaryScreen.Bounds.Width;

            nud_height.Value = scr_height;
            nud_width.Value = scr_width;
        }

        private void DownloadAndSetWallper()
        {
            try
            {
                var webClient = new WebClient();

                var str_guid = Guid.NewGuid().ToString();

                var save_file_name = str_guid + ".jpg";

                var img_dir = DirUtil.getBasePath() + @"img\";

                if (!Directory.Exists(img_dir))
                {
                    Directory.CreateDirectory(img_dir);
                }

                var dest_url = String.Format(url, scr_width, scr_height);

                webClient.DownloadFile(dest_url, img_dir + save_file_name);

                Image jpgImage = Image.FromFile(img_dir + save_file_name);

                var dest_bmp_file = img_dir + str_guid + ".bmp";

                jpgImage.Save(dest_bmp_file, System.Drawing.Imaging.ImageFormat.Bmp);

                new WallperUtil().setWallper(dest_bmp_file);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DownloadAndSetWallper();
        }
    }
}
