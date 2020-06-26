using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AsyncRetry
{
    public class CommonDataAccess
    {
        private readonly string strDBConnectionString = "Server=192.168.0.205;User Id=xpert36;pwd=xpert36;database=36_XpertEMR;";
        public async Task<DataTable> GetDataTableFromSP1()
        {
            await using SqlConnection cnn = new SqlConnection(strDBConnectionString);
            await cnn.OpenAsync();
            await using var cmd = new SqlCommand("usp_Billing_Get", cnn) { CommandType = CommandType.StoredProcedure };

            //Add input parameters
            cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
            cmd.Parameters["@ID"].Value = 1;
            cmd.Parameters.Add(new SqlParameter("@loggedUserID", SqlDbType.Int));
            cmd.Parameters["@loggedUserID"].Value = 1;
            cmd.Parameters.Add(new SqlParameter("@return", SqlDbType.Int));
            cmd.Parameters["@return"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add(new SqlParameter("@errorID", SqlDbType.Int));
            cmd.Parameters["@errorID"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add(new SqlParameter("@errorMessage", SqlDbType.VarChar, -1));
            cmd.Parameters["@errorMessage"].Direction = ParameterDirection.Output;

            var dt = new DataTable();
            using (var sdAdapter = new SqlDataAdapter(cmd))
            {
                sdAdapter.Fill(dt);
            }

            if (!string.IsNullOrWhiteSpace(cmd.Parameters["@return"].Value?.ToString()) && Convert.ToInt16(cmd.Parameters["@return"].Value) < 0)
            {
                throw new Exception(cmd.Parameters["@errorMessage"].Value?.ToString());
            }

            return dt;
        }

        public async Task<DataTable> GetDataTableFromSP2()
        {
            DataTable dt = null;
            try
            {
                //Create Connection
                using (SqlConnection cnn = new SqlConnection(strDBConnectionString))
                {

                    //open Connection
                    await cnn.OpenAsync();
                    //Create Command
                    using (SqlCommand cmd = new SqlCommand("usp_Billing_Get", cnn))
                    {

                        //Specify Command type
                        cmd.CommandType = CommandType.StoredProcedure;


                        //**********REGULAR OUT PUT PARAMETERS BLOCK END***************

                        //**********REGULAR OUT PUT PARAMETERS BLOCK END***************
                        //Add input parameters
                        cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                        cmd.Parameters["@ID"].Value = 2;
                        cmd.Parameters.Add(new SqlParameter("@loggedUserID", SqlDbType.Int));
                        cmd.Parameters["@loggedUserID"].Value = 1;

                        cmd.Parameters.Add(new SqlParameter("@return", SqlDbType.Int));
                        cmd.Parameters["@return"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add(new SqlParameter("@errorID", SqlDbType.Int));
                        cmd.Parameters["@errorID"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add(new SqlParameter("@errorMessage", SqlDbType.VarChar, -1));
                        cmd.Parameters["@errorMessage"].Direction = ParameterDirection.Output;


                        dt = new DataTable();
                        using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                        {
                            //sdAdapter.Fill(dt);
                            sdAdapter.Fill(dt);
                        }

                        if (!string.IsNullOrWhiteSpace(cmd.Parameters["@return"].Value?.ToString()) && Convert.ToInt16(cmd.Parameters["@return"].Value) < 0)
                        {
                            throw new Exception(cmd.Parameters["@errorMessage"].Value?.ToString());
                        }


                        //Closing connection


                    }
                }
            }
            finally
            {

            }
            return dt;
        }

        public async Task<DataTable> GetDataTableFromSP3()
        {
            DataTable dt = null;
            try
            {
                //Create Connection
                using (SqlConnection cnn = new SqlConnection(strDBConnectionString))
                {

                    //open Connection
                    await cnn.OpenAsync();
                    //Create Command
                    using (SqlCommand cmd = new SqlCommand("usp_Billing_Get", cnn))
                    {
                        //Specify Command type
                        cmd.CommandType = CommandType.StoredProcedure;


                        //**********REGULAR OUT PUT PARAMETERS BLOCK END***************

                        //**********REGULAR OUT PUT PARAMETERS BLOCK END***************
                        //Add input parameters

                        cmd.Parameters.Add(new SqlParameter("@loggedUserID", SqlDbType.Int));
                        cmd.Parameters["@loggedUserID"].Value = 1;

                        cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                        cmd.Parameters["@ID"].Value = 3;

                        cmd.Parameters.Add(new SqlParameter("@return", SqlDbType.Int));
                        cmd.Parameters["@return"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add(new SqlParameter("@errorID", SqlDbType.Int));
                        cmd.Parameters["@errorID"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add(new SqlParameter("@errorMessage", SqlDbType.VarChar, -1));
                        cmd.Parameters["@errorMessage"].Direction = ParameterDirection.Output;


                        dt = new DataTable();
                        using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                        {
                            //sdAdapter.Fill(dt);
                            sdAdapter.Fill(dt);
                        }

                        if (!string.IsNullOrWhiteSpace(cmd.Parameters["@return"].Value?.ToString()) && Convert.ToInt16(cmd.Parameters["@return"].Value) < 0)
                        {
                            throw new Exception(cmd.Parameters["@errorMessage"].Value?.ToString());
                        }


                        //Closing connection


                    }
                }
            }
            finally
            {

            }
            return dt;
        }

        public async Task<DataTable> GetDataTableFromSP4()
        {
            DataTable dt = null;
            try
            {
                //Create Connection
                using (SqlConnection cnn = new SqlConnection(strDBConnectionString))
                {

                    //open Connection
                    await cnn.OpenAsync();
                    //Create Command
                    using (SqlCommand cmd = new SqlCommand("usp_Billing_Get", cnn))
                    {
                        //Specify Command type
                        cmd.CommandType = CommandType.StoredProcedure;


                        //**********REGULAR OUT PUT PARAMETERS BLOCK END***************

                        //**********REGULAR OUT PUT PARAMETERS BLOCK END***************
                        //Add input parameters

                        cmd.Parameters.Add(new SqlParameter("@loggedUserID", SqlDbType.Int));
                        cmd.Parameters["@loggedUserID"].Value = 1;

                        cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                        cmd.Parameters["@ID"].Value = 4;

                        cmd.Parameters.Add(new SqlParameter("@return", SqlDbType.Int));
                        cmd.Parameters["@return"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add(new SqlParameter("@errorID", SqlDbType.Int));
                        cmd.Parameters["@errorID"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add(new SqlParameter("@errorMessage", SqlDbType.VarChar, -1));
                        cmd.Parameters["@errorMessage"].Direction = ParameterDirection.Output;


                        dt = new DataTable();
                        using (SqlDataAdapter sdAdapter = new SqlDataAdapter(cmd))
                        {
                            //sdAdapter.Fill(dt);
                            sdAdapter.Fill(dt);
                        }

                        if (!string.IsNullOrWhiteSpace(cmd.Parameters["@return"].Value?.ToString()) && Convert.ToInt16(cmd.Parameters["@return"].Value) < 0)
                        {
                            throw new Exception(cmd.Parameters["@errorMessage"].Value?.ToString());
                        }


                        //Closing connection


                    }
                }
            }
            finally
            {

            }
            return dt;
        }
    }
}
