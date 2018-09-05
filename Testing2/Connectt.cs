using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;   // System.Data.dll 
using System.Data.Common;
//using System.Data;  

namespace Testing2
{
    static class Connectt
    {
        static string Build_2_Tsql_CreateTables()
        {
            return @"
 DROP TABLE IF EXISTS bookings;
    CREATE TABLE bookings
(
    IDuser int not null,
    IDproduct int not null, 
    reservationDate date not null,
    deliveryDate date not null,
    location nvarchar(128) not null,
    confirmation bit not null
);
 ";
        }
        static string Build_6_Tsql_SelecUsers()
        {
            return @"
 SELECT
      IDuser,
IDproduct,
confirmation,
deliveryDate,
reservationDate,
location
    FROM
       bookings
    ORDER BY
       IDuser;
 ";
        }
        public static void Submit_Tsql_NonQuery(
          SqlConnection connection,
          string tsqlPurpose,
          string tsqlSourceCode,
          string parameterName = null,
          string parameterValue = null
          )
        {
            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("T-SQL to {0}...", tsqlPurpose);

            using (var command = new SqlCommand(tsqlSourceCode, connection))
            {
                if (parameterName != null)
                {
                    command.Parameters.AddWithValue(  // Or, use SqlParameter class.
                       parameterName,
                       parameterValue);
                }
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsAffected + " = rows affected.");
            }
        }
        public static void Submit_6_Tsql_SelectUsers(SqlConnection connection)
        {
            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("Now, SelectUsers...");

            string tsql = Build_6_Tsql_SelecUsers();

            using (var command = new SqlCommand(tsql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Console.WriteLine("{0} , {1}, {2} ",
                        //  reader.GetValue(reader.GetOrdinal("productID")),
                        //   reader.GetValue(reader.GetOrdinal("productName")),
                        //   reader.GetValue(reader.GetOrdinal("quantity")));


                        Console.WriteLine("{0} , {1}, {2},{3},{4},{5}",
                          reader.GetValue(reader.GetOrdinal("IDuser")),
                           reader.GetValue(reader.GetOrdinal("IDproduct")),
                           reader.GetValue(reader.GetOrdinal("confirmation")),
                           reader.GetValue(reader.GetOrdinal("deliveryDate")),
                           reader.GetValue(reader.GetOrdinal("reservationDate")),
                           reader.GetValue(reader.GetOrdinal("location")));

                    }
                }
            }
        }
        public static void Con()
        {
            try
            {
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "prjserver.database.windows.net";
                cb.UserID = "serveradmin";
                cb.Password = "Azurefinalapp4";
                cb.InitialCatalog = "projectTesting";

                using (var connection = new SqlConnection(cb.ConnectionString))
                {
                    connection.Open();


                    using (DbCommand command = new SqlCommand("insert into users (username,password,type,groupID,email) values ('ioana','admin','admin',4,'t-anpirv@microsoft.com');"))
                    {
                        command.Connection = connection;
                        command.ExecuteNonQuery();
                    }



                    // Submit_Tsql_NonQuery(connection, "2 - Create-Tables",
                    //Build_2_Tsql_CreateTables());


                    //Submit_Tsql_NonQuery(connection, "3 - Inserts",
                    //   Build_3_Tsql_Inserts());

                    //Submit_Tsql_NonQuery(connection, "4 - Update-Join",
                    //   Build_4_Tsql_UpdateJoin(),
                    //   "@csharpParmDepartmentName", "Accounting");

                    //Submit_Tsql_NonQuery(connection, "5 - Delete-Join",
                    //   Build_5_Tsql_DeleteJoin(),
                    //   "@csharpParmDepartmentName", "Legal");
                    Submit_6_Tsql_SelectUsers(connection);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("View the report output here, then press any key to end the program...");
            //Console.ReadKey();
        }
    }
}
