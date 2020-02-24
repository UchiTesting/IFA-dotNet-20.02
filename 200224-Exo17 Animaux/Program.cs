using System;
using System.Collections.Generic;
using static Simple_IO.AskData;
using _200224_Exo17_Animals.Animals;
using _200224_Exo17_Animals.Factory;

namespace _200224_Exo17_Animals
{
    class Program
    {
        static List<Animal> animals = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Exo 17: Animals");

            char choice = '\0';
            animals = new List<Animal>();

            do
            {
                DisplayMainMenu();

                choice = askChar("Selection: ");

                switch (choice)
                {
                    case '1':
                        CreateAnimalMenu();
                        break;
                    case '2':
                        ListAnimals();
                        break;
                    case '3':
                        AnimalsDoSomething();
                        break;
                }

            } while (choice != '0');
        }

        static void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu\n========");
            Console.WriteLine("1) Create an animal");
            Console.WriteLine("2) List Animals");
            Console.WriteLine("3) Animals do their thing");
            Console.WriteLine("0) Quit");
        }

        static void CreateAnimalMenu()
        {
            char choice = '\0';
            do
            {
                DisplayAnimalCreationMenu();

                choice = askChar("Selection: ");

                switch (choice)
                {
                    case '1':

                        animals.Add(new CatFactory().Create());
                        break;
                    case '2':
                        animals.Add( new DogFactory().Create());
                        break;
                    case '3':
                        animals.Add(new SeaGullFactory().Create());
                        break;
                }
            } while (choice != '0');
        }

        static void ListAnimals()
        {
            if (animals.Count >0)
                animals.ForEach(x => Console.WriteLine(x));
            else
                Console.WriteLine("The list is empty");

            Console.ReadKey(true);
        }

        static void AnimalsDoSomething()
        {
            if (animals.Count > 0)
                animals.ForEach(x => x.DoSomething());
            else
                Console.WriteLine("There's no animal to do anything.");

            Console.ReadKey(true);
        }

        private static void DisplayAnimalCreationMenu()
        {
            Console.Clear();
            Console.WriteLine("Animal Creation\n========");
            Console.WriteLine("1) Create an Emperor of the universe.");
            Console.WriteLine("2) Create a dog.");
            Console.WriteLine("3) Create a seagull.");
            Console.WriteLine("0) Exit this menu.");

        }
    }
}
