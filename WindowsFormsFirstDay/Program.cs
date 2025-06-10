using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsFirstDay.CoursesPL;

namespace WindowsFormsFirstDay
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            while (true)
            {
                Login loginForm = new Login();
                DialogResult result = loginForm.ShowDialog();
                
                if (result == DialogResult.OK)
                {
                    CoursesPL.Courses coursesForm = new CoursesPL.Courses(
                        loginForm.UserId,
                        loginForm.UserName,
                        loginForm.TrackName
                    );

                    DialogResult coursesResult = coursesForm.ShowDialog();

                    // if Courses form was closed normally, loop back to login
                    if (coursesResult == DialogResult.Cancel || coursesResult == DialogResult.None)
                        continue;
                    else
                        break; // or exit app if you prefer
                }
                else
                {
                    break; // user closed login form or canceled
                }
            }
        }
    }
}
