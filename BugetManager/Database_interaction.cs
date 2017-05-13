using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

namespace BugetManager
{
	public class Database_interaction
	{
		public Database_interaction()
		{
		}

		public void AddCost(Cost cost)
		{
			//addto database using cost
			string connectionString = "Data Source=148.72.232.166;Integrated Security=False;User ID=q512102932;password=334573gong;Connect Timeout=15;Encrypt=False;Packet Size=4096";
			SqlConnection con = new SqlConnection(connectionString);
			try
			{
				con.Open();

				string sqlQuery = "insert into SIT305Cost Values('"+cost.CostName+"',"+cost.CostValue+",'"+cost.CostType+"','"+cost.CostDate+"','"+cost.CostDetails+"')";
				SqlCommand comm = new SqlCommand(sqlQuery, con);
				SqlDataReader dr = comm.ExecuteReader();
				dr.Close();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				con.Close();
				con.Dispose();
			}
		}
		public void AddBudget(Budget budget)
		{
			//add to database 
			Budget budget2;
			if (DetectBudget(budget, out budget2) == false)
			{

				string connectionString = "Data Source=148.72.232.166;Integrated Security=False;User ID=q512102932;password=334573gong;Connect Timeout=15;Encrypt=False;Packet Size=4096";
				SqlConnection con = new SqlConnection(connectionString);
				try
				{
					con.Open();

					string sqlQuery = "insert into SIT305Budget values (" + budget.BudgetAmount + ",'" + budget.BudgetTime + "','" + budget.BudgetPurpose + "')";
					SqlCommand comm = new SqlCommand(sqlQuery, con);
					SqlDataReader dr = comm.ExecuteReader();
					dr.Close();
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
				finally
				{
					con.Close();
					con.Dispose();
				}
			}
			else
			{
string connectionString = "Data Source=148.72.232.166;Integrated Security=False;User ID=q512102932;password=334573gong;Connect Timeout=15;Encrypt=False;Packet Size=4096";
SqlConnection con = new SqlConnection(connectionString);
				try
				{
					con.Open();

					string sqlQuery = "Update SIT305Budget set BudgetAmount="+budget.BudgetAmount+" where BudgetTime='"+budget2.BudgetTime+"'";
					SqlCommand comm = new SqlCommand(sqlQuery, con);
					SqlDataReader dr = comm.ExecuteReader();
					dr.Close();
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
				finally
				{
					con.Close();
					con.Dispose();
				}
			}

		}

		private bool DetectBudget( Budget budget,out Budget budget2)
		{
string connectionString = "Data Source=148.72.232.166;Integrated Security=False;User ID=q512102932;password=334573gong;Connect Timeout=15;Encrypt=False;Packet Size=4096";
			SqlConnection con=null;
			try
			{
 con= new SqlConnection(connectionString);
				con.Open();

				string sqlQuery = "select * from SIT305Budget";

				SqlCommand comm = new SqlCommand(sqlQuery, con);
				SqlDataReader dr = comm.ExecuteReader();
				while (dr.Read())
				{
					float budgetvalue =float.Parse( dr.GetDouble(0).ToString());
					DateTime budgettime =DateTime.Parse( dr.GetString(1));
					string budgetdescription = dr.GetString(2);

					if (budget.BudgetTime.Year == budgettime.Year && budget.BudgetTime.Month == budgettime.Month)
					{
						dr.Close();
						con.Close();
						con.Dispose();

						budget2 = new Budget(budgetvalue, budgettime);

						return true;
					}
				}



				dr.Close();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				con.Close();
				con.Dispose();

			}
			budget2 = null;
			return false;
		}
		public List<Cost> GetCostList(DateTime time)
		{
			List<Cost> costlist = new List<Cost>();
string connectionString = "Data Source=148.72.232.166;Integrated Security=False;User ID=q512102932;password=334573gong;Connect Timeout=15;Encrypt=False;Packet Size=4096";
SqlConnection con = new SqlConnection(connectionString);
			try
			{
				con.Open();

				string sqlQuery = "select * from SIT305Cost";
				SqlCommand comm = new SqlCommand(sqlQuery, con);
				SqlDataReader dr = comm.ExecuteReader();
				while (dr.Read())
				{
					if (DateTime.Parse(dr.GetString(3)).Year == time.Year && DateTime.Parse(dr.GetString(3)).Month == time.Month)
					{
						costlist.Add(new Cost(dr.GetString(0), float.Parse(dr.GetDouble(1).ToString()), dr.GetString(2), DateTime.Parse(dr.GetString(3)), dr.GetString(4)));
					}
				}
				dr.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				con.Close();
				con.Dispose();
			}

			return costlist;
		}
		public Budget GetBudget(DateTime time)
		{
string connectionString = "Data Source=148.72.232.166;Integrated Security=False;User ID=q512102932;password=334573gong;Connect Timeout=15;Encrypt=False;Packet Size=4096";
SqlConnection con = new SqlConnection(connectionString);
			try
			{
				con.Open();

				string sqlQuery = "select * from SIT305Budget";
SqlCommand comm = new SqlCommand(sqlQuery, con);
SqlDataReader dr = comm.ExecuteReader();
				while (dr.Read())
				{
					if (DateTime.Parse(dr.GetString(1)).Year == time.Year && DateTime.Parse(dr.GetString(1)).Month == time.Month)
					{
						Budget budget = new Budget(float.Parse(dr.GetDouble(0).ToString()), DateTime.Parse(dr.GetString(1)));
						dr.Close();
						con.Close();
						con.Dispose();

						return budget;
					}
				}
				dr.Close();
				
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				con.Close();
				con.Dispose();
			}
			return null;
		}
		public float GetTotalCostMonth(DateTime time)
		{
			List<Cost> costlist = this.GetCostList(time);
			float totalcost = 0;
			if (costlist != null)
			{
				foreach (Cost c in costlist)
				{
					totalcost += c.CostValue;
				}
			}
			return totalcost;
		}
	}
}
