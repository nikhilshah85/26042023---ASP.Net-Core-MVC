using System;
using System.Collections.Generic;

namespace clientManagementMVC_DI.Models.EF;

public partial class ClientInfo
{
    public int Clientid { get; set; }

    public string? ClientName { get; set; }

    public string? ClientLocation { get; set; }

    public int? ProjectValue { get; set; }

    public bool? ClientIsActive { get; set; }
}
