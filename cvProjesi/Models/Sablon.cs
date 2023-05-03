using System;
using System.Collections.Generic;

namespace cvProjesi.Models;

public partial class Sablon
{
    public long SablonId { get; set; }

    public string SablonAdi { get; set; } = null!;

    public string? OnizlemeResim { get; set; }

    public long? Text { get; set; }

    public virtual ICollection<CvOlustur> CvOlusturs { get; set; } = new List<CvOlustur>();
}
