using System;
using System.Collections.Generic;

namespace EvlerKiralik.DAL.Entities;

public partial class Ilceler
{
    public int IlceId { get; set; }

    public string? IlceAdi { get; set; }

    public int? IlId { get; set; }

    public string? IlAdi { get; set; }
}
