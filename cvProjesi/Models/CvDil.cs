using System;
using System.Collections.Generic;

namespace cvProjesi.Models;

public partial class CvDil
{
    public long Id { get; set; }

    public long KayitId { get; set; }

    public long DilId { get; set; }

    public virtual CvDil Dil { get; set; } = null!;

    public virtual ICollection<CvDil> InverseDil { get; set; } = new List<CvDil>();

    public virtual CvOlustur Kayit { get; set; } = null!;
}
