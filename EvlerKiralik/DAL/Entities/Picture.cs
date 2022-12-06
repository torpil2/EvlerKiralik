using System;
using System.Collections.Generic;

namespace EvlerKiralik.DAL.Entities;

public partial class Picture
{
    public int ResimId { get; set; }

    public string? ResimPath { get; set; }

    public int? UserId { get; set; }

    public int? PostId { get; set; }

    public bool? IsKapak { get; set; }

    public int? ResimSira { get; set; }

    public DateOnly? UploadDate { get; set; }

    public string? ResimName { get; set; }

    public bool? IsProfile { get; set; }
}
