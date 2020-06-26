using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AsyncRetry
{
    public class CommonDataAccess
    {
        private const string ConnectionString = @"data source=SRILANKA\DANNYMSSQL;initial catalog=SampleDB;persist security info=True;Integrated Security=SSPI;";

        public async Task<DataTable> GetDataTableUsingDataAdapter()
        {
            Logger.Log("GetDataTableUsingDataAdapter before connection creation");
            //initialize and open connection
            await using var connection = new SqlConnection(ConnectionString);
            Logger.Log("GetDataTableUsingDataAdapter after connection creation, before connection open");
            await connection.OpenAsync();
            Logger.Log("GetDataTableUsingDataAdapter after open connection, before command creation");

            //create the SQL command
            await using var command = new SqlCommand("Select_Products_By_Cost", connection) { CommandType = CommandType.StoredProcedure };
            Logger.Log("GetDataTableUsingDataAdapter after command creation, before table fill");

            //Add input parameters to the SQL command
            command.Parameters.Add(new SqlParameter("@Cost", SqlDbType.Money));
            command.Parameters["@Cost"].Value = 20;

            //fill the data table asynchronously using a data adapter
            var table = await AdoUtilities.FillAsync(command);
            Logger.Log("GetDataTableUsingDataAdapter after table fill using adapter");

            return table;
        }

        public async Task<DataTable> GetDataTableUsingDataReader()
        {
            Logger.Log("GetDataTableUsingDataReader before connection creation");
            //initialize and open connection
            await using var connection = new SqlConnection(ConnectionString);
            Logger.Log("GetDataTableUsingDataReader after connection creation, before connection open");
            await connection.OpenAsync();
            Logger.Log("GetDataTableUsingDataReader after open connection, before command creation");

            //create the SQL command
            await using var command = new SqlCommand("Select_Products_By_Cost", connection) { CommandType = CommandType.StoredProcedure };
            Logger.Log("GetDataTableUsingDataReader after command creation, before table fill");

            //Add input parameters to the SQL command
            command.Parameters.Add(new SqlParameter("@Cost", SqlDbType.Money));
            command.Parameters["@Cost"].Value = 10;

            //fill the data table asynchronously using a data reader
            var reader = await command.ExecuteReaderAsync();
            Logger.Log("GetDataTableUsingDataReader after command execution");
            var table = new DataTable();
            table.Load(reader);
            Logger.Log("GetDataTableUsingDataReader after table fill using reader");
            return table;
        }
    }
}
