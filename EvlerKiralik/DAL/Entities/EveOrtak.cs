using System;
using System.Collections.Generic;

namespace EvlerKiralik.DAL.Entities;

public partial class EveOrtak
{
    public int IlanId { get; set; }

    public string? IlanAdi { get; set; }

    public int? UserId { get; set; }

    public DateOnly? IlanDate { get; set; }

    public string? IlAdi { get; set; }

    public string? IlceAdi { get; set; }

    public string? MahalleAdi { get; set; }

    public string? KiraTutari { get; set; }

    public string? PaylasimliOda { get; set; }

    public string? OdaSayisi { get; set; }

    public string? BulunduguKat { get; set; }

    public string? BinaYasi { get; set; }

    public string? Balkon { get; set; }

    public string? Aciklama { get; set; }

    public string? ArananCinsiyet { get; set; }

    public string? IsOgrenci { get; set; }

    public bool? IsBoosted { get; set; }

    public string? EvTip { get; set; }

    public bool? IsApproved { get; set; }
}
