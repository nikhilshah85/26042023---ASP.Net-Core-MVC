using System;
using System.Collections.Generic;

namespace bankingSolution.Models.EF;

public partial class BranchInfo
{
    public int BrNo { get; set; }

    public string? BrName { get; set; }

    public string? BrCity { get; set; }
}
