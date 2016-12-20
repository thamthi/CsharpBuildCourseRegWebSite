using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
/// <summary>
/// Summary description for RegistrationDataAccess
/// </summary>
public class RegistrationDataAccess: DataAccessBase
{
   public static int AddNewRegistration(CourseOffering courseOffering, Student student)
    {
        // Define ADO.NET Objects
        string insertRegistrationSQL =
            "INSERT INTO Registration"
                + "(Student_StudentNum, CourseOffering_Course_CourseID, CourseOffering_Year, CourseOffering_Semester)"
                + "VALUES (@studentNum, @courseID, @year,@semester)";

        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand sqlInsertRegistrationCmd = new SqlCommand(insertRegistrationSQL, connection);

        // Add the parameters
        sqlInsertRegistrationCmd.Parameters.AddWithValue("@studentNum", student.Number);
        sqlInsertRegistrationCmd.Parameters.AddWithValue("@courseID", courseOffering.CourseOffered.courseNumber);
        sqlInsertRegistrationCmd.Parameters.AddWithValue("@year", courseOffering.Year);
        sqlInsertRegistrationCmd.Parameters.AddWithValue("@semester", courseOffering.Semester);

        //Try to open the database and execute the update
        int added = 0;
        try
        {
            connection.Open();
            added = sqlInsertRegistrationCmd.ExecuteNonQuery();
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
    public static List<Student> GetRegistedStudentsByCourseOffering(CourseOffering courseOffering)
    {
        // Define ADO.NET objects
        string selectSQL = "SELECT s.StudentNum, s.Name, s.Type FROM Student s"
                                    + " JOIN Registration r ON s.StudentNum = r.Student_StudentNum"
                                    + " WHERE r.CourseOffering_Course_CourseID = @CourseID"
                                    + " AND r.CourseOffering_Year = @Year "
                                    + " AND r.CourseOffering_Semester = @Semester";

        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand SqlCoursecommand = new SqlCommand(selectSQL, connection);

        // Add the parameters
        SqlCoursecommand.Parameters.AddWithValue("@CourseID", courseOffering.CourseOffered.courseNumber);
        SqlCoursecommand.Parameters.AddWithValue("@Year", courseOffering.Year);
        SqlCoursecommand.Parameters.AddWithValue("@Semester",courseOffering.Semester);

        SqlDataReader reader = null;

        List<Student> students = new List<Student>();
        try
        {
            connection.Open();
            reader = SqlCoursecommand.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    string studentNum = (string)reader["StudentNum"];
                    string studentName = (string)reader["Name"];
                    string studentType = (string)reader["Type"];
                    Student student = null;

                    if (studentType == "Full" || studentType == "full")
                    {
                        student = new FullTimeStudent(studentNum, studentName);
                    }
                    if (studentType == "Part" || studentType == "part")
                    {
                        student = new PartTimeStudent(studentNum, studentName);
                    }
                    if (studentType == "Coop" || studentType == "coop")
                    {
                        student = new CoopStudent(studentNum,studentName);
                    }
                    students.Add(student);
                }
                //return students;
            }
            
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            if (reader != null)
            {
                reader.Close();
            }
            connection.Close();
        }
        return students;
    }
    public static List<CourseOffering> GetRegisteredCourseOfferingsByStudent(Student student)
    {
        // Define ADO.NET objects
        string selectSQL = "SELECT c.CourseID, c.CourseTitle, c.HoursPerWeek r.CourseOffering_Year r.CourseOffering_Semester"
                                    + "FROM Course c"
                                    + "JOIN Registration r ON c.CourseID =  r.CourseOffering_Course_CourseID"
                                    + "WHERE r.Student_StudentNum = @studentNumber";

        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand SqlCoursecommand = new SqlCommand(selectSQL, connection);

        // Add the parameters
        SqlCoursecommand.Parameters.AddWithValue("@StudentNumber", student);
        

        SqlDataReader reader = null;
        List<CourseOffering> coursesOfferings = new List<CourseOffering>();
        try
        {
            connection.Open();
            reader = SqlCoursecommand.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    string courseID = (string)reader["CourseID"];
                    int courseTitle = (int)reader["CourseTitle"];
                    int hourPerWeek = (int)reader["HoursPerWeek"];
                    Course course = new Course(courseID, courseTitle.ToString(), hourPerWeek);

                    int year = (int)reader["CourseOffering_Year"];
                    string semester = (string)reader["CourseOffering_Semester"];
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
            if (reader != null)
            {
                reader.Close();
            }
            connection.Close();
        }
        return coursesOfferings;
    }
}