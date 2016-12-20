using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
/// <summary>
/// Summary description for CourseOfferingDataAccess
/// </summary>
public class CourseOfferingDataAccess: DataAccessBase
{
    public static int AddNewCourseOffering(CourseOffering courseOffering)
    {
        if (!checkCourseOffering(courseOffering))
        {

            //Define ADO.NET objects
            string insertCourseOfferingSQL = "INSERT INTO CourseOffering(Course_CourseID, Year, Semester) VALUES (@Course_CourseID, @Year, @Semester)";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCourseCmd = new SqlCommand(insertCourseOfferingSQL, connection);

            // Add the parameters
            sqlCourseCmd.Parameters.AddWithValue("@Course_CourseID", courseOffering.CourseOffered.CourseNumber);
            sqlCourseCmd.Parameters.AddWithValue("@Year", courseOffering.Year);
            sqlCourseCmd.Parameters.AddWithValue("@Semester", courseOffering.Semester);

            // Try to open the database and execute the update
            int added = 0;
            try
            {
                connection.Open();
                added = sqlCourseCmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return added;
        }
        return 0;
    }
    public static List<CourseOffering> RetrieveAllCoursesOffering()
    {
        // Define ADO.NET objects
        string selectCoursesOfferingSQL = "SELECT * FROM CourseOffering Left Join Course ON Course_CourseID = CourseID;";

        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(selectCoursesOfferingSQL, connection);
        SqlDataReader reader = null;

        List<CourseOffering> coursesOfferings = new List<CourseOffering>();
        try
        {
            connection.Open();
            reader = command.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    string courseID = (string)reader["CourseID"];
                    string courseTitle = (string)reader["CourseTitle"];
                    int hourPerWeek = (int)reader["HoursPerWeek"];
                    Course course = new Course(courseID, courseTitle.ToString(), hourPerWeek);

                    int year = (int)reader["Year"];
                    string semester = (string)reader["Semester"];
                    CourseOffering courseOffering = new CourseOffering(course, year, semester);

                    coursesOfferings.Add(courseOffering);
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
        return coursesOfferings;
    }
    public static List<CourseOffering> RetrievCoursesOfferingByCourse(Course course)
    {
        string selectCourseOfferingByCourseSQL = "SELECT Course_CourseID FROM CourseOffering WHERE Course_CourseID=course";

        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(selectCourseOfferingByCourseSQL, connection);
        SqlDataReader reader = null;

        List<CourseOffering> coursesOfferings = new List<CourseOffering>();
        try
        {
            connection.Open();
            reader = command.ExecuteReader();
            if (reader != null && reader.HasRows)
            {
                string coursetNum = (string)reader["CourseID"];
                string coursetName = (string)reader["CourseTitle"];
                int coursetHours = (int)reader["HoursPerWeek"];
                Course courseOffer = new Course(coursetNum, coursetName, coursetHours);

                int year = (int)reader["Year"];
                string semester = (string)reader["Semester"];
                CourseOffering courseOffering = new CourseOffering(courseOffer, year, semester);

                coursesOfferings.Add(courseOffering);              
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
        return coursesOfferings;
    }

    private static bool checkCourseOffering(CourseOffering courseOffering)
    {
        string sqlCheckCourseOffering = "SELECT count(*) FROM CourseOffering WHERE Year=@Year AND Semester=@Semester AND Course_CourseID=@CourseID;";

        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(sqlCheckCourseOffering, connection);

        int intOffered = 0;
        try
        {
            command.Parameters.AddWithValue("@CourseID", courseOffering.CourseOffered.CourseNumber);
            command.Parameters.AddWithValue("@Year", courseOffering.Year);
            command.Parameters.AddWithValue("@Semester", courseOffering.Semester);

            connection.Open();

            
            intOffered = (int)command.ExecuteScalar();
      
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }

        if (intOffered > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}