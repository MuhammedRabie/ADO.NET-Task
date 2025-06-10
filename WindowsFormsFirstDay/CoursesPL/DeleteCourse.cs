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
    public partial class DeleteCourse: Form
    {
        public DeleteCourse()
        {
            InitializeComponent();
        }

        private void deleteCoursebtn_Click(object sender, EventArgs e)
        {
            int courseID = int.Parse(tbCourseID.Text);
            int affectedrows = CoursesBL.CoursesBL.DeleteCourse(courseID);
            if (affectedrows == 1)
            {
                MessageBox.Show("Course Deleted successfully!");
                tbCourseID.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Failed to Delete course.");
            }
        }
    }
}
