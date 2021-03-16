using Microsoft.AnalysisServices.AdomdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daxcli
{
    public class Dax
    {
        private string connectionString;
        public Dax(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataTable Query(string query)
        {
            var dt = new DataTable();

            using (var conn = new AdomdConnection(connectionString))
            {
                conn.Open();

                var da = new AdomdDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;

        }

        public void Display(DataTable dt)
        {
            foreach (DataColumn col in dt.Columns)
            {
                Console.Write(col.ColumnName + ", ");
            }

            Console.WriteLine();

            foreach(DataRow dr in dt.Rows)
            {
                foreach(var cell in dr.ItemArray)
                {
                    Console.Write(cell + ", ");
                }

                Console.WriteLine();
            }
        }
    }
}
