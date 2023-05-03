using System;
using System.Collections.Generic;

namespace cvProjesi.Models;

public partial class Yetenekler
{
    public long YetenekId { get; set; }

    public long KullaniciId { get; set; }

    public string? Adi { get; set; }

    public string? Aciklama { get; set; }

    public string? Seviye { get; set; }

    public virtual ICollection<CvYetenek> CvYeteneks { get; set; } = new List<CvYetenek>();

    public virtual KisiselBilgi Kullanici { get; set; } = null!;
}
