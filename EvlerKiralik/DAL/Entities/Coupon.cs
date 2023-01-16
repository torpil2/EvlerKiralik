using System;
using System.Collections.Generic;

namespace EvlerKiralik.DAL.Entities;

public partial class Coupon
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? IsUnique { get; set; }

    public int? UserId { get; set; }

    public string? Code { get; set; }

    public string? DiscountType { get; set; }

    public string? DiscountValue { get; set; }

    public DateTime? ExpiresDate { get; set; }

    public bool? UsedCheck { get; set; }
}
