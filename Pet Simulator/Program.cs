using System;
using System.Threading;

namespace VirtualPet
{
    class Pet
    {
        public string Name { get; }
        public string Type { get; }
        public int Hunger { get; private set; }
        public int Happiness { get; private set; }
        public int Health { get; private set; }

        public Pet(string name, string type)
        {
            Name = name;
            Type = type;
            Hunger = 5;
            Happiness = 5;
            Health = 5;
        }

        public void Feed()
        {
            Hunger = Math.Max(0, Hunger - 2);
            Happiness = Math.Min(10, Happiness + 1);
            Health = Math.Min(10, Health + 1);
            Console.WriteLine("You feed " + Name + ". Hunger decreases, and health increases.");
        }

        public void Play()
        {
            Happiness = Math.Min(10, Happiness + 2);
            Hunger = Math.Min(10, Hunger + 1);
            Health = Math.Max(0, Health - 1);
            Console.WriteLine("You play with " + Name + ". Happiness increases, but hunger and health may be affected.");
        }

        public void Rest()
        {
            Health = Math.Min(10, Health + 2);
            Happiness = Math.Max(0, Happiness - 1);
            Console.WriteLine(Name + " rests. Health improves, but happiness may decrease.");
        }

        public void ShowStatus()
        {
            Console.WriteLine("Status of " + Name + ":");
            Console.WriteLine("Hunger: " + Hunger);
            Console.WriteLine("Happiness: " + Happiness);
            Console.WriteLine("Health: " + Health);
        }

        public void CheckStatus()
        {
            if (Hunger <= 2)
                Console.WriteLine(Name + " is hungry.");
            if (Happiness <= 2)
                Console.WriteLine(Name + " is unhappy.");
            if (Health <= 2)
                Console.WriteLine(Name + " is unhealthy.");
        }

        public void TimePasses()
        {
            Hunger += 1;
            Happiness -= 1;
            Console.WriteLine("Time passes. Hunger increases, and happiness decreases.");
        }

        public bool IsAlive()
        {
            return Hunger < 10 && Happiness > 0 && Health > 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Virtual Pet!");
            Console.WriteLine("Choose a pet type: \n1. cat\n2. dog\n3. rabbit");
            int petTypeChoice = Convert.ToInt32(Console.ReadLine());

            string petType = "";
            switch (petTypeChoice)
            {
                case 1:
                    petType = "cat";
                    break;
                case 2:
                    petType = "dog";
                    break;
                case 3:
                    petType = "rabbit";
                    break;
                default:
                    Console.WriteLine("Invalid choice. Exiting...");
                    return;
            }

            Console.WriteLine("Enter a name for your " + petType + ":");
            string petName = Console.ReadLine();

            Pet pet = new Pet(petName, petType);
            Console.WriteLine("Welcome, your " + pet.Type + " named " + pet.Name + " is ready!");

            Console.WriteLine("Instructions:");
            Console.WriteLine("1. Type '1' to feed your pet");
            Console.WriteLine("2. Type '2' to play with your pet");
            Console.WriteLine("3. Type '3' to let your pet rest");
            Console.WriteLine("4. Type '4' to check the pet's status");
            Console.WriteLine("5. Type '5' to quit");

            while (pet.IsAlive())
            {
                pet.TimePasses();

                Console.WriteLine("\nChoose an action:");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        pet.Feed();
                        break;
                    case "2":
                        pet.Play();
                        break;
                    case "3":
                        pet.Rest();
                        break;
                    case "4":
                        pet.ShowStatus();
                        pet.CheckStatus();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (!pet.IsAlive())
                {
                    Console.WriteLine("Your pet has passed away. Game over.");
                    break;
                }

                Thread.Sleep(1000); // Pause for 1 second to simulate the passage of time
            }
        }
    }
}
