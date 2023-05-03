using System;
using System.Collections.Generic;

namespace cvProjesi.Models;

public partial class CvOzel
{
    public long Id { get; set; }

    public long KayitId { get; set; }

    public long OzelId { get; set; }

    public virtual CvOlustur Kayit { get; set; } = null!;

    public virtual OzelBolum Ozel { get; set; } = null!;
}
