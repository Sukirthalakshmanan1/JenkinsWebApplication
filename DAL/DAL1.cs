using BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL1
    {
        public bool Insert(Pizza school)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=Order_pizza;Integrated Security=True");

            SqlCommand cmdInsert = new SqlCommand("insert into Pizza(Order_id,Food_name,Cost) values(@Order_id,@Food_name,@Cost)", cn);
            cmdInsert.Parameters.AddWithValue("@Order_id", school.Order_id);
            cmdInsert.Parameters.AddWithValue("@Food_name", school.Food_name);
            cmdInsert.Parameters.AddWithValue("@cost", school.Cost);
            




            cn.Open();
            int i = cmdInsert.ExecuteNonQuery();

            bool status = false;

            if (i == 1)
            {
                status = true;
            }

            cn.Close();//finally
            cn.Dispose();//finally
            return status;



        }
        public bool Update(Pizza school)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=Order_pizza;Integrated Security=True");

           

            SqlCommand cmdUpdate = new SqlCommand("[dbo].[Update]", cn);

            cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            cmdUpdate.Parameters.AddWithValue("@p_id", school.Order_id);
            cmdUpdate.Parameters.AddWithValue("@p_name", school.Food_name);
            cmdUpdate.Parameters.AddWithValue("@p_cost", school.Cost);
            

            cn.Open();
            int s = cmdUpdate.ExecuteNonQuery();
            bool statusd = false;
            if (s == 1)
            {
                statusd = true;
            }
            cn.Close();//finally
            cn.Dispose();//finally
            return statusd;

        }

        public Pizza Find(int id)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=Order_pizza;Integrated Security=True");

            SqlCommand cmdSelect = new SqlCommand("[dbo].sp_Find", cn);
            cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelect.Parameters.AddWithValue("@p_id", id);

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@p_name";
            p1.SqlDbType = System.Data.SqlDbType.NVarChar;
            p1.Size = 10;
            p1.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p1);


            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@p_cost";
            p2.SqlDbType = System.Data.SqlDbType.Int;
            p2.Size = 20;
            p2.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p2);



            

            cn.Open();
            cmdSelect.ExecuteNonQuery();

           Pizza found = new Pizza();

            found.Food_name = p1.Value.ToString();
            found.Cost = Convert.ToInt32(p2.Value);
        




            cn.Close();
            cn.Dispose();


            return found;



        }
        public List<Pizza> List()
        {

            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=Order_pizza;Integrated Security=True");


            SqlCommand cmdlist = new SqlCommand("select Order_id,Food_name,Cost from Pizza", cn);

            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<Pizza> emplist = new List<Pizza>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Pizza bal = new Pizza();
                    bal.Order_id = Convert.ToInt32(dr["Order_id"]);
                    bal.Food_name = dr["Food_name"].ToString();
                    bal.Cost = Convert.ToInt32(dr["Cost"]);
                   

                    emplist.Add(bal);
                }
            }
            cn.Close();
            cn.Dispose();
            return emplist;

        }
        public bool Delete(int stuid)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=Order_pizza;Integrated Security=True");

            SqlCommand cmdDelete = new SqlCommand("[dbo].sp_Delete", cn);
            cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
            cmdDelete.Parameters.AddWithValue("@p_id", stuid);
            cn.Open();
            int i = cmdDelete.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();//finally
            cn.Dispose();//finally
            return status;

        }
    }
    }
