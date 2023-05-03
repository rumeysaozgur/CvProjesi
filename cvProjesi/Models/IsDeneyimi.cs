using System;
using System.Collections.Generic;

namespace cvProjesi.Models;

public partial class IsDeneyimi
{
    public long IsId { get; set; }

    public long KullaniciId { get; set; }

    public string? IsUnvani { get; set; }

    public string? Sehir { get; set; }

    public string? Ilce { get; set; }

    public string? BaslangicTarihi { get; set; }

    public string? BitisTarihi { get; set; }

    public string? Aciklama { get; set; }

    public virtual ICollection<CvI> CvIs { get; set; } = new List<CvI>();

    public virtual KisiselBilgi Kullanici { get; set; } = null!;
}
