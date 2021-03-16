using System;
using System.Data;

namespace daxcli
{
    class Program
    {
        static void Main(string[] args)
        {
            var connString = "Data Source=.;Catalog=WorldWideImportersTAB;";

            var dax = new Dax(connString);

            var query = 
@"DEFINE 
VAR SelectedColors =
FILTER(
	ALL( 'Item'[Color] ),
	'Item'[Color] IN { ""Red"", ""Green"" }
)

EVALUATE
CALCULATETABLE(
    'Item',
    SelectedColors
)";

            var dt = dax.Query(query);

            dax.Display(dt);
            Console.WriteLine($"Rows returned: {dt.Rows.Count}");
        }
    }
}
