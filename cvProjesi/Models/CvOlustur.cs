using System;
using System.Collections.Generic;

namespace cvProjesi.Models;

public partial class CvOlustur
{
    public long KayıtId { get; set; }

    public long KullaniciId { get; set; }

    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public long Sablon { get; set; }

    public long? Yetenekler { get; set; }

    public long? Egitimler { get; set; }

    public long? Kurslar { get; set; }

    public long? Isler { get; set; }

    public long? Basarilar { get; set; }

    public long? Portfolio { get; set; }

    public long? Diller { get; set; }

    public long? OzelBolum { get; set; }

    public virtual ICollection<CvBasari> CvBasaris { get; set; } = new List<CvBasari>();

    public virtual ICollection<CvDil> CvDils { get; set; } = new List<CvDil>();

    public virtual ICollection<CvEgitim> CvEgitims { get; set; } = new List<CvEgitim>();

    public virtual ICollection<CvI> CvIs { get; set; } = new List<CvI>();

    public virtual ICollection<CvKur> CvKurs { get; set; } = new List<CvKur>();

    public virtual ICollection<CvOzel> CvOzels { get; set; } = new List<CvOzel>();

    public virtual ICollection<CvProfil> CvProfils { get; set; } = new List<CvProfil>();

    public virtual ICollection<CvYetenek> CvYeteneks { get; set; } = new List<CvYetenek>();

    public virtual KisiselBilgi Kullanici { get; set; } = null!;

    public virtual Sablon SablonNavigation { get; set; } = null!;
}
