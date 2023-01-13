using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EvlerKiralik.DAL.Entities;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BalkonSayi> BalkonSayis { get; set; }

    public virtual DbSet<BanyoSayi> BanyoSayis { get; set; }

    public virtual DbSet<BinaYasi> BinaYasis { get; set; }

    public virtual DbSet<BoostTip> BoostTips { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<CouponsDefine> CouponsDefines { get; set; }

    public virtual DbSet<DaireKat> DaireKats { get; set; }

    public virtual DbSet<EvTip> EvTips { get; set; }

    public virtual DbSet<EveOrtak> EveOrtaks { get; set; }

    public virtual DbSet<Favourite> Favourites { get; set; }

    public virtual DbSet<Ilceler> Ilcelers { get; set; }

    public virtual DbSet<Iller> Illers { get; set; }

    public virtual DbSet<IsEsyali> IsEsyalis { get; set; }

    public virtual DbSet<IsinSite> IsinSites { get; set; }

    public virtual DbSet<IsitmaTur> IsitmaTurs { get; set; }

    public virtual DbSet<Kimden> Kimdens { get; set; }

    public virtual DbSet<KirayaVerme> KirayaVermes { get; set; }

    public virtual DbSet<Mahalleler> Mahallelers { get; set; }

    public virtual DbSet<OdaSayisi> OdaSayisis { get; set; }

    public virtual DbSet<OdemeTur> OdemeTurs { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Sokaklar> Sokaklars { get; set; }

    public virtual DbSet<ToplamKat> ToplamKats { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserStatus> UserStatuses { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;port=5432;Username=postgres;Password=123456;Database=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<BalkonSayi>(entity =>
        {
            entity.HasKey(e => e.BalkonSayiId).HasName("BalkonSayi_pkey");

            entity.ToTable("BalkonSayi");

            entity.Property(e => e.BalkonSayiId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("BalkonSayi_id");
            entity.Property(e => e.BalkonSayi1).HasColumnName("BalkonSayi");
        });

        modelBuilder.Entity<BanyoSayi>(entity =>
        {
            entity.HasKey(e => e.BanyoSayiId).HasName("BanyoSayi_pkey");

            entity.ToTable("BanyoSayi");

            entity.Property(e => e.BanyoSayiId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("BanyoSayi_id");
            entity.Property(e => e.BanyoSayi1).HasColumnName("BanyoSayi");
        });

        modelBuilder.Entity<BinaYasi>(entity =>
        {
            entity.HasKey(e => e.BinaYasiId).HasName("Bina_Yasi_pkey");

            entity.ToTable("Bina_Yasi");

            entity.Property(e => e.BinaYasiId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("BinaYasi_id");
            entity.Property(e => e.BinaYasi1).HasColumnName("Bina_Yasi");
        });

        modelBuilder.Entity<BoostTip>(entity =>
        {
            entity.HasKey(e => e.BoostTipId).HasName("BoostTip_pkey");

            entity.ToTable("BoostTip");

            entity.Property(e => e.BoostTipId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("BoostTip_id");
            entity.Property(e => e.BoostTipAdi).HasColumnName("BoostTip_adi");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Comments_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CommentStatus).HasColumnName("commentStatus");
            entity.Property(e => e.CreatedTime).HasColumnName("createdTime");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Text).HasColumnName("text");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Coupons_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.DiscountType).HasColumnName("discount_type");
            entity.Property(e => e.DiscountValue).HasColumnName("discount_value");
            entity.Property(e => e.ExpiresDate).HasColumnName("expires_date");
            entity.Property(e => e.IsUnique).HasColumnName("is_unique");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UsedCheck).HasColumnName("used_check");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<CouponsDefine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Coupons_Define_pkey");

            entity.ToTable("Coupons_Define");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.DiscountType).HasColumnName("discount_type");
            entity.Property(e => e.DiscountValue).HasColumnName("discount_value");
            entity.Property(e => e.ExpireDate).HasColumnName("expire_date");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<DaireKat>(entity =>
        {
            entity.HasKey(e => e.DaireKatId).HasName("Daire_Kat_pkey");

            entity.ToTable("Daire_Kat");

            entity.Property(e => e.DaireKatId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("DaireKat_id");
            entity.Property(e => e.DaireKat1).HasColumnName("DaireKat");
        });

        modelBuilder.Entity<EvTip>(entity =>
        {
            entity.HasKey(e => e.EvTipId).HasName("EvTip_pkey");

            entity.ToTable("EvTip");

            entity.Property(e => e.EvTipId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("EvTip_id");
            entity.Property(e => e.EvTipName).HasColumnName("EvTip_name");
        });

        modelBuilder.Entity<EveOrtak>(entity =>
        {
            entity.HasKey(e => e.IlanId).HasName("Eve_Ortak_pkey");

            entity.ToTable("Eve_Ortak");

            entity.Property(e => e.IlanId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ilan_id");
            entity.Property(e => e.Aciklama).HasColumnName("aciklama");
            entity.Property(e => e.ArananCinsiyet).HasColumnName("aranan_cinsiyet");
            entity.Property(e => e.Balkon).HasColumnName("balkon");
            entity.Property(e => e.BinaYasi).HasColumnName("bina_yasi");
            entity.Property(e => e.BulunduguKat).HasColumnName("bulundugu_kat");
            entity.Property(e => e.EvTip).HasColumnName("ev_tip");
            entity.Property(e => e.IlAdi).HasColumnName("il_adi");
            entity.Property(e => e.IlanAdi)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("ilan_adi");
            entity.Property(e => e.IlanDate).HasColumnName("ilan_date");
            entity.Property(e => e.IlceAdi).HasColumnName("ilce_adi");
            entity.Property(e => e.IsBoosted).HasColumnName("is_boosted");
            entity.Property(e => e.IsOgrenci).HasColumnName("is_ogrenci");
            entity.Property(e => e.KiraTutari).HasColumnName("kira_tutari");
            entity.Property(e => e.MahalleAdi).HasColumnName("mahalle_adi");
            entity.Property(e => e.OdaSayisi).HasColumnName("oda_sayisi");
            entity.Property(e => e.PaylasimliOda).HasColumnName("paylasimli_oda");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Favourite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Favourites_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.AddDate).HasColumnName("Add_date");
            entity.Property(e => e.PostId).HasColumnName("Post_id");
            entity.Property(e => e.UserId).HasColumnName("User_id");
        });

        modelBuilder.Entity<Ilceler>(entity =>
        {
            entity.HasKey(e => e.IlceId).HasName("ilceler_pkey");

            entity.ToTable("ilceler");

            entity.Property(e => e.IlceId)
                .ValueGeneratedNever()
                .HasColumnName("ilce_id");
            entity.Property(e => e.IlAdi)
                .HasColumnType("character varying")
                .HasColumnName("il_adi");
            entity.Property(e => e.IlId).HasColumnName("il_id");
            entity.Property(e => e.IlceAdi)
                .HasColumnType("character varying")
                .HasColumnName("ilce_adi");
        });

        modelBuilder.Entity<Iller>(entity =>
        {
            entity.HasKey(e => e.IlId).HasName("iller_pkey");

            entity.ToTable("iller");

            entity.Property(e => e.IlId)
                .ValueGeneratedNever()
                .HasColumnName("il_id");
            entity.Property(e => e.İlAdi)
                .HasColumnType("character varying")
                .HasColumnName("İl_adi");
        });

        modelBuilder.Entity<IsEsyali>(entity =>
        {
            entity.HasKey(e => e.IsEsyaliId).HasName("IsEsyali_pkey");

            entity.ToTable("IsEsyali");

            entity.Property(e => e.IsEsyaliId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("IsEsyali_id");
            entity.Property(e => e.IsEsyali1).HasColumnName("IsEsyali");
        });

        modelBuilder.Entity<IsinSite>(entity =>
        {
            entity.HasKey(e => e.IsinSiteId).HasName("IsinSite_pkey");

            entity.ToTable("IsinSite");

            entity.Property(e => e.IsinSiteId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("IsinSite_id");
            entity.Property(e => e.IsinSite1).HasColumnName("IsinSite");
        });

        modelBuilder.Entity<IsitmaTur>(entity =>
        {
            entity.HasKey(e => e.IsitmaTurId).HasName("IsitmaTur_pkey");

            entity.ToTable("IsitmaTur");

            entity.Property(e => e.IsitmaTurId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("IsitmaTur_id");
            entity.Property(e => e.IsitmaTur1).HasColumnName("IsitmaTur");
        });

        modelBuilder.Entity<Kimden>(entity =>
        {
            entity.HasKey(e => e.KimdenId).HasName("Kimden_pkey");

            entity.ToTable("Kimden");

            entity.Property(e => e.KimdenId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("Kimden_id");
            entity.Property(e => e.KimdenAdi).HasColumnName("Kimden_adi");
        });

        modelBuilder.Entity<KirayaVerme>(entity =>
        {
            entity.HasKey(e => e.IlanId).HasName("Kiraya_Verme_pkey");

            entity.ToTable("Kiraya_Verme");

            entity.Property(e => e.IlanId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ilan_id");
            entity.Property(e => e.Aciklama).HasColumnName("aciklama");
            entity.Property(e => e.Aidat).HasColumnName("aidat");
            entity.Property(e => e.Balkon).HasColumnName("balkon");
            entity.Property(e => e.BanyoSayisi).HasColumnName("banyo_sayisi");
            entity.Property(e => e.BinaYasi).HasColumnName("bina_yasi");
            entity.Property(e => e.BoostTip).HasColumnName("Boost_Tip");
            entity.Property(e => e.BulunduguKat).HasColumnName("bulundugu_kat");
            entity.Property(e => e.Esyali).HasColumnName("esyali");
            entity.Property(e => e.EvTip).HasColumnName("ev_tip");
            entity.Property(e => e.IlanAdi).HasColumnName("ilan_adi");
            entity.Property(e => e.IlanDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ilan_date");
            entity.Property(e => e.IlanIl).HasColumnName("ilan_il");
            entity.Property(e => e.IlanIlce).HasColumnName("ilan_ilce");
            entity.Property(e => e.IlanMahalle).HasColumnName("ilan_mahalle");
            entity.Property(e => e.IlanSokak).HasColumnName("ilan_sokak");
            entity.Property(e => e.IlanTuru).HasColumnName("Ilan_Turu");
            entity.Property(e => e.IsitmaTuru).HasColumnName("isitma_turu");
            entity.Property(e => e.Kimden).HasColumnName("kimden");
            entity.Property(e => e.KiraTutari).HasColumnName("kira_tutari");
            entity.Property(e => e.KiralamaDonemi).HasColumnName("Kiralama_Donemi");
            entity.Property(e => e.KomisyonTutari).HasColumnName("komisyon_tutari");
            entity.Property(e => e.M2Brut).HasColumnName("m2_brut");
            entity.Property(e => e.M2Net).HasColumnName("m2_net");
            entity.Property(e => e.MinimumSure).HasColumnName("minimum_sure");
            entity.Property(e => e.OdaSayisi).HasColumnName("oda_sayisi");
            entity.Property(e => e.OdemeTuru).HasColumnName("odeme_turu");
            entity.Property(e => e.SiteIcerisinde).HasColumnName("site_icerisinde");
            entity.Property(e => e.ToplamKat).HasColumnName("toplam_kat");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Mahalleler>(entity =>
        {
            entity.HasKey(e => e.MahalleId).HasName("mahalleler_pkey");

            entity.ToTable("mahalleler");

            entity.Property(e => e.MahalleId)
                .ValueGeneratedNever()
                .HasColumnName("mahalle_id");
            entity.Property(e => e.IlAdi)
                .HasColumnType("character varying")
                .HasColumnName("il_adi");
            entity.Property(e => e.IlId).HasColumnName("il_id");
            entity.Property(e => e.IlceAdi)
                .HasColumnType("character varying")
                .HasColumnName("ilce_adi");
            entity.Property(e => e.IlceId).HasColumnName("ilce_id");
            entity.Property(e => e.MahalleAdi)
                .HasColumnType("character varying")
                .HasColumnName("mahalle_adi");
        });

        modelBuilder.Entity<OdaSayisi>(entity =>
        {
            entity.HasKey(e => e.OdaSayisiId).HasName("Oda_Sayisi_pkey");

            entity.ToTable("Oda_Sayisi");

            entity.Property(e => e.OdaSayisiId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("OdaSayisi_id");
            entity.Property(e => e.OdaSayisi1).HasColumnName("OdaSayisi");
        });

        modelBuilder.Entity<OdemeTur>(entity =>
        {
            entity.HasKey(e => e.OdemeTurId).HasName("OdemeTur_pkey");

            entity.ToTable("OdemeTur");

            entity.Property(e => e.OdemeTurId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("OdemeTur_id");
            entity.Property(e => e.OdemeTurName).HasColumnName("OdemeTur_name");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.HasKey(e => e.ResimId).HasName("Picture_pkey");

            entity.ToTable("Picture");

            entity.Property(e => e.ResimId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("resim_id");
            entity.Property(e => e.IsKapak).HasColumnName("is_kapak");
            entity.Property(e => e.IsProfile).HasColumnName("is_profile");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.ResimName).HasColumnName("resim_name");
            entity.Property(e => e.ResimPath).HasColumnName("resim_path");
            entity.Property(e => e.ResimSira).HasColumnName("resim_sira");
            entity.Property(e => e.UploadDate).HasColumnName("upload_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reservation_pkey");

            entity.ToTable("reservation");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.DiscountCoupon).HasColumnName("discount_coupon");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.PayCheck).HasColumnName("payCheck");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.ReservationDate).HasColumnName("reservation_date");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.TotalPrice).HasColumnName("total_price");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Sokaklar>(entity =>
        {
            entity.HasKey(e => e.SokakId).HasName("sokaklar_pkey");

            entity.ToTable("sokaklar");

            entity.Property(e => e.SokakId)
                .ValueGeneratedNever()
                .HasColumnName("sokak_id");
            entity.Property(e => e.IlAdi)
                .HasColumnType("character varying")
                .HasColumnName("il_adi");
            entity.Property(e => e.IlId).HasColumnName("il_id");
            entity.Property(e => e.IlceAdi)
                .HasColumnType("character varying")
                .HasColumnName("ilce_adi");
            entity.Property(e => e.IlceId).HasColumnName("ilce_id");
            entity.Property(e => e.MahalleAdi)
                .HasColumnType("character varying")
                .HasColumnName("mahalle_adi");
            entity.Property(e => e.MahalleId).HasColumnName("mahalle_id");
            entity.Property(e => e.SokakAdi)
                .HasColumnType("character varying")
                .HasColumnName("sokak_adi");
        });

        modelBuilder.Entity<ToplamKat>(entity =>
        {
            entity.HasKey(e => e.ToplamKatId).HasName("ToplamKat_pkey");

            entity.ToTable("ToplamKat");

            entity.Property(e => e.ToplamKatId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ToplamKat_id");
            entity.Property(e => e.ToplamKatAdi).HasColumnName("ToplamKat_adi");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("Users_pkey");

            entity.Property(e => e.UserId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("user_id");
            entity.Property(e => e.LastLogin).HasColumnName("last_login");
            entity.Property(e => e.UserMail).HasColumnName("user_mail");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("user_name");
            entity.Property(e => e.UserPassword).HasColumnName("user_password");
            entity.Property(e => e.UserPicture).HasColumnName("user_picture");
            entity.Property(e => e.UserStatus).HasColumnName("user_status");
            entity.Property(e => e.UserType).HasColumnName("user_type");
        });

        modelBuilder.Entity<UserStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_Status_pkey");

            entity.ToTable("User_Status");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.UserTypeId).HasName("UserTypes_pkey");

            entity.Property(e => e.UserTypeId).UseIdentityAlwaysColumn();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
