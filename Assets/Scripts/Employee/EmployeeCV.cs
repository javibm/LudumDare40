using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeCV 
{
    public float Happiness
    {
        get;
        private set;
    }
    public int MoneyCost
    {
        get;
        private set;
    }
    public string Name
    {
        get;
        private set;
    }

    public EmployeeCV()
    {
        GetRandomEmployeeStats();
    }

    public void GetRandomEmployeeStats()
    {
        if(Random.Range(0.0f, 1.0f) > 0.8f)
        {
            Name = GetRandomSpecialName();
        }
        else
        {
            Name = GenerateName(Random.Range(5, 8));
        }
        Happiness = Random.Range(GameMetaManager.Employee.EmployeeStats.minInitialHappiness, GameMetaManager.Employee.EmployeeStats.maxInitialHappiness);
        MoneyCost = Mathf.CeilToInt(Happiness * GameMetaManager.Employee.EmployeeStats.moneyFactor);
    }

    private string GenerateName(int len)
    {
        System.Random r = new  System.Random();
        string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
        string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
        string Name = "";
        Name += consonants[r.Next(consonants.Length)].ToUpper();
        Name += vowels[r.Next(vowels.Length)];
        int b = 2;
        while (b < len)
        {
            Name += consonants[r.Next(consonants.Length)];
            b++;
            Name += vowels[r.Next(vowels.Length)];
            b++;
        }

        return Name;
    }

    private string GetRandomSpecialName()
    {
        return SpecialNames[Random.Range(0, SpecialNames.Length)];
    }

    private string[] SpecialNames = new string[]{"Puñales", "Javote", "Ajota", "Jocheider", "Francoc", "Yisus", 
    "Marcos", "Carlota", "MadMellow", "Lewandowski", "Triyisus", "Gustavo", "Miguel el Gordo", "Sergar", "Cabrote", 
    "Maceta", "Bolardo","Estivi","Vargas","Gitano","Altea","Pepper", "Gustin", "Pablo Iglesias", "Fiu Fiu", "Angel David", 
    "Oscar", "Velen", "Tomas", "Mate", "Diego", "Jorge", "Juanjo", "Adrian", "Zhang", "QA Luis", "QAngel", "Carolina", 
    "Bob Morate", "Qarrillo", "Clicker Boy", "Indalo", "Machango", "Rayco", "Fotingo", "Almeria", "Bisbal", "Leprous", "Taburete", "Willy",
    "Jari", "Devin", "Einar", "Mikael", "Twinbot" };
}
