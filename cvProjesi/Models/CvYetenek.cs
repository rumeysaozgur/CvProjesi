using System;
using System.Collections.Generic;

namespace cvProjesi.Models;

public partial class CvYetenek
{
    public long Id { get; set; }

    public long KayitId { get; set; }

    public long YetenekId { get; set; }

    public virtual CvOlustur Kayit { get; set; } = null!;

    public virtual Yetenekler Yetenek { get; set; } = null!;
}
