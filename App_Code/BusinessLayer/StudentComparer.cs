using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentComparer
/// </summary>
public class StudentComparer:IComparer<Student>
{
    public StudentComparer()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int CompareTypeStudent(Student student1, Student student2)
    {
        if (student1.GetType() == student2.GetType())
        {
            return 0;
        }
        else if (student1.GetType() == typeof(FullTimeStudent))
        {
            return -1;
        }
        else if (student2.GetType() == typeof(PartTimeStudent))
        {
            return 1;
        }
        else if (student1.GetType() == typeof(CoopStudent))
        {
            return -1;
        }
        else
        {
            return 1;
        }

    }
    public int Compare(Student student1, Student student2)
    {
        if (student1 == null && student2 != null)
        {
            return 1;
        }
        if (student1 != null && student2 == null)
        {
            return -1;
        }

        if (student1 == null && student2 == null)
        {
            return 0;
        }
     
        if (student1.Name == student2.Name)
        {
            if (student1.GetType() == student2.GetType())
            {
                return student1.Number.CompareTo(student2.Number);  
            }
            else
            {
                if (student1.GetType() == typeof(FullTimeStudent) || student2.GetType() == typeof(CoopStudent))
                {
                    return -1;
                }
                else if (student2.GetType() == typeof(FullTimeStudent) || student1.GetType() == typeof(CoopStudent))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            
        }
        else
        {
            return student1.Name.CompareTo(student2.Name);
        }   
    }
}