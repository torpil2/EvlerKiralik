using System;
using System.Collections.Generic;

namespace EvlerKiralik.DAL.Entities;

public partial class CouponsDefine
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? DiscountType { get; set; }

    public string? DiscountValue { get; set; }

    public DateOnly? ExpireDate { get; set; }
}
