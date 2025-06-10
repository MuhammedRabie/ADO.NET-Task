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
    public partial class App_Courses: Form
    {
        public App_Courses()
        {
            InitializeComponent();
        }

        private void App_Courses_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CoursesBL.CoursesBL.GetAllCourses();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
