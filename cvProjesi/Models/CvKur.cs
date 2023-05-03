using System;
using System.Collections.Generic;

namespace cvProjesi.Models;

public partial class CvKur
{
    public long Id { get; set; }

    public long KayitId { get; set; }

    public long KursId { get; set; }

    public virtual CvOlustur Kayit { get; set; } = null!;

    public virtual Kurslar Kurs { get; set; } = null!;
}
