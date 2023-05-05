using System;
using System.Collections.Generic;

namespace bankingSolution.Models.EF;

public partial class AccountsInfo
{
    public int AccNo { get; set; }

    public string? AccName { get; set; }

    public string? AccType { get; set; }

    public int? AccBalance { get; set; }

    public bool? AccIsActive { get; set; }

    public string? AccLastName { get; set; }
}
