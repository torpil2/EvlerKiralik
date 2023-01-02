using System;
using System.Collections.Generic;

namespace EvlerKiralik.DAL.Entities;

public partial class KirayaVerme
{
    public int IlanId { get; set; }

    public string? IlanAdi { get; set; }

    public int? UserId { get; set; }

    public DateTime? IlanDate { get; set; }

    public string? IlanIl { get; set; }

    public string? IlanMahalle { get; set; }

    public string? IlanSokak { get; set; }

    public string? M2Brut { get; set; }

    public string? M2Net { get; set; }

    public string? OdaSayisi { get; set; }

    public string? BinaYasi { get; set; }

    public string? BulunduguKat { get; set; }

    public string? IsitmaTuru { get; set; }

    public string? BanyoSayisi { get; set; }

    public string? Balkon { get; set; }

    public string? Esyali { get; set; }

    public string? SiteIcerisinde { get; set; }

    public string? Aidat { get; set; }

    public string? Kimden { get; set; }

    public string? OdemeTuru { get; set; }

    public string? KiraTutari { get; set; }

    public string? KomisyonTutari { get; set; }

    public string? Aciklama { get; set; }

    public string? BoostTip { get; set; }

    public string? EvTip { get; set; }

    public string? ToplamKat { get; set; }

    public string? IlanIlce { get; set; }

    public bool? IsApproved { get; set; }

    public string? IlanTuru { get; set; }

    public string? KiralamaDonemi { get; set; }

    public string? MinimumSure { get; set; }
}
