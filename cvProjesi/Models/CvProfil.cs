using System;
using System.Collections.Generic;

namespace cvProjesi.Models;

public partial class CvProfil
{
    public long Id { get; set; }

    public long KayitId { get; set; }

    public long CvProfil1 { get; set; }

    public virtual Profiller CvProfil1Navigation { get; set; } = null!;

    public virtual CvOlustur Kayit { get; set; } = null!;
}
