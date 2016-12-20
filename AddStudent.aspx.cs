using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddStudent : PageBase
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
            int indx = 1;
            List<CourseOffering> coursesOffering = CourseOfferingDataAccess.RetrieveAllCoursesOffering();
            foreach (CourseOffering courseO in coursesOffering)
            {
                drpRegisterStudentsList.Items.Insert(indx, courseO.CourseOffered.courseNumber + " " + courseO.CourseOffered.CourseName + " "+ courseO.Year + " "  + courseO.Semester);
                indx++;
            }
        }
    }

    protected void rdbStudentType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnAddToCourseOffering_Click(object sender, EventArgs e)
    {
        Student astudent = null;
        List<CourseOffering> coursesOffering = CourseOfferingDataAccess.RetrieveAllCoursesOffering();
        int indx = 1;
        
        try
        {
            switch (rdbStudentType.SelectedItem.Value)
            {
                case "FullTime":
                   astudent = new FullTimeStudent(txtStudentNumber.Text, txtStudentName.Text);
                    break;
                case "PartTime":
                     astudent = new PartTimeStudent(txtStudentNumber.Text, txtStudentName.Text);
                     break;
                case "Coop":
                    astudent = new CoopStudent(txtStudentNumber.Text, txtStudentName.Text);
                    break;
            }
            StudentDataAccess.AddNewStudent(astudent);

            if (drpRegisterStudentsList.SelectedIndex != 0)
            {
                foreach (CourseOffering courseO in coursesOffering)
                {
                    if (indx == drpRegisterStudentsList.SelectedIndex)
                    {
                        RegistrationDataAccess.AddNewRegistration(courseO, astudent);
                    }

                    indx++;
                    
                }
                indx = 1;
            }
        }
        catch (Exception)
        {

        }
        populateTable();
    }

    protected void drpRegisterStudentsList_SelectedIndexChanged(object sender, EventArgs e)
    {
        populateTable();
    }

    protected void populateTable()
    {
        if (drpRegisterStudentsList.SelectedIndex != 0)
        {
            string courseOffer = drpRegisterStudentsList.SelectedItem.Value;
            List<CourseOffering> coursesOffering = CourseOfferingDataAccess.RetrieveAllCoursesOffering();
            int indx = 0;
            foreach (CourseOffering courseO in coursesOffering)
            {
                if ((indx + 1) == drpRegisterStudentsList.SelectedIndex)
                {
                    List<Student> registeredS = RegistrationDataAccess.GetRegistedStudentsByCourseOffering(courseO);

                    if (registeredS.Count > 1)
                    {
                        registeredS.Sort((c1, c2) => c1.Name.CompareTo(c2.Name));
                    }

                    foreach (Student student in registeredS)
                    {
                        TableRow row = new TableRow();

                        TableCell cell = new TableCell();
                        cell.Text = student.Number;
                        row.Cells.Add(cell);

                        cell = new TableCell();
                        cell.Text = student.Name;
                        row.Cells.Add(cell);

                        cell = new TableCell();
                        string sType = "Not enrolled";

                        if (student.GetType() == typeof(FullTimeStudent))
                        {
                            sType = "Full-Time";
                        }

                        else if (student.GetType() == typeof(PartTimeStudent))
                        {
                            sType = "Part-Time";
                        }

                        else if (student.GetType() == typeof(CoopStudent))
                        {
                            sType = "Co-op";
                        }
                        cell.Text = sType;
                        row.Cells.Add(cell);

                        cell = new TableCell();
                        cell.Text = student.TuitionPayable().ToString();
                        row.Cells.Add(cell);

                        tblCourseOfferingRegisteredStudent.Rows.Add(row);
                    }

                }
                indx++;
            }
            lblCourseOfferingDisplay_forRegisterStudent.Text = courseOffer;

        }
        else
        {
            lblCourseOfferingDisplay_forRegisterStudent.Text = string.Empty;

        }
    } 
}