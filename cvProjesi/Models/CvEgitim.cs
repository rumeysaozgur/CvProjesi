using System;
using System.Collections.Generic;

namespace cvProjesi.Models;

public partial class CvEgitim
{
    public long Id { get; set; }

    public long KayitId { get; set; }

    public long EgitimId { get; set; }

    public virtual Egitimler Egitim { get; set; } = null!;

    public virtual CvOlustur Kayit { get; set; } = null!;
}
