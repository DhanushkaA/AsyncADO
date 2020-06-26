using System;
using System.Threading.Tasks;

namespace AsyncRetry
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var bll = new CommonBll();
                Logger.Log("Main before BLL call");
                var spData = await bll.GetDataFromDal();
                Logger.Log("Main after BLL call");
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
