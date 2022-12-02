using System;
using System.Collections.Generic;

namespace EvlerKiralik.DAL.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserMail { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string? UserPicture { get; set; }

    public DateOnly? LastLogin { get; set; }

    public string? UserType { get; set; }
}
