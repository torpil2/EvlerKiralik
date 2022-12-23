using System;
using System.Collections.Generic;

namespace EvlerKiralik.DAL.Entities;

public partial class Comment
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public int? Rating { get; set; }

    public int? UserId { get; set; }

    public int? PostId { get; set; }

    public DateOnly? CreatedTime { get; set; }

    public int? Createdby { get; set; }
}
