
using DeveloperRepo;
using DevTeamRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceConsole
{
    class ProgramUI
    {

        private DevRepo _developerRepo = new DevRepo();
        private DeveloperTeamRepo _devTeamRepo = new DeveloperTeamRepo();

        public void Run()
        {
            SeedContentList();
            Menu();

        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            { // Display options to user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add new developer \n" +
                    "2. View all developers \n" +
                    "3. Update existing developer \n" +
                    "4. Remove a developer \n" +
                    "5. Add new team \n" +
                    "6. View all teams \n" +
                    "7. Update existing team\n" +
                    "8. Remove a team \n" +
                    "9. Developers that need Plurasight access\n" +
                    "10. Exit");

                string input = Console.ReadLine();

                switch (input) // switch case break is for the menu. prompts next action after number is selected
                {

                    case "1":
                        AddNewDevelopers();
                        break;
                    case "2":
                        ViewAllDevelopers();
                        break;
                    case "3":
                        UpdateDevelopers();
                        break;
                    case "4":
                        RemoveDevelopers();
                        break;
                    case "5":
                        CreateNewTeams();
                        break;
                    case "6":
                        ViewAllTeams();
                        break;
                    case "7":
                        UpdateTeams();
                        break;
                    case "8":
                        RemoveTeams();
                        break;
                    case "9":
                        NeedPluralsight();
                        break;
                    case "10":
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number from the list");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
        // Add Developer
        private void AddNewDevelopers()
        {
            DeveloperContent newDeveloper = new DeveloperContent();
            Console.Clear();
            Console.WriteLine("Enter developer's full name");
            newDeveloper.FullName = Console.ReadLine();

            Console.WriteLine("Enter developer's ID number (numbers only)");
            newDeveloper.IdNum = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Does developer have access to Pluralsight (y/n)?");
            string hasPluralsight = Console.ReadLine().ToLower();

            if (hasPluralsight == "y")
            {
                newDeveloper.HasPluralsight = true;
                Console.WriteLine("Developer successfully added. Press enter to return to menu.");
                Console.ReadLine();
            }
            else
            {
                newDeveloper.HasPluralsight = false;
                Console.WriteLine("Developer successfully added. Press enter to return to menu.");
                Console.ReadLine();
            }
            _developerRepo.AddDeveloperToList(newDeveloper);

        }
        // View all developers
        private void ViewAllDevelopers()
        {
            List<DeveloperContent> listOfDevelopers = _developerRepo.GetDeveloperList();

            foreach (DeveloperContent developer in listOfDevelopers)
            {
                Console.WriteLine($"Full Name:{developer.FullName}\nID Number:{developer.IdNum}\nAccess to Pluralsight:{developer.HasPluralsight}");
            }
        }
        // Update Developers
        private void UpdateDevelopers()
        {
            ViewAllDevelopers();

            Console.WriteLine("Enter full name of developer you want to update");

            string oldDeveloper = Console.ReadLine();

            DeveloperContent newDeveloper = new DeveloperContent();
            Console.Clear();
            Console.WriteLine("Enter developer's full name");
            newDeveloper.FullName = Console.ReadLine();

            Console.WriteLine("Enter developer's ID number (numbers only)");
            newDeveloper.IdNum = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Does developer have access to Pluralsight (y/n)?");
            string hasPluralsight = Console.ReadLine().ToLower();

            if (hasPluralsight == "y")
            {
                newDeveloper.HasPluralsight = true;
                Console.WriteLine("Developer successfully added. Press enter to return to menu.");
                Console.ReadLine();
            }
            else
            {
                newDeveloper.HasPluralsight = false;
                Console.WriteLine("Developer successfully added. Press enter to return to menu.");
                Console.ReadLine();

                bool wasUpdated = _developerRepo.UpdateDeveloper(oldDeveloper, newDeveloper);
                if (wasUpdated)
                {
                    Console.WriteLine("Developer was updated");

                }
                else
                {
                    Console.WriteLine("Developer was not updated");
                }
            }


        }

        // Remove developers 
        private void RemoveDevelopers()
        {
            Console.Clear();
            ViewAllDevelopers();

            Console.WriteLine("\nEnter full name of developer you would like to remove");

            string input = Console.ReadLine();

            bool wasDeleted = _developerRepo.RemoveDeveloperFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("Developer was deleted");

            }
            else
            {
                Console.WriteLine("The developer could not be deleted. Please be sure to enter the full name as stated");
            }



        }
        // Create new team
        private void CreateNewTeams()
        {
            DevTeamContent teamName = new DevTeamContent();

            Console.Clear();
            Console.WriteLine("Enter dev team name");
            teamName.TeamName = Console.ReadLine();

            Console.WriteLine("Enter dev team ID number (numbers only)");
            teamName.TeamId = Int32.Parse(Console.ReadLine());

            _devTeamRepo.AddDevTeamToList(teamName);
        }
        // View all teams
        private void ViewAllTeams()
        {
            List<DevTeamContent> listOfDevTeams = _devTeamRepo.GetDevTeamList();

            foreach (DevTeamContent teamName in listOfDevTeams)
            {
                Console.WriteLine($"Team Name:{teamName.TeamName}\nTeam ID:{teamName.TeamId}");
            }
        }
        // Update teams
        private void UpdateTeams()
        {
            ViewAllTeams();
            Console.WriteLine("Enter dev team you want to update");

            string oldDevTeam = Console.ReadLine();

            DevTeamContent newDevTeam = new DevTeamContent();
            Console.Clear();
            Console.WriteLine("Enter new dev team name");
            newDevTeam.TeamName = Console.ReadLine();

            Console.WriteLine("Enter dev team ID number (numbers only)");
            newDevTeam.TeamId = Int32.Parse(Console.ReadLine());

            bool wasUpdated = _devTeamRepo.UpdateDevTeam(oldDevTeam, newDevTeam);
            if (wasUpdated)
            {
                Console.WriteLine("Dev team was updated");

            }
            else
            {
                Console.WriteLine("Dev team was not updated");
            }



        }
        // Remove teams
        private void RemoveTeams()
        {
            Console.Clear();
            ViewAllTeams();

            Console.WriteLine("\nEnter dev team you would like to remove");

            string input = Console.ReadLine();

            bool wasDeleted = _devTeamRepo.RemoveDevTeamFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("Dev team was deleted");

            }
            else
            {
                Console.WriteLine("The dev team could not be deleted.");
            }
        }
        // Needs pluralsight 
        public void NeedPluralsight()
        {
            Console.Clear();
            List<DeveloperContent> listWithoutAccess = _developerRepo.NeedPluralsight();
            foreach (DeveloperContent developer in listWithoutAccess)
            {

                Console.WriteLine($"Full Name:{developer.FullName}\nID Number:{developer.IdNum}");
            }
        }

        //Seed Method
        private void SeedContentList()
        {
            DeveloperContent dezBryant = new DeveloperContent("Dez Bryant", 88, true);
            DeveloperContent tonyRomo = new DeveloperContent("Tony Romo", 09, true);
            DeveloperContent dakPrescott = new DeveloperContent("Dak Prescott", 04, false);

            _developerRepo.AddDeveloperToList(dezBryant);
            _developerRepo.AddDeveloperToList(tonyRomo);
            _developerRepo.AddDeveloperToList(dakPrescott);

        }
    }
}














