using DeveloperRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperRepo
{
    public class DevRepo
    {
        private List<DeveloperContent> _listOfDevelopers = new List<DeveloperContent>();

        //Create
        public void AddDeveloperToList(DeveloperContent developer)
        {
            _listOfDevelopers.Add(developer);
        }

        //Read
        public List<DeveloperContent> GetDeveloperList()
        {
            return _listOfDevelopers;
        }

        //Update
        public bool UpdateDeveloper(string originalFullName, DeveloperContent newDeveloper)
        {
            //Find the developer
            DeveloperContent oldDeveloper = GetDeveloperByFullName(originalFullName);

            //Update developer
            if (oldDeveloper != null)
            {
                oldDeveloper.FullName = newDeveloper.FullName;
                oldDeveloper.IdNum = newDeveloper.IdNum;
                oldDeveloper.HasPluralsight = newDeveloper.HasPluralsight;
                return true;
            }
            else
            {
                return false;
            }

        }
        //Delete
        public bool RemoveDeveloperFromList(string fullName)
        {
            DeveloperContent developer = GetDeveloperByFullName(fullName);

            if (developer == null)
            {
                return false;
            }
            int initialCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(developer);

            if (initialCount > _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Need pluralsight access
        public List<DeveloperContent> NeedPluralsight()
        {
            // Create empty list to hold developers that don't have access
            List<DeveloperContent> listWithoutAccess = new List<DeveloperContent>();
            // Iterate through list of all developers
            foreach (DeveloperContent developer in _listOfDevelopers)
            {
                if (developer.HasPluralsight == false)
                {
                    listWithoutAccess.Add(developer);
                }


            }
            return listWithoutAccess;

        }


        //Helper method
        private DeveloperContent GetDeveloperByFullName(string fullName)
        {
            foreach (DeveloperContent developer in _listOfDevelopers)
            {
                if (developer.FullName.ToLower() == fullName.ToLower())
                {
                    return developer;
                }
            }
            return null;

        }

    }
}
