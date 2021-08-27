﻿using System;
using Mantas.PetShop.Core.IServices;
using Mantas.PetShop.Core.Models;
using Mantas.PetShop.Domain.Services;

namespace Mantas.PetShop.UI
{
    public class MainMenu : IMenu
    {
        
        private IPetService _petService;
        private IPetTypeService _petTypeService;
        public MainMenu(IPetService petService, IPetTypeService petTypeService)
        {
            _petService = petService;
            _petTypeService = petTypeService;
        }

        public void Start()
        {
            StartLoop();
        }
        
        private void StartLoop()
        {
            int choice;
            while ((choice = GetMainMenuSelection()) != 0)
            {
                if (choice == 1)
                {
                    CreatePet();
                } else if (choice == 2)
                {
                    DeletePet();
                } 
                else if (choice == 3)
                {
                    UpdatePet();
                }
                else if (choice == 4)
                {
                    ShowAllPets();
                }
                else if (choice == 5)
                {
                    SearchForAPet();
                }
                else if (choice == -1 )
                {
                    PleaseTryAgain();
                }
            }
        }
        
        private int GetMainMenuSelection()
        {
            ShowMainMenu();
            Print("");
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }
            return -1;
        }

        public void ShowMainMenu()
        {
            Print(StringConstants.WelcomeGreeting);
            Print(StringConstants.CreatePet);
            Print(StringConstants.DeletePet);
            Print(StringConstants.UpdatePet);
            Print(StringConstants.ShowAllPets);
            Print(StringConstants.SearchForAPet);
        }
        
        
        public void CreatePet()
        {
            Print("Write the name of the new pet:");
            var petName = Console.ReadLine();
            Print("Write the type of the new pet:");
            string? petType = Console.ReadLine();
            Print("Write the birthday of the new pet:");
            DateTime petBDay = Convert.ToDateTime(Console.ReadLine());
            Print("Write the color of the new pet:");
            var petColor = Console.ReadLine();
            Print("Write the price of the new pet:");
            double petPrice = Convert.ToDouble(Console.ReadLine());

            var pet = new Pet()
            {
                Name = petName,
                PetType = petType,
                Birthdate = petBDay,
                Color = petColor,
                Price = petPrice
            };
            pet = _petService.CreatePet(pet);
            Print($"New pet create with the name of: {pet.Name} Type: {pet.PetType} BDay: {pet.Birthdate} Color: {pet.Color} Price: {pet.Price}");
        }
        
        public void DeletePet()
        {
            Print("Select pet to remove:");
            ShowAllPets();
            int id = Convert.ToInt32(Console.ReadLine());
            var pet = new Pet()
            {
                Id = id
            };
            pet = _petService.DeletePet(id);
            Print("You just removed a pet");
        }

        public void UpdatePet()
        {
            
        }

        public void ShowAllPets()
        {
            Print("Here are all available pets");
            var pets = _petService.GetPets();
            foreach (var pet in pets)
            {
                Print($"{pet.Id}, {pet.Name}, {pet.PetType}, {pet.Birthdate}, {pet.Color}, {pet.Price}");
            }
        }

        public void SearchForAPet()
        {
            
        }
        
        private void PleaseTryAgain()
        {
            Print("Please try again");
        }
        
        private void Print(string value)
        {
            Console.WriteLine(value);
        }
    }
}