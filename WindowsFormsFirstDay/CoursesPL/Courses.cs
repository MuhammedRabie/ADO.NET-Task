using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsFirstDay.CoursesPL
{
    public partial class Courses: Form
    {
        private int userID;
        private string UserName, TrackName;
        public bool logged { get; set; }
        public Courses(int UserId , string UserName , string TrackName)
        {
            InitializeComponent();
            userID = UserId;
            this.UserName = UserName;
            this.TrackName = TrackName;
            this.FormClosed += Courses_FormClosed;
        }
        private void Courses_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show($"{UserName}, Are you sure you want to logout ?","Logout",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (x==DialogResult.OK)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            AddCourses add = new AddCourses();
            add.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            App_Courses app = new App_Courses();
            app.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateCourse update = new UpdateCourse();
            update.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteCourse delete = new DeleteCourse();
            delete.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile(userID);
            profile.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EditProfile editForm = new EditProfile(userID);
            editForm.ShowDialog();
        }

        private void Courses_Load(object sender, EventArgs e)
        {
            namelabel.Text = UserName.ToString();
            tracklabel.Text = "Track:"+TrackName.ToString();
        }
    }
}
