using System;
using System.Collections.Generic;

namespace cvProjesi.Models;

public partial class Egitimler
{
    public long EgitimId { get; set; }

    public long KullaniciId { get; set; }

    public string EgitimAd { get; set; } = null!;

    public string EgitimTuru { get; set; } = null!;

    public string? DereceSertifika { get; set; }

    public string? Sehir { get; set; }

    public string? Ilce { get; set; }

    public string? Okul { get; set; }

    public string? BaslangicTarihi { get; set; }

    public string? BitisTarihi { get; set; }

    public string? Aciklama { get; set; }

    public virtual ICollection<CvEgitim> CvEgitims { get; set; } = new List<CvEgitim>();

    public virtual KisiselBilgi Kullanici { get; set; } = null!;
}
