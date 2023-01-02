using System;
using System.Collections.Generic;

namespace EvlerKiralik.DAL.Entities;

public partial class Favourite
{
    public int Id { get; set; }

    public int? PostId { get; set; }

    public int? UserId { get; set; }

    public DateOnly? AddDate { get; set; }
}
