using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddCourse : PageBase
{
    protected override void OnPreInit(EventArgs e)
    {
        this.MasterPageFile = "~/algonquinMasterPage2.master";
        base.OnPreInit(e);
    }
    protected void btnSumitCourseInfo_Click(object sender, EventArgs e)
    {
        int hours = int.Parse(txtCourseWklyHours.Text);
        Course course = new Course(txtCourseNumber.Text, txtCourseName.Text, hours);
        CourseDataAccess.AddNewCourse(course);
        
    }

    protected void Page_PreRender(object sender, EventArgs ev)
    {
        txtCourseName.Text = "";
        txtCourseNumber.Text = "";
        txtCourseWklyHours.Text = "";
        List<Course> courses = CourseDataAccess.RetrieveAllCourses();
        ShowCourseInfo(courses);
    }

    private void ShowCourseInfo(List<Course> courses)
    {
        if (courses.Count == 0)
        {
            TableRow lastRow = new TableRow();
            TableCell lastRowCell = new TableCell();
            lastRowCell.Text = "No Course Exist!";
            lastRowCell.ForeColor = System.Drawing.Color.Red;
            lastRowCell.ColumnSpan = 3;
            lastRowCell.HorizontalAlign = HorizontalAlign.Center;
            lastRow.Cells.Add(lastRowCell);
            tblCourseInfo.Rows.Add(lastRow);
        }

        else
        {
            courses.Sort((c1, c2) => c1.CourseName.CompareTo(c2.CourseName));

            foreach (Course course in courses)
            {
                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.Text = course.courseNumber;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = course.CourseName;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = course.WeeklyHours.ToString();
                row.Cells.Add(cell);

                tblCourseInfo.Rows.Add(row);
            }

        }
    }
    
}