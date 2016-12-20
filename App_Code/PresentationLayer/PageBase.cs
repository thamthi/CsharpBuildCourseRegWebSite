using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for PageBase
/// </summary>
public class PageBase: System.Web.UI.Page
{
    protected virtual void Page_Load(object sender, EventArgs e)
    {
        LinkButton addNewCourseSideButton = (LinkButton)Master.FindControl("sidebarButton1");
        LinkButton addNewCourseOfferingSideButton = (LinkButton)Master.FindControl("sidebarButton2");
        LinkButton addNewStudentSideButton = (LinkButton)Master.FindControl("sidebarButton3");

        if (!IsPostBack)
        {
            Image logo = (Image)Master.FindControl("programLogo");
            logo.ImageUrl = "~/App_Themes/Sat.png";

            addNewCourseSideButton.Text += "Add Course";
            addNewCourseOfferingSideButton.Text += "Add Course Offering";
            addNewStudentSideButton.Text += "Register Student";
        }

        // use Lamda expression to create event handlers
        addNewCourseSideButton.Click += (se, ev) => Response.Redirect("AddCourse.aspx");
        addNewCourseOfferingSideButton.Click += (se, ev) => Response.Redirect("AddCourseOffering.aspx");
        addNewStudentSideButton.Click += (se, ev) => Response.Redirect("AddStudent.aspx");

        //use function declaration to create event handlers
        //addNewCourseSideButton.Click += addNewCourseSideButton_click;
        //addNewCourseOfferingSideButton.Click += addNewCourseOfferingSideButton_click;
        //addNewStudentSideButton.Click += addNewStudentSideButton_click;
    }
        protected void addNewCourseSideButton_click(object sender, EventArgs e)
        {
            Response.Redirect("AddCourse.aspx");
        }
        protected void addNewCourseOfferingSideButton_click(object sender, EventArgs e)
        {
            Response.Redirect("AddCourseOffering.aspx");
        }
        protected void addNewStudentSideButton_click(object sender, EventArgs e)
        {
        Response.Redirect("AddStudent.aspx");
        }
    }
