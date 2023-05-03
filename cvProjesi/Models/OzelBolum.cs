using System;
using System.Collections.Generic;

namespace cvProjesi.Models;

public partial class OzelBolum
{
    public long OzelId { get; set; }

    public long KullaniciId { get; set; }

    public string? Baslik { get; set; }

    public string? Aciklama { get; set; }

    public virtual ICollection<CvOzel> CvOzels { get; set; } = new List<CvOzel>();

    public virtual KisiselBilgi Kullanici { get; set; } = null!;
}
