namespace UnikProjekt.Domain.Shared;

public class DAWAAddressModel
{
    public class Adresse
    {
        public string Id { get; set; }
        public string Vejnavn { get; set; }
        public string Adresseringsvejnavn { get; set; }
        public string Husnr { get; set; }
        public string Supplerendebynavn { get; set; }
        public string Postnr { get; set; }
        public string Postnrnavn { get; set; }
        public int Status { get; set; }
        public DateTime Virkningstart { get; set; }
        public DateTime? Virkningslut { get; set; }
        public string Adgangsadresseid { get; set; }
        public string Etage { get; set; }
        public string Dør { get; set; }
    }

    public class Aktueladresse
    {
        public string Id { get; set; }
        public string Vejnavn { get; set; }
        public string Adresseringsvejnavn { get; set; }
        public string Husnr { get; set; }
        public string Supplerendebynavn { get; set; }
        public string Postnr { get; set; }
        public string Postnrnavn { get; set; }
        public int Status { get; set; }
        public DateTime Virkningstart { get; set; }
        public DateTime? Virkningslut { get; set; }
        public string Adgangsadresseid { get; set; }
        public string Etage { get; set; }
        public string Dør { get; set; }
        public string Href { get; set; }
    }

    public class Vaskeresultat
    {
        public Variant Variant { get; set; }
        public int Afstand { get; set; }
        public Forskelle Forskelle { get; set; }
        public Parsetadresse Parsetadresse { get; set; }
        public List<object> Ukendtetokens { get; set; }
        public object Anvendtstormodtagerpostnummer { get; set; }
    }

    public class Variant
    {
        public string Vejnavn { get; set; }
        public string Husnr { get; set; }
        public string Etage { get; set; }
        public string Dør { get; set; }
        public object Supplerendebynavn { get; set; }
        public string Postnr { get; set; }
        public string Postnrnavn { get; set; }
    }

    public class Forskelle
    {
        public int Vejnavn { get; set; }
        public int Husnr { get; set; }
        public int Postnr { get; set; }
        public int Postnrnavn { get; set; }
        public int Etage { get; set; }
        public int Dør { get; set; }
    }

    public class Parsetadresse
    {
        public string Vejnavn { get; set; }
        public string Husnr { get; set; }
        public string Etage { get; set; }
        public string Dør { get; set; }
        public string Postnr { get; set; }
        public string Postnrnavn { get; set; }
    }

    public class Resultater
    {
        public Adresse Adresse { get; set; }
        public Aktueladresse Aktueladresse { get; set; }
        public Vaskeresultat Vaskeresultat { get; set; }
    }

    public class Root
    {
        public string Kategori { get; set; }
        public List<Resultater> Resultater { get; set; }
    }

}
