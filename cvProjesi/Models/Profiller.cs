using System;
using System.Collections.Generic;

namespace cvProjesi.Models;

public partial class Profiller
{
    public long ProfilId { get; set; }

    public long KullaniciId { get; set; }

    public string? IsUnvani { get; set; }

    public string? UnvanAciklama { get; set; }

    public string? GenelBilgi { get; set; }

    public string? Resim { get; set; }

    public virtual ICollection<CvProfil> CvProfils { get; set; } = new List<CvProfil>();

    public virtual KisiselBilgi Kullanici { get; set; } = null!;
}
