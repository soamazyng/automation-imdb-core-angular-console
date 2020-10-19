using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automation.imdb.bot
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var conn = new SqlConnection("Server=DESKTOP-VKFH9QA;Database=imdbAutomation;Trusted_Connection=True;"))
            using (var command = new SqlCommand("spTest", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                var result = command.ExecuteReader();
            }
        }
    }
}
