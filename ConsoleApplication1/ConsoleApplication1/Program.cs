using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace ConsoleApplication1
{
    class Program
    {
       
        static void Main(string[] args)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connStr);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            CloudTable table = client.GetTableReference("employee");
        
            TableQuery<message> query = new TableQuery<message>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal,"2"));
            foreach (message entity in table.ExecuteQuery(query))
            {
                Console.WriteLine("{0}, {1}\t{2}\t{3}", entity.PartitionKey, entity.RowKey,
                    entity.Id, entity.Name,entity.Last);
                Console.WriteLine("Press enter to close...");
                Console.ReadLine();
            }
        }

           
    }
    }

