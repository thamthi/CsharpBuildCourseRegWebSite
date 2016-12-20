using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;

/// <summary>
/// Summary description for StudentDataAccess
/// </summary>
public class StudentDataAccess : DataAccessBase
{
    public static int AddNewStudent(Student student)
    {
        //Define ADO.NET objects
        string insertStudentSQL = "INSERT INTO Student(StudentNum, Name, Type) VALUES (@StudentNum, @Name, @Type)";

        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand sqlStudentCmd = new SqlCommand(insertStudentSQL, connection);

        // Add the parameters
        sqlStudentCmd.Parameters.AddWithValue("@StudentNum", student.Number);
        sqlStudentCmd.Parameters.AddWithValue("@Name", student.Name);

        string studentType = "";

        if (student.GetType() == typeof(FullTimeStudent))
        {
            studentType = "Full";
        }
        else if (student.GetType() == typeof(PartTimeStudent))
        {
            studentType = "Part";
        }
        else if (student.GetType() == typeof(CoopStudent))
        {
            studentType = "Coop";
        }
       

        sqlStudentCmd.Parameters.AddWithValue("@Type", studentType);

        // Try to open the database and execute the update
        int added = 0;
        try
        {
            connection.Open();
            added = sqlStudentCmd.ExecuteNonQuery();
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
    public static Student RetrieveStudentByStudentNum(string studentNum)
    {
        string selectStudentByIdSQL = "SELECT StudentNum FROM Student WHERE studentNum = StudentNum";

        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(selectStudentByIdSQL, connection);
        SqlDataReader reader = null;

        List<Student> students = new List<Student>();

        try
        {
            connection.Open();
            reader = command.ExecuteReader();
            if (reader != null && reader.HasRows)
            {
                string studentId = (string)reader["StudentNum"];
                string studentName = (string)reader["Name"];
                string studentType = (string)reader["Type"];
                Student student = null;

                if (studentType == StudentType.FullTime)
                {
                    student = new FullTimeStudent(studentNum, studentName);
                }
                if (studentType == StudentType.PartTime)
                {
                    student = new PartTimeStudent(studentNum, studentName);
                }
                if (studentType == StudentType.Coop)
                {
                    student = new CoopStudent(studentNum, studentName);
                }
                students.Add(student);
                return student;
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
        return null;
    }
    public static List<Student> RetrieveAllStudent()
    {
        // Define ADO.NET objects
        string selectStudentsSQL = "SELECT * FROM Student";

        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(selectStudentsSQL, connection);
        SqlDataReader reader = null;

        List<Student> students = new List<Student>();
        try
        {
            connection.Open();
            reader = command.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    string studentNum = (string)reader["StudentNum"];
                    string studentName = (string)reader["Name"];
                    string studentType = (string)reader["Type"];
                    Student student = null;

                    if (studentType == StudentType.FullTime)
                    {
                        student = new FullTimeStudent(studentNum, studentName);
                    }
                    if (studentType == StudentType.PartTime)
                    {
                        student = new PartTimeStudent(studentNum, studentName);
                    }
                    if (studentType == StudentType.Coop)
                    {
                        student = new CoopStudent(studentNum, studentName);
                    }
                    students.Add(student);
                }
            }
            return students;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
    }
}

