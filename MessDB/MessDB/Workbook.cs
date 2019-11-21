using System.Collections.Generic;

namespace MessDB
{
    internal class Workbook
    {
        public IEnumerable<Worksheet> Sheets { get; internal set; }
    }
}