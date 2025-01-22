using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HR_Department.DeskTop
{
    public class Connection
    {
        private static HttpClient sharedClient = new()
        {
            BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),

        };
       
    }
}
