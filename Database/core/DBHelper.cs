using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.core
{
	public static class DBHelper
	{
		/// <summary>
		/// Executes sql query with parameters against database.
		/// </summary>
		public static void Exec(string query, List<SqlParameter> sqlParameters)
		{
			using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
			using (SqlCommand command = new SqlCommand(query, conn))
			{
				conn.Open();
				sqlParameters?.ForEach(p => command.Parameters.Add(p));
				//command.Parameters.Add(new SqlParameter("0", 1));

				using (SqlDataReader reader = command.ExecuteReader())
				{
					Console.WriteLine("FirstColumn\tSecond Column");
					while (reader.Read())
					{
						Console.WriteLine(String.Format("{0} \t | {1}",
							reader[0], reader[1]));
					}
				}
			}
		}

		/// <summary>
		/// Executes sql query against database.
		/// </summary>
		public static void Exec(string query)
		{
			Exec(query, null);
		}

	}
}
