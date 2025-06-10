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

namespace WindowsFormsFirstDay.CoursesPL
{
    public partial class Profile : Form
    {
        private int _userID;

        public Profile()
        {
            InitializeComponent();
        }
        public Profile(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }
        async private void Profile_Load(object sender, EventArgs e)
        {
            await Task.Run(() => LoadProfileData());

            /*            DataTable profile = CoursesBL.CoursesBL.DisplayProfile(_userID);


            if (profile.Rows.Count > 0)
            {
                DataRow row = profile.Rows[0];
                tbProfileID.Text = row["ProfileID"].ToString();
                tbFullName.Text = row["FullName"].ToString();
                tbEmail.Text = row["Email"].ToString();
                tbPhone.Text = row["Phone"].ToString();

                // Load image from varbinary
                if (row["ProfileImage"] != DBNull.Value)
                {
                    byte[] imgBytes = (byte[])row["ProfileImage"];
                    using (MemoryStream ms = new MemoryStream(imgBytes))
                    {
                        pictureBox.Image = Image.FromStream(ms);
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
            else
            {
                MessageBox.Show("No profile data found.");
            }
        }*/
        }
        private void LoadProfileData()
        {
            DataTable profile = CoursesBL.CoursesBL.DisplayProfile(_userID);
            if (profile.Rows.Count > 0)
            {
                DataRow row = profile.Rows[0];

                this.Invoke((MethodInvoker)delegate
                {
                    tbProfileID.Text = row["ProfileID"].ToString();
                    tbFullName.Text = row["FullName"].ToString();
                    tbEmail.Text = row["Email"].ToString();
                    tbPhone.Text = row["Phone"].ToString();

                    if (row["ProfileImage"] != DBNull.Value)
                    {
                        byte[] imageData = (byte[])row["ProfileImage"];
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            pictureBox.Image = Image.FromStream(ms);
                            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                });
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
