using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace cvProjesi.Models;

public partial class cvweb2Context : DbContext
{
    public cvweb2Context()
    {
    }

    public cvweb2Context(DbContextOptions<cvweb2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Basarilar> Basarilars { get; set; }

    public virtual DbSet<CvBasari> CvBasaris { get; set; }

    public virtual DbSet<CvDil> CvDils { get; set; }

    public virtual DbSet<CvEgitim> CvEgitims { get; set; }

    public virtual DbSet<CvI> CvIs { get; set; }

    public virtual DbSet<CvKur> CvKurs { get; set; }

    public virtual DbSet<CvOlustur> CvOlusturs { get; set; }

    public virtual DbSet<CvOzel> CvOzels { get; set; }

    public virtual DbSet<CvProfil> CvProfils { get; set; }

    public virtual DbSet<CvYetenek> CvYeteneks { get; set; }

    public virtual DbSet<Diller> Dillers { get; set; }

    public virtual DbSet<Egitimler> Egitimlers { get; set; }

    public virtual DbSet<IsDeneyimi> IsDeneyimis { get; set; }

    public virtual DbSet<KisiselBilgi> KisiselBilgi { get; set; }

    public virtual DbSet<Kurslar> Kurslars { get; set; }

    public virtual DbSet<OzelBolum> OzelBolums { get; set; }

    public virtual DbSet<Profiller> Profillers { get; set; }

    public virtual DbSet<Sablon> Sablons { get; set; }

    public virtual DbSet<YeniKayit> YeniKayits { get; set; }

    public virtual DbSet<Yetenekler> Yeteneklers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\Rumeysa ÖZGÜR\\Desktop\\cvSitesi\\cvProjesi\\cvProjesi\\Data\\cvweb2.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Basarilar>(entity =>
        {
            entity.HasKey(e => e.BasariId);

            entity.ToTable("Basarilar");

            entity.HasIndex(e => e.BasariId, "IX_Basarilar_basariId").IsUnique();

            entity.Property(e => e.BasariId).HasColumnName("basariId");
            entity.Property(e => e.Aciklama).HasColumnName("aciklama");
            entity.Property(e => e.BBasligi).HasColumnName("bBasligi");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Basarilars)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CvBasari>(entity =>
        {
            entity.ToTable("cvBasari");

            entity.HasIndex(e => e.Id, "IX_cvBasari_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BasariId).HasColumnName("basariId");
            entity.Property(e => e.KayitId).HasColumnName("kayitId");

            entity.HasOne(d => d.Basari).WithMany(p => p.CvBasaris)
                .HasForeignKey(d => d.BasariId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Kayit).WithMany(p => p.CvBasaris)
                .HasForeignKey(d => d.KayitId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CvDil>(entity =>
        {
            entity.ToTable("cvDil");

            entity.HasIndex(e => e.Id, "IX_cvDil_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DilId).HasColumnName("dilId");
            entity.Property(e => e.KayitId).HasColumnName("kayitId");

            entity.HasOne(d => d.Dil).WithMany(p => p.InverseDil)
                .HasForeignKey(d => d.DilId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Kayit).WithMany(p => p.CvDils)
                .HasForeignKey(d => d.KayitId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CvEgitim>(entity =>
        {
            entity.ToTable("cvEgitim");

            entity.HasIndex(e => e.Id, "IX_cvEgitim_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EgitimId).HasColumnName("egitimId");
            entity.Property(e => e.KayitId).HasColumnName("kayitId");

            entity.HasOne(d => d.Egitim).WithMany(p => p.CvEgitims)
                .HasForeignKey(d => d.EgitimId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Kayit).WithMany(p => p.CvEgitims)
                .HasForeignKey(d => d.KayitId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CvI>(entity =>
        {
            entity.ToTable("cvIs");

            entity.HasIndex(e => e.Id, "IX_cvIs_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Isıd).HasColumnName("isıd");
            entity.Property(e => e.KayitId).HasColumnName("kayitId");

            entity.HasOne(d => d.IsıdNavigation).WithMany(p => p.CvIs)
                .HasForeignKey(d => d.Isıd)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Kayit).WithMany(p => p.CvIs)
                .HasForeignKey(d => d.KayitId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CvKur>(entity =>
        {
            entity.ToTable("cvKurs");

            entity.HasIndex(e => e.Id, "IX_cvKurs_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.KayitId).HasColumnName("kayitId");
            entity.Property(e => e.KursId).HasColumnName("kursId");

            entity.HasOne(d => d.Kayit).WithMany(p => p.CvKurs)
                .HasForeignKey(d => d.KayitId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Kurs).WithMany(p => p.CvKurs)
                .HasForeignKey(d => d.KursId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CvOlustur>(entity =>
        {
            entity.HasKey(e => e.KayıtId);

            entity.ToTable("CvOlustur");

            entity.HasIndex(e => e.KayıtId, "IX_CvOlustur_KayıtId").IsUnique();

            entity.Property(e => e.Isler).HasColumnName("isler");
            entity.Property(e => e.OzelBolum).HasColumnName("ozelBolum");

            entity.HasOne(d => d.SablonNavigation).WithMany(p => p.CvOlusturs)
                .HasForeignKey(d => d.Sablon)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CvOzel>(entity =>
        {
            entity.ToTable("cvOzel");

            entity.HasIndex(e => e.Id, "IX_cvOzel_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.KayitId).HasColumnName("kayitId");
            entity.Property(e => e.OzelId).HasColumnName("ozelId");

            entity.HasOne(d => d.Kayit).WithMany(p => p.CvOzels)
                .HasForeignKey(d => d.KayitId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Ozel).WithMany(p => p.CvOzels)
                .HasForeignKey(d => d.OzelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CvProfil>(entity =>
        {
            entity.ToTable("cvProfil");

            entity.HasIndex(e => e.Id, "IX_cvProfil_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CvProfil1).HasColumnName("cvProfil");
            entity.Property(e => e.KayitId).HasColumnName("kayitId");

            entity.HasOne(d => d.CvProfil1Navigation).WithMany(p => p.CvProfils)
                .HasForeignKey(d => d.CvProfil1)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Kayit).WithMany(p => p.CvProfils)
                .HasForeignKey(d => d.KayitId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CvYetenek>(entity =>
        {
            entity.ToTable("cvYetenek");

            entity.HasIndex(e => e.Id, "IX_cvYetenek_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.KayitId).HasColumnName("kayitId");
            entity.Property(e => e.YetenekId).HasColumnName("yetenekId");

            entity.HasOne(d => d.Kayit).WithMany(p => p.CvYeteneks)
                .HasForeignKey(d => d.KayitId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Yetenek).WithMany(p => p.CvYeteneks)
                .HasForeignKey(d => d.YetenekId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Diller>(entity =>
        {
            entity.HasKey(e => e.DilId);

            entity.ToTable("Diller");

            entity.HasIndex(e => e.DilId, "IX_Diller_dilId").IsUnique();

            entity.Property(e => e.DilId).HasColumnName("dilId");
            entity.Property(e => e.Dil).HasColumnName("dil");
            entity.Property(e => e.Seviye).HasColumnName("seviye");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Dillers)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Egitimler>(entity =>
        {
            entity.HasKey(e => e.EgitimId);

            entity.ToTable("Egitimler");

            entity.HasIndex(e => e.EgitimId, "IX_Egitimler_EgitimId").IsUnique();

            entity.Property(e => e.BaslangicTarihi).HasColumnName("baslangicTarihi");
            entity.Property(e => e.BitisTarihi).HasColumnName("bitisTarihi");
            entity.Property(e => e.DereceSertifika).HasColumnName("dereceSertifika");
            entity.Property(e => e.EgitimAd).HasColumnName("egitimAd");
            entity.Property(e => e.EgitimTuru).HasColumnName("egitimTuru");
            entity.Property(e => e.Ilce).HasColumnName("ilce");
            entity.Property(e => e.Okul).HasColumnName("okul");
            entity.Property(e => e.Sehir).HasColumnName("sehir");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Egitimlers)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<IsDeneyimi>(entity =>
        {
            entity.HasKey(e => e.IsId);

            entity.ToTable("isDeneyimi");

            entity.HasIndex(e => e.IsId, "IX_isDeneyimi_isId").IsUnique();

            entity.Property(e => e.IsId).HasColumnName("isId");
            entity.Property(e => e.Aciklama).HasColumnName("aciklama");
            entity.Property(e => e.BaslangicTarihi).HasColumnName("baslangicTarihi");
            entity.Property(e => e.BitisTarihi).HasColumnName("bitisTarihi");
            entity.Property(e => e.Ilce).HasColumnName("ilce");
            entity.Property(e => e.IsUnvani).HasColumnName("isUnvani");
            entity.Property(e => e.KullaniciId).HasColumnName("kullaniciId");
            entity.Property(e => e.Sehir).HasColumnName("sehir");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.IsDeneyimis)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<KisiselBilgi>(entity =>
        {
            entity.HasKey(e => e.KullaniciId);

            entity.ToTable("KisiselBilgi");

            entity.HasIndex(e => e.KullaniciId, "IX_KisiselBilgi_KullaniciId").IsUnique();

            entity.Property(e => e.Adres).HasColumnName("adres");
            entity.Property(e => e.AskerlikDurumu).HasColumnName("askerlikDurumu");
            entity.Property(e => e.DogumTarihi).HasColumnName("dogumTarihi");
            entity.Property(e => e.DogumYeri).HasColumnName("dogumYeri");
            entity.Property(e => e.EPosta).HasColumnName("ePosta");
            entity.Property(e => e.Ilce).HasColumnName("ilce");
            entity.Property(e => e.MedeniDurumu).HasColumnName("medeniDurumu");
            entity.Property(e => e.PostaKodu).HasColumnName("postaKodu");
            entity.Property(e => e.Resim).HasColumnName("resim");
            entity.Property(e => e.Sehir).HasColumnName("sehir");
            entity.Property(e => e.SurucuEhliyeti).HasColumnName("surucuEhliyeti");
            entity.Property(e => e.UyeSifresi).HasColumnName("uyeSifresi");
            entity.Property(e => e.Websitesi).HasColumnName("websitesi");
        });

        modelBuilder.Entity<Kurslar>(entity =>
        {
            entity.HasKey(e => e.KursId);

            entity.ToTable("Kurslar");

            entity.HasIndex(e => e.KursId, "IX_Kurslar_KursId").IsUnique();

            entity.Property(e => e.Aciklama).HasColumnName("aciklama");
            entity.Property(e => e.Kurum).HasColumnName("kurum");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Kurslars)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<OzelBolum>(entity =>
        {
            entity.HasKey(e => e.OzelId);

            entity.ToTable("ozelBolum");

            entity.HasIndex(e => e.OzelId, "IX_ozelBolum_ozelId").IsUnique();

            entity.Property(e => e.OzelId).HasColumnName("ozelId");
            entity.Property(e => e.Aciklama).HasColumnName("aciklama");
            entity.Property(e => e.Baslik).HasColumnName("baslik");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.OzelBolums)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Profiller>(entity =>
        {
            entity.HasKey(e => e.ProfilId);

            entity.ToTable("Profiller");

            entity.HasIndex(e => e.ProfilId, "IX_Profiller_profilId").IsUnique();

            entity.Property(e => e.ProfilId).HasColumnName("profilId");
            entity.Property(e => e.GenelBilgi).HasColumnName("genelBilgi");
            entity.Property(e => e.IsUnvani).HasColumnName("isUnvani");
            entity.Property(e => e.Resim).HasColumnName("resim");
            entity.Property(e => e.UnvanAciklama).HasColumnName("unvanAciklama");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Profillers)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Sablon>(entity =>
        {
            entity.ToTable("Sablon");

            entity.HasIndex(e => e.SablonId, "IX_Sablon_sablonId").IsUnique();

            entity.Property(e => e.SablonId).HasColumnName("sablonId");
            entity.Property(e => e.OnizlemeResim).HasColumnName("onizlemeResim");
            entity.Property(e => e.SablonAdi).HasColumnName("sablonAdi");
            entity.Property(e => e.Text).HasColumnName("text");
        });

        modelBuilder.Entity<YeniKayit>(entity =>
        {
            entity.ToTable("YeniKayit");

            entity.HasIndex(e => e.Id, "IX_YeniKayit_Id").IsUnique();

            entity.Property(e => e.Eposta).HasColumnName("EPosta");
        });

        modelBuilder.Entity<Yetenekler>(entity =>
        {
            entity.HasKey(e => e.YetenekId);

            entity.ToTable("Yetenekler");

            entity.HasIndex(e => e.YetenekId, "IX_Yetenekler_yetenekId").IsUnique();

            entity.Property(e => e.YetenekId).HasColumnName("yetenekId");
            entity.Property(e => e.Aciklama).HasColumnName("aciklama");
            entity.Property(e => e.Seviye).HasColumnName("seviye");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Yeteneklers)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
