using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
	public static class DBHelper
	{
		public static void Exec()
		{
			using (SqlConnection conn = new SqlConnection("Server=[server_name];Database=[database_name];Trusted_Connection=true"))
			using (SqlCommand command = new SqlCommand("SELECT * FROM TableName WHERE FirstColumn = @0", conn))
			{
				conn.Open();
				command.Parameters.Add(new SqlParameter("0", 1));

				using (SqlDataReader reader = command.ExecuteReader())
				{
					Console.WriteLine("FirstColumn\tSecond Column\t\tThird Column\t\tForth Column\t");
					while (reader.Read())
					{
						Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3}",
							reader[0], reader[1], reader[2], reader[3]));
					}
				}
			}
		}
	}
}
