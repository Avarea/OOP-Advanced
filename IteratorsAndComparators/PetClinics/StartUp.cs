using System;
using System.Collections.Generic;
using System.Linq;

namespace PetClinics
{
    class StartUp
    {
        static void Main()
        {
            List<Pet> pets = new List<Pet>();
            List<PetClinic> clinics = new List<PetClinic>();
            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                string[] commandInput = Console.ReadLine()?.Split();
                string command = commandInput[0];

                switch (command)
                {
                    case "Create":
                        try
                        {
                            string type = commandInput[1];
                            if (type == "Pet")
                            {
                                Pet pet = new Pet(commandInput[2], int.Parse(commandInput[3]), commandInput[4]);
                                pets.Add(pet);
                            }
                            else
                            {
                                PetClinic petClinic = new PetClinic(commandInput[2], int.Parse(commandInput[3]));
                                clinics.Add(petClinic);
                            }
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                        
                        break;
                    case "Add":
                        Pet petToAdd = pets.FirstOrDefault(p => p.Name == commandInput[1]);
                        PetClinic clinicToAdd = clinics.FirstOrDefault(c => c.Name == commandInput[2]);
                        Console.WriteLine(clinicToAdd.Add(petToAdd));
                        break;
                    case "Release":
                        PetClinic clinicToRemove = clinics.FirstOrDefault(c => c.Name == commandInput[1]);
                        Console.WriteLine(clinicToRemove.Release());
                        break;
                    case "HasEmptyRooms":
                        PetClinic clinicHasRooms = clinics.FirstOrDefault(c => c.Name == commandInput[1]);
                        Console.WriteLine(clinicHasRooms.HasEmptyRooms);
                        break;
                    case "Print":
                        PetClinic clinictoPrint = clinics.FirstOrDefault(c => c.Name == commandInput[1]);

                        if (commandInput.Length == 3)
                        {
                            int roomNumber = int.Parse(commandInput[2]);
                            Console.WriteLine(clinictoPrint.Print(roomNumber));
                        }
                        else
                        {
                            Console.WriteLine(clinictoPrint.PrintAll());
                        }
                        break;
                }
            }
        }
    }
}
