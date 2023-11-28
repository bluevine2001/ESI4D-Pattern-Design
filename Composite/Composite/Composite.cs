namespace Composite;


using System;
using System.Collections.Generic;

abstract class Societe
{
    protected string _nom;
    protected int _nombreVehicules;

    public Societe(string nom, int nombreVehicules)
    {
        _nom = nom;
        _nombreVehicules = nombreVehicules;
    }

    public abstract void AfficheParcAutomobile();
    public virtual void Add(Societe filiale)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(Societe filiale)
    {
        throw new NotImplementedException();
    }

    public virtual bool IsMere()
    {
        return true;
    }
}

class Filiale : Societe
{
    public Filiale(string nom, int nombreVehicules) : base(nom, nombreVehicules) { }

    public override void AfficheParcAutomobile()
    {
        Console.WriteLine($"{_nom} a {_nombreVehicules} véhicules.");
    }

    public override bool IsMere()
    {
        return false;
    }
}

class SocieteMere : Societe
{
    private List<Societe> _filiales = new List<Societe>();
    
    public SocieteMere(string nom) : base(nom, 0) { }

    public override void Add(Societe filiale)
    {
        _filiales.Add(filiale);
    }

    public override void Remove(Societe filiale)
    {
        _filiales.Remove(filiale);
    }

    public override void AfficheParcAutomobile()
    {
        Console.WriteLine($"{_nom} a un parc automobile composé de :");
        foreach (Societe filiale in _filiales)
        {
            filiale.AfficheParcAutomobile();
        }
    }
}

class Client
{
    public void AfficheInformations(Societe societe)
    {
        societe.AfficheParcAutomobile();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Client client = new Client();

        // Création de filiales avec un certain nombre de véhicules
        Filiale filiale1 = new Filiale("Filiale 1", 10);
        Filiale filiale2 = new Filiale("Filiale 2", 7);
        Filiale sousFiliale1 = new Filiale("Sous-Filiale 1", 5);

        // Création de la société mère et ajout des filiales
        SocieteMere societeMere = new SocieteMere("Société Mère");
        societeMere.Add(filiale1);
        societeMere.Add(filiale2);

        // Ajout d'une sous-filiale à une filiale
        SocieteMere grandeFiliale = new SocieteMere("Grande Filiale");
        grandeFiliale.Add(sousFiliale1);

        // La grande filiale est elle-même une filiale de la société mère
        //societeMere.Add(grandeFiliale);

        // Affichage des informations de la société mère
        //societeMere.AfficheParcAutomobile();

        // Affichage des informations de la grande filiale
        grandeFiliale.AfficheParcAutomobile();

        // Affichage des informations de la filiale 1
        //filiale1.AfficheParcAutomobile();

        // Affichage des informations de la filiale 2
        //filiale2.AfficheParcAutomobile();

        // Affichage des informations de la sous-filiale 1
        //sousFiliale1.AfficheParcAutomobile();

        // Affichage des informations de la société mère par le client
        //client.AfficheInformations(societeMere);

    }
}

