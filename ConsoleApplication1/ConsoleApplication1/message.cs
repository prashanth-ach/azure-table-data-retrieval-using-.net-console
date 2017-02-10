    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.StorageClient;
    using Microsoft.WindowsAzure.Storage.Table;

namespace ConsoleApplication1

{
        public class message : TableEntity
        {
            public message()
            {
            }
            public message(int id, string name, string last)
            {
                Id = id;
                Name = name;
                Last = last;
                PartitionKey = id.ToString();
                RowKey = name;
            }
            public int Id { get; set; }
            public string Name { get; set; }
            public string Last { get; set; }
        }
    }
