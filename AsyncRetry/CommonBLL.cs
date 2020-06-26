using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncRetry
{
    public class CommonBll
    {
        private readonly CommonDataAccess _dal;

        public CommonBll()
        {
            _dal = new CommonDataAccess();
        }

        public async Task<DataTable[]> GetDataFromDal()
        {
            Task<DataTable[]> taskManager = null;
            try
            {
                Logger.Log("GetDataFromDal before coolie initialization");
                var taskCoolie1 = _dal.GetDataTableUsingDataAdapter();
                var taskCoolie2 = _dal.GetDataTableUsingDataReader();
                Logger.Log("GetDataFromDal after coolie initialization");
                taskManager = Task.WhenAll(taskCoolie1, taskCoolie2);
                Logger.Log("GetDataFromDal after coolie start before await");
                await taskManager;
                Logger.Log("GetDataFromDal after coolie start after await");
            }
            catch (Exception mainEx)
            {
                Console.WriteLine($"Exception: {mainEx.Message}");
                if (taskManager?.Exception?.InnerExceptions.Any() ?? false)
                {
                    foreach (var innerEx in taskManager.Exception.InnerExceptions)
                    {
                        Console.WriteLine(innerEx.Message);
                    }
                }
            }

            return taskManager?.Result;
        }
    }
}
