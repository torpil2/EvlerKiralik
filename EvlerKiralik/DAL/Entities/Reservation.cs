using System;
using System.Collections.Generic;

namespace EvlerKiralik.DAL.Entities;

public partial class Reservation
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? PostId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? DiscountCoupon { get; set; }

    public decimal? TotalPrice { get; set; }

    public bool? PayCheck { get; set; }

    public DateOnly? ReservationDate { get; set; }
}
