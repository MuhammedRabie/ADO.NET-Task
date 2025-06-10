using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace WindowsFormsFirstDay.CoursesPL
{
    public partial class AddCourses: Form
    {

        public AddCourses()
        {
            InitializeComponent();
        }

        private void AddCourses_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void addcoursebtn_Click(object sender, EventArgs e)
        {
            string courseName = tbCourseName.Text;
            string description = tbDescription.Text;
            int duration = int.Parse(tbDuration.Text);
            string trackName = tbTrackName.Text;
            int rowsAffected = CoursesBL.CoursesBL.AddNewCourse(courseName, description, duration, trackName);

            if (rowsAffected > 0)
            {
                MessageBox.Show("Course added successfully!");
                tbCourseName.Text = tbDescription.Text = tbDuration.Text = tbTrackName.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Failed to add course.");
            }

        }
    }
}
