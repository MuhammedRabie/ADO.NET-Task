using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsFirstDay.CoursesPL
{
    public partial class Login: Form
    {
        public Login()
        {
            InitializeComponent();
            this.Shown += Login_Shown;
        }

        void clear()
        {
            tbUsername.Text = tbPassword.Text = string.Empty;
        }
        public string UserName { get; private set; }
        public int UserId { get; private set; }
        public string TrackName { get; private set; }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text.Trim();
            string password = tbPassword.Text;

            int userId;
            string trackName;
            bool isValid = CoursesBL.CoursesBL.ValidateLogin(username, password, out userId, out trackName);

            if (isValid)
            {
                this.UserId = userId;
                this.UserName = username;
                this.TrackName = trackName;
                this.DialogResult = DialogResult.OK;
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Login Failed");
                clear();
            }
        }
        private void Login_Shown(object sender, EventArgs e)
        {
            tbUsername.Focus();
        }

        private void Login_Load(object sender, EventArgs e)
        {
           tbUsername.Focus();
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
