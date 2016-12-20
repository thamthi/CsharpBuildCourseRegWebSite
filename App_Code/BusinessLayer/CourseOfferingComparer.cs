using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CourseOfferingComparer
/// </summary>
public class CourseOfferingComparer : IComparer<CourseOffering>
{
    public CourseOfferingComparer()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int Compare(CourseOffering co1, CourseOffering co2)
    {
        if (co1 == null && co2 != null)
        {
            return -1;
        }
        if (co1 != null && co2 == null)
        {
            return 1;
        }

        if (co1 == null && co2 == null)
        {
            return 0;
        }

        if (co1.Year == co2.Year)
        {
            if (co1.Semester == co2.Semester)
            {
                return co1.CourseOffered.CourseName.CompareTo(co2.CourseOffered.CourseName);
            }
            else
            {
                if (co1.Semester == "Fall" || co2.Semester == "Spring/Summer")
                {
                    return -1;
                }
                else if (co2.Semester == "Fall" || co1.Semester == "Spring/Summer")
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
            return co1.Year.CompareTo(co2.Year);
        }
    }
}