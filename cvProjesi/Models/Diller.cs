using System;
using System.Collections.Generic;

namespace cvProjesi.Models;

public partial class Diller
{
    public long DilId { get; set; }

    public long KullaniciId { get; set; }

    public string? Dil { get; set; }

    public string? Seviye { get; set; }

    public virtual KisiselBilgi Kullanici { get; set; } = null!;
}
