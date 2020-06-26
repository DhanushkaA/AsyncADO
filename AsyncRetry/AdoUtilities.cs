using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AsyncRetry
{
    public class AdoUtilities
    {
        public static async Task<DataTable> FillAsync(SqlCommand command)
        {
            return await Task.Run(() => FillTable(command));
        }

        private static DataTable FillTable(SqlCommand command)
        {
            var table = new DataTable();
            using var adapter = new SqlDataAdapter(command);
            adapter.Fill(table);

            return table;
        }
    }
}
