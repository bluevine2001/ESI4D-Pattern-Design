namespace CatalogueVoitureCSharp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

class Catalogue
{

}

interface FabriqueVehicule
{
    void CreeAutomobile();
    void CreeScooter();
}

class FabriqueVehiculeElectrique : FabriqueVehicule
{
    public void CreeAutomobile()
    {
        Console.WriteLine("Automobile électrique créée");
    }

    public void CreeScooter()
    {
        Console.WriteLine("Scooter électrique créé");
    }
}

class FabriqueVehiculeEssence : FabriqueVehicule
{
    public Automobile CreeAutomobile()
    {
        return new AutomobileEssence("Renault", "Clio", 2010, "Rouge", 10000, 5, "Essence");
    }

    public void CreeScooter()
    {
        return new ScooterEssence("Peugeot", "Speedfight", 2015, "Noir", 2000, 50, "Essence");
    }
}

abstract class Automobile
{
    public string? Marque { get; set; }
    public string? Modele { get; set; }
    public int Annee { get; set; }
    public string? Couleur { get; set; }
    public decimal Prix { get; set; }
    public int NombreDePortes { get; set; }
    public string? TypeCarburant { get; set; }

    public Automobile(string marque, string modele, int annee, string couleur, decimal prix, int nombreDePortes, string typeCarburant)
    {
        Marque = marque;
        Modele = modele;
        Annee = annee;
        Couleur = couleur;
        Prix = prix;
        NombreDePortes = nombreDePortes;
        TypeCarburant = typeCarburant;
    }
}

abstract class Scooter
{
    public string? Marque { get; set; }
    public string? Modele { get; set; }
    public int Annee { get; set; }
    public string? Couleur { get; set; }
    public decimal? Prix { get; set; }
    public int Cylindree { get; set; }
    public string? TypeCarburant { get; set; }

    public Scooter(string marque, string modele, int annee, string couleur, decimal prix, int cylindree, string typeCarburant)
    {
        Marque = marque;
        Modele = modele;
        Annee = annee;
        Couleur = couleur;
        Prix = prix;
        Cylindree = cylindree;
        TypeCarburant = typeCarburant;
    }
}

class AutomobileEssence : Automobile
{

    public AutomobileEssence(string marque, string modele, int annee, string couleur, decimal prix, int nombreDePortes, string typeCarburant) : base(marque, modele, annee, couleur, prix, nombreDePortes, typeCarburant)
    {
        
    }

}

class ScooterEssence : Scooter
{
    public ScooterEssence(string marque, string modele, int annee, string couleur, decimal prix, int cylindree, string typeCarburant) : base(marque, modele, annee, couleur, prix, cylindree, typeCarburant)
    {
        
    }
}