using System;
using System.Collections.Generic;

namespace MVC_webapi.Models.EF;

public partial class ClientInfo
{
    public int ClientId { get; set; }

    public string? ClientName { get; set; }

    public string? FundsAvailable { get; set; }

    public string? ClientEmail { get; set; }
}
