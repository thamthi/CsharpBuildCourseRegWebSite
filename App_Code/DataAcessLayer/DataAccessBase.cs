using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DataAccessBase
/// </summary>
public class DataAccessBase
{
    protected static string connectionString = WebConfigurationManager.ConnectionStrings["Student"].ConnectionString;
}