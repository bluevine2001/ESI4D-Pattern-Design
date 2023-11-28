namespace CatalogueVoitureCSharp;


class Catalogue
{
     static void Main(string[] args)
    {
        FabriqueVehicule fabriqueVehiculeElectrique = new FabriqueVehiculeElectrique();
        FabriqueVehicule fabriqueVehiculeEssence = new FabriqueVehiculeEssence();

        Automobile automobileElectrique = fabriqueVehiculeElectrique.CreeAutomobile();
        Scooter scooterElectrique = fabriqueVehiculeElectrique.CreeScooter();

        Automobile automobileEssence = fabriqueVehiculeEssence.CreeAutomobile();
        Scooter scooterEssence = fabriqueVehiculeEssence.CreeScooter();

        Console.WriteLine("Catalogue de véhicules électriques");
        Console.WriteLine("Automobile : " + automobileElectrique.Marque + " " + automobileElectrique.Modele + " " + automobileElectrique.Annee + " " + automobileElectrique.Couleur + " " + automobileElectrique.Prix + " " + automobileElectrique.NombreDePortes + " " + automobileElectrique.TypeCarburant);
        Console.WriteLine("Scooter : " + scooterElectrique.Marque + " " + scooterElectrique.Modele + " " + scooterElectrique.Annee + " " + scooterElectrique.Couleur + " " + scooterElectrique.Prix + " " + scooterElectrique.Cylindree + " " + scooterElectrique.TypeCarburant);

        Console.WriteLine("Catalogue de véhicules à essence");
        Console.WriteLine("Automobile : " + automobileEssence.Marque + " " + automobileEssence.Modele + " " + automobileEssence.Annee + " " + automobileEssence.Couleur + " " + automobileEssence.Prix + " " + automobileEssence.NombreDePortes + " " + automobileEssence.TypeCarburant);
        Console.WriteLine("Scooter : " + scooterEssence.Marque + " " + scooterEssence.Modele + " " + scooterEssence.Annee + " " + scooterEssence.Couleur + " " + scooterEssence.Prix + " " + scooterEssence.Cylindree + " " + scooterEssence.TypeCarburant);
    }
}

interface FabriqueVehicule
{
    Automobile CreeAutomobile();
    Scooter CreeScooter();
}

class FabriqueVehiculeElectrique : FabriqueVehicule
{
    public Automobile CreeAutomobile()
    {
        return new AutomobileElectrique("Tesla", "Model S", 2019, "Noir", 100000, 5, "Electrique");
    }

    public Scooter CreeScooter()
    {
       return new ScooterElectrique("Peugeot", "Elystar", 2015, "Noir", 2000, 50, "Electrique");
    }
}

class FabriqueVehiculeEssence : FabriqueVehicule
{
    public Automobile CreeAutomobile()
    {
        return new AutomobileEssence("Renault", "Clio", 2010, "Rouge", 10000, 5, "Essence");
    }

    public Scooter CreeScooter()
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

class AutomobileElectrique : Automobile
{
    public AutomobileElectrique(string marque, string modele, int annee, string couleur, decimal prix, int nombreDePortes, string typeCarburant) : base(marque, modele, annee, couleur, prix, nombreDePortes, typeCarburant)
    {

    }
}

class ScooterElectrique : Scooter
{
    public ScooterElectrique(string marque, string modele, int annee, string couleur, decimal prix, int cylindree, string typeCarburant) : base(marque, modele, annee, couleur, prix, cylindree, typeCarburant)
    {

    }
}

// génération liasse véhicule pdf ou html

class Vendeur {
    public void Construit(){
        ConstructeurLiasseVehicule constructeur;
        string choix = "html";
        if(choix == "html"){
            constructeur = new ConstructeurLiasseVehiculeHtml();
        } else {
            constructeur = new ConstructeurLiasseVehiculePdf();
        }
        Client client = new Client();
        client.Construit(this, constructeur);
    }

    public void Construit(ConstructeurLiasseVehicule constructeur){
        constructeur.ConstruitBonDeCommande("Bon de commande client");
        constructeur.ConstruitDemandeImmatriculation("Demande d'immatriculation client");
    }

}

public abstract class ConstructeurLiasseVehicule {
    protected Liasse? liasse;
    public abstract void ConstruitBonDeCommande(string nomClient);

    public abstract void ConstruitDemandeImmatriculation(string nomDemandeur);

    public Liasse? Resultat(){
        return liasse;
    }
}

class ConstructeurLiasseVehiculePdf : ConstructeurLiasseVehicule {
    public override void ConstruitBonDeCommande(string nomClient){

    }

    public override void ConstruitDemandeImmatriculation(string nomDemandeur){

    }
}

class ConstructeurLiasseVehiculeHtml : ConstructeurLiasseVehicule {
    public override void ConstruitBonDeCommande(string nomClient){

    }

    public override void ConstruitDemandeImmatriculation(string nomDemandeur){

    }
}

public abstract class Liasse {
    public abstract void AjouteDocument(string document);

    public abstract void Imprime();
}

class LiasseHtml : Liasse {
    public override void AjouteDocument(string document){

    }

    public override void Imprime(){

    }

}

class LiassePdf : Liasse {
    public override void AjouteDocument(string document){

    }

    public override void Imprime(){

    }

}
class Client {
    public void Construit(Vendeur vendeur, ConstructeurLiasseVehicule constructeur){
        vendeur.Construit(constructeur);
        Liasse? liasse = constructeur.Resultat();
        if (liasse != null)
        {
            liasse.Imprime();
        }
    }
}