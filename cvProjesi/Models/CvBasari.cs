using System;
using System.Collections.Generic;

namespace cvProjesi.Models;

public partial class CvBasari
{
    public long Id { get; set; }

    public long KayitId { get; set; }

    public long BasariId { get; set; }

    public virtual Basarilar Basari { get; set; } = null!;

    public virtual CvOlustur Kayit { get; set; } = null!;
}
