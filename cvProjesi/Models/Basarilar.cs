using System;
using System.Collections.Generic;

namespace cvProjesi.Models;

public partial class Basarilar
{
    public long BasariId { get; set; }

    public long KullaniciId { get; set; }

    public string? BBasligi { get; set; }

    public string? Aciklama { get; set; }

    public virtual ICollection<CvBasari> CvBasaris { get; set; } = new List<CvBasari>();

    public virtual KisiselBilgi Kullanici { get; set; } = null!;
}
