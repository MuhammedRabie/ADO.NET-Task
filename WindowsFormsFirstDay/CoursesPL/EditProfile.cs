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
    public partial class EditProfile: Form
    {
        public EditProfile()
        {
            InitializeComponent();
        }
        public EditProfile(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }


        private int _userID;
        private string originalFullName;
        private string originalEmail;
        private string originalPhone;
        private byte[] originalImageBytes;
        private string selectedImagePath = "";

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                pictureBox.Image = Image.FromFile(selectedImagePath);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            string newFullName = tbFullName.Text.Trim();
            string newEmail = tbEmail.Text.Trim();
            string newPhone = tbPhone.Text.Trim();
            byte[] newImageBytes = null;

            bool isChanged = false;

            // Check if any text fields changed
            if (newFullName != originalFullName || newEmail != originalEmail || newPhone != originalPhone)
                isChanged = true;

            // Check if a new image was selected
            if (!string.IsNullOrEmpty(selectedImagePath))
            {
                newImageBytes = File.ReadAllBytes(selectedImagePath);
                isChanged = true;
            }

            if (!isChanged)
            {
                MessageBox.Show("No changes detected.");
                return;
            }

            // If not changed, set them to null so the update method can skip them
            if (newFullName == originalFullName) newFullName = null;
            if (newEmail == originalEmail) newEmail = null;
            if (newPhone == originalPhone) newPhone = null;
            if (string.IsNullOrEmpty(selectedImagePath)) newImageBytes = null;

            bool isUpdated = CoursesBL.CoursesBL.UpdateUserProfileSelective(_userID, newFullName, newEmail, newPhone, newImageBytes);

            if (isUpdated)
            {
                MessageBox.Show("Profile updated!");

                // Sync the originals to reflect new values
                originalFullName = newFullName ?? originalFullName;
                originalEmail = newEmail ?? originalEmail;
                originalPhone = newPhone ?? originalPhone;

                if (!string.IsNullOrEmpty(selectedImagePath))
                {
                    originalImageBytes = File.ReadAllBytes(selectedImagePath);
                    selectedImagePath = ""; // Reset selected image path
                }
            }
            else
            {
                MessageBox.Show("Update failed.");
            }
        }

        private void EditProfile_Load(object sender, EventArgs e)
        {
            DataTable profile = CoursesBL.CoursesBL.DisplayProfile(_userID);

            if (profile.Rows.Count > 0)
            {
                DataRow row = profile.Rows[0];

                // Set textboxes
                tbFullName.Text = row["FullName"].ToString();
                tbEmail.Text = row["Email"].ToString();
                tbPhone.Text = row["Phone"].ToString();

                // Set original values
                originalFullName = tbFullName.Text;
                originalEmail = tbEmail.Text;
                originalPhone = tbPhone.Text;

                // Load and store image
                if (row["ProfileImage"] != DBNull.Value)
                {
                    originalImageBytes = (byte[])row["ProfileImage"];
                    using (MemoryStream ms = new MemoryStream(originalImageBytes))
                    {
                        pictureBox.Image = Image.FromStream(ms);
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    pictureBox.Image = null;
                    originalImageBytes = null;
                }
            }
        }
    }
}
