using System;
using System.Collections.Generic;

namespace cvProjesi.Models;

public partial class KisiselBilgi
{
    public long KullaniciId { get; set; }

    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public string? EPosta { get; set; }

    public long? Telefon { get; set; }

    public string? Adres { get; set; }

    public string? PostaKodu { get; set; }

    public string? Sehir { get; set; }

    public string? Ilce { get; set; }

    public string? Resim { get; set; }

    public string? DogumTarihi { get; set; }

    public string? DogumYeri { get; set; }

    public string? SurucuEhliyeti { get; set; }

    public string? Cinsiyet { get; set; }

    public string? AskerlikDurumu { get; set; }

    public string? MedeniDurumu { get; set; }

    public string? Linkedn { get; set; }

    public string? Websitesi { get; set; }

    public string? UyeSifresi { get; set; }

    public virtual ICollection<Basarilar> Basarilars { get; set; } = new List<Basarilar>();

    public virtual ICollection<Diller> Dillers { get; set; } = new List<Diller>();

    public virtual ICollection<Egitimler> Egitimlers { get; set; } = new List<Egitimler>();

    public virtual ICollection<IsDeneyimi> IsDeneyimis { get; set; } = new List<IsDeneyimi>();

    public virtual ICollection<Kurslar> Kurslars { get; set; } = new List<Kurslar>();

    public virtual ICollection<OzelBolum> OzelBolums { get; set; } = new List<OzelBolum>();

    public virtual ICollection<Profiller> Profillers { get; set; } = new List<Profiller>();

    public virtual ICollection<Yetenekler> Yeteneklers { get; set; } = new List<Yetenekler>();
}
