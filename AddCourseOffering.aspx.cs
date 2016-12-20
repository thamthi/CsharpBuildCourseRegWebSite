using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddCourseOffering : PageBase
{
    protected override void OnPreInit(EventArgs e)
    {
        this.MasterPageFile = "~/algonquinMasterPage2.master";
        base.OnPreInit(e);
    }
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
        if (!IsPostBack)
        {
            List<Course> courses = CourseDataAccess.RetrieveAllCourses();
            List<CourseOffering> coursesOffering = CourseOfferingDataAccess.RetrieveAllCoursesOffering();
            
            if (courses.Count == 0)
            {
                Response.Redirect("AddCourse.aspx");
            }
            else
            {
                courses.Sort((c1, c2) => c1.CourseName.CompareTo(c2.CourseName));
                foreach (Course course in courses)
                {
                    drpCourseOfferingList.Items.Add(new ListItem(course.ToString(), course.courseNumber));
                }
                
                drpOfferInYr.Items.Add(new ListItem("2016"));
                drpOfferInYr.Items.Add(new ListItem("2017"));
                drpOfferInYr.Items.Add(new ListItem("2018"));
                drpOfferInYr.Items.Add(new ListItem("2019"));
                drpOfferInYr.Items.Add(new ListItem("2020"));

                drpSemester.Items.Add(new ListItem(Semester.Fall));
                drpSemester.Items.Add(new ListItem(Semester.Winter));
                drpSemester.Items.Add(new ListItem(Semester.Spring_Summer));
            }
            //drpSemester.Items.Add(lblSemest.Fall);
            //drpSemester.Items.Add(lblSemest.Winter);
            //drpSemester.Items.Add(lblSemest.SpringSummer);
        }
    }
    protected void Page_PreRender(object sender, EventArgs ev)
    {
        //drpCourseOfferingList.Text = "";
        //drpOfferInYr.Text = "";
        //drpSemester.Text = "";
        List<CourseOffering> coursesOffering = CourseOfferingDataAccess.RetrieveAllCoursesOffering();
        ShowCourseOfferingInfo(coursesOffering);
    }
    protected void btnAddCourseOffering_Click(object sender, EventArgs e)
    {
        string courseId = drpCourseOfferingList.SelectedValue;
        int year = int.Parse(drpOfferInYr.SelectedValue);
        string semester = drpSemester.SelectedValue;

        Course course = CourseDataAccess.RetrieveCourseByCourseId(courseId);
        CourseOffering courseOffering = new CourseOffering(course,year,semester);
        CourseOfferingDataAccess.AddNewCourseOffering(courseOffering);
        
    }
    private void ShowCourseOfferingInfo(List<CourseOffering> coursesOffering)
    {

        if (coursesOffering.Count == 0)
        {
            TableRow lastRow = new TableRow();
            TableCell lastRowCell = new TableCell();
            lastRowCell.Text = "No Course Offering Exist!";
            lastRowCell.ForeColor = System.Drawing.Color.Red;
            lastRowCell.ColumnSpan = 3;
            lastRowCell.HorizontalAlign = HorizontalAlign.Center;
            lastRow.Cells.Add(lastRowCell);
            tblCourseOffering.Rows.Add(lastRow);
        }
        else
        {
            CourseOfferingComparer compareOffer = new CourseOfferingComparer();
            coursesOffering.Sort(compareOffer.Compare);
            
            foreach (CourseOffering course in coursesOffering)
            {
                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.Text = course.CourseOffered.courseNumber;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = course.CourseOffered.CourseName;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = course.Year.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = course.Semester;
                row.Cells.Add(cell);

                tblCourseOffering.Rows.Add(row);
            }

        }
    }

    protected void drpCourseOfferingList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpCourseOfferingList.SelectedIndex != 0)
        {
            string courseId = drpCourseOfferingList.SelectedItem.Value;
            Course course = CourseDataAccess.RetrieveCourseByCourseId(courseId);

            lblCourseOfferingDisplay.Text = courseId; 
            
        }
        else
        {
            lblCourseOfferingDisplay.Text = string.Empty;
            
        }
    }

    protected void drpOfferInYr_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void drpSemester_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}