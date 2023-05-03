using System;
using System.Collections.Generic;

namespace cvProjesi.Models;

public partial class Kurslar
{
    public long KursId { get; set; }

    public long KullaniciId { get; set; }

    public string? KursAdi { get; set; }

    public string? Kurum { get; set; }

    public string? Aciklama { get; set; }

    public virtual ICollection<CvKur> CvKurs { get; set; } = new List<CvKur>();

    public virtual KisiselBilgi Kullanici { get; set; } = null!;
}
