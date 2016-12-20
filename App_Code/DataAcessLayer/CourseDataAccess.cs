using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CourseDataAccess
/// </summary>
public class CourseDataAccess:DataAccessBase
{
    public static int AddNewCourse(Course course)
    {
        //Define ADO.NET objects
        string insertCourseSQL = "INSERT INTO Course(CourseID, CourseTitle, HoursPerWeek) VALUES (@courseID, @courseTitle, @courseHours)";

        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand sqlCourseCmd = new SqlCommand(insertCourseSQL, connection);

        // Add the parameters
        sqlCourseCmd.Parameters.AddWithValue("@CourseID", course.courseNumber);
        sqlCourseCmd.Parameters.AddWithValue("@CourseTitle", course.CourseName);
        sqlCourseCmd.Parameters.AddWithValue("@CourseHours", course.WeeklyHours);

        // Try to open the database and execute the update
        int added = 0;
        try
        {
            connection.Open();
            added = sqlCourseCmd.ExecuteNonQuery();
        }
        catch(Exception)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
        return added;
    }
    public static Course RetrieveCourseByCourseId(string id)
    {
        string selectCourseByIdSQL = "SELECT * FROM Course WHERE CourseID = @id;" ;

        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(selectCourseByIdSQL, connection);
        SqlDataReader reader = null;

        command.Parameters.AddWithValue("@id", id);

        List<Course> courses = new List<Course>();
        Course course = null;
        try
        {
            connection.Open();
            reader = command.ExecuteReader();
            if (reader !=null && reader.HasRows)
            {
                while(reader.Read())
                {
                    string coursetNum = (string)reader["CourseID"];
                    string coursetName = (string)reader["CourseTitle"];
                    int coursetHours = (int)reader["HoursPerWeek"];
                    course = new Course(coursetNum, coursetName, coursetHours);
                    courses.Add(course);
                }       
                
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
        return course;
    }
    
    public static List<Course> RetrieveAllCourses()
    {
        // Define ADO.NET objects
        string selectCoursesSQL = "SELECT * FROM Course";

        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(selectCoursesSQL, connection);
        SqlDataReader reader = null;

        List<Course> courses = new List<Course>();
        try
        {
            connection.Open();
            reader = command.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    string courseNum = (string)reader["CourseID"];
                    string coursetName = (string)reader["CourseTitle"];
                    int coursetHours = (int)reader["HoursPerWeek"];

                    Course course = new Course(courseNum, coursetName, coursetHours);
                    courses.Add(course);
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
        return courses;
    }
}
