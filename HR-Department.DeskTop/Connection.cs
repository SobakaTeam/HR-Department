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
    internal class Connection
    {
        HttpClient client = new HttpClient();
        Client.BaseAddress = new Uri("http://example.com/");
    }
}
