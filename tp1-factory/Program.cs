using System;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


/*
    Classe Catalogue : classer véhicules entre essence / éléctrique
    Classe abstraite + sous-classes concrètes
    Éviter de modifier la classe catalogue à chaque nouveau type de véhicule grâce à une abstract factory -> dé-résponsabiliser la classe mère
    L'interface comprend la signature des méthodes qui serviront à définir chaque produit
        -> Signature = nom + IO (entrées/sorties) 
        -> // Prototype du C
*/

// Fichier Automobile.cs
public abstract class Automobile
{
    protected string modele;
    protected string couleur;
    protected int puissance;
    protected double espace;

    public Automobile(string modele, string couleur, int puissance, double espace)
    {
        this.modele = modele;
        this.couleur = couleur;
        this.puissance = puissance;
        this.espace = espace;
    }

    public abstract void afficherCarac();
}

// 
public class AutomobileElectrique : Automobile
{
    public AutomobileElectrique(string modele, string couleur, int puissance, double espace) : base(modele, couleur, puissance, espace)
    {
    }


    public override void afficherCarac()
    {
        Console.WriteLine("Automobile éléctrique :");
        Console.WriteLine("Modele : " + modele);
        Console.WriteLine("Couleur : " + couleur);
        Console.WriteLine("Puissance : " + puissance);
        Console.WriteLine("Espace : " + espace);
    }
}

public class AutomobileEssence : Automobile
{
    public AutomobileEssence(string modele, string couleur, int puissance, double espace) : base(modele, couleur, puissance, espace)
    {
    }


    public override void afficherCarac()
    {
        Console.WriteLine("Automobile essence :");
        Console.WriteLine("Modele : " + modele);
        Console.WriteLine("Couleur : " + couleur);
        Console.WriteLine("Puissance : " + puissance);
        Console.WriteLine("Espace : " + espace);
    }
}

//
public interface IFabriqueVehicle
{
    Automobile fabriquerAutomobile(string modele, string couleur, int puissance, double espace);
}

//
public class FabriqueVehicleEssence : IFabriqueVehicle
{
    public Automobile fabriquerAutomobile(string modele, string couleur, int puissance, double espace)
    {
        return new AutomobileEssence(modele, couleur, puissance, espace);
    }

    // public Scooter fabriquerScooter(string modele, string couleur, int puissance, double espace)
    // {
    //     return new ScooterEssence(modele, couleur, puissance, espace);
    // }
}


public class FabriqueVehicleElectrique : IFabriqueVehicle
{
    public Automobile fabriquerAutomobile(string modele, string couleur, int puissance, double espace)
    {
        return new AutomobileElectrique(modele, couleur, puissance, espace);
    }

    // public Scooter fabriquerScooter(string modele, string couleur, int puissance, double espace)
    // {
    //     return new ScooterEssence(modele, couleur, puissance, espace);
    // }
}


public class Catalogue
{

    public int nbVehicle = 2;
    static void Main(string[] args)
    {
        FabriqueVehicleEssence fabriqueEssence = new FabriqueVehicleEssence();
        FabriqueVehicleElectrique fabriqueElectrique = new FabriqueVehicleElectrique();
        Automobile auto1 = fabriqueEssence.fabriquerAutomobile("C4", "noir", 175, 2);
        Automobile auto2 = fabriqueEssence.fabriquerAutomobile("Clio 2", "bleu", 100, 0.5);
        Automobile auto3 = fabriqueElectrique.fabriquerAutomobile("Tesla", "rouge", 250, 2.5);
        auto1.afficherCarac();
        auto2.afficherCarac();
        auto3.afficherCarac();
    }
}

