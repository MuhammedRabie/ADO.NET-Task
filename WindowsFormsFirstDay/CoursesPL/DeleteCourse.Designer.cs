﻿namespace WindowsFormsFirstDay.CoursesPL
{
    partial class DeleteCourse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.deleteCoursebtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCourseID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // deleteCoursebtn
            // 
            this.deleteCoursebtn.Location = new System.Drawing.Point(110, 68);
            this.deleteCoursebtn.Name = "deleteCoursebtn";
            this.deleteCoursebtn.Size = new System.Drawing.Size(102, 36);
            this.deleteCoursebtn.TabIndex = 0;
            this.deleteCoursebtn.Text = "Delete Course";
            this.deleteCoursebtn.UseVisualStyleBackColor = true;
            this.deleteCoursebtn.Click += new System.EventHandler(this.deleteCoursebtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CourseID";
            // 
            // tbCourseID
            // 
            this.tbCourseID.Location = new System.Drawing.Point(84, 42);
            this.tbCourseID.Name = "tbCourseID";
            this.tbCourseID.Size = new System.Drawing.Size(167, 20);
            this.tbCourseID.TabIndex = 2;
            // 
            // DeleteCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 130);
            this.Controls.Add(this.tbCourseID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteCoursebtn);
            this.Name = "DeleteCourse";
            this.Text = "DeleteCourse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deleteCoursebtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCourseID;
    }
}