using System;
using System.Collections.Generic;

namespace cvProjesi.Models;

public partial class YeniKayit
{
    public long Id { get; set; }

    public string AdSoyad { get; set; } = null!;

    public string Eposta { get; set; } = null!;

    public long Telefon { get; set; }

    public string Sifre { get; set; } = null!;
}
