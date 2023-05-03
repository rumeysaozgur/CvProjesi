using System;
using System.Collections.Generic;

namespace cvProjesi.Models;

public partial class CvI
{
    public long Id { get; set; }

    public long KayitId { get; set; }

    public long Isıd { get; set; }

    public virtual IsDeneyimi IsıdNavigation { get; set; } = null!;

    public virtual CvOlustur Kayit { get; set; } = null!;
}
