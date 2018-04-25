using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsTest
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			using (SqlConnection conn = new SqlConnection("data source=.; Initial Catalog=Test; User Id=cristi; Password=cristi"))
			{
				SqlCommand command = new SqlCommand();
				command.Connection = conn;
				command.CommandType = CommandType.Text;
				command.CommandText = "select * from Produse";

				//command.Parameters.Add(new SqlParameter("column", SqlDbType.VarChar, 50));
				//command.Parameters["column"].Value = yourColumnValue;

				conn.Open();

				using (SqlDataReader sqlDataReader = command.ExecuteReader())
				{
					DataTable dataTable = new DataTable();
					dataTable.Load(sqlDataReader);

					DataTable dt = new DataTable();
					dt.Columns.AddRange(new DataColumn[7] { new DataColumn("IdProdus"), new DataColumn("Nume"), new DataColumn("Categorie"), new DataColumn("Tip1"),
																new DataColumn("Tip2"), new DataColumn("Tip3"), new DataColumn("Tip4")});

					foreach (DataRow row in dataTable.Rows)
					{
						if(row["Tip"].ToString() == "1")
						{
							dt.Rows.Add(row["IdProdus"], row["Nume"], row["Categorie"], row["Tip"]);
						}
						else if (row["Tip"].ToString() == "2")
						{
							dt.Rows.Add(row["IdProdus"], row["Nume"], row["Categorie"], null,  row["Tip"]);
						}
					}

					GridView1.DataSource = dt;
					GridView1.DataBind();
				}

				//DataTable dt = new DataTable();
				//dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("Name"), new DataColumn("Country") });
				//dt.Rows.Add(1, "John Hammond", "United States");
				//dt.Rows.Add(2, "Mudassar Khan", "India");
				//dt.Rows.Add(3, "Suzanne Mathews", "France");
				//dt.Rows.Add(4, "Robert Schidner", "Russia");
				//GridView1.DataSource = dt;
				//GridView1.DataBind();
			}
		}
	}
}