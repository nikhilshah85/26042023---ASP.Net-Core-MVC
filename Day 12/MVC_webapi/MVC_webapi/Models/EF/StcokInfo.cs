using System;
using System.Collections.Generic;

namespace MVC_webapi.Models.EF;

public partial class StcokInfo
{
    public int StockId { get; set; }

    public string? StockName { get; set; }

    public int? StockPrice { get; set; }

    public int? StockQty { get; set; }
}
