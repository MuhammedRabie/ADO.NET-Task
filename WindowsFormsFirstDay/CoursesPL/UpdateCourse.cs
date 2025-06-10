using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsFirstDay.CoursesPL
{
    public partial class UpdateCourse: Form
    {
        public UpdateCourse()
        {
            InitializeComponent();
        }

        private void updatecoursebtn_Click_1(object sender, EventArgs e)
        {

            int courseID = int.Parse(tbCourseID.Text);
            string courseName = tbCourseName.Text;
            string description = tbDescription.Text;
            int duration = int.Parse(tbDuration.Text);
            string TrackName = tbTrackName.Text;
            int rowsAffected = CoursesBL.CoursesBL.UpdateCourse(courseID, courseName, description, duration, TrackName);
            if (rowsAffected > 0)
            {
                MessageBox.Show("Course Updated successfully!");
                tbCourseName.Text = tbDescription.Text = tbDuration.Text = tbTrackName.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Failed to update course.");
            }
        }
    }
}
