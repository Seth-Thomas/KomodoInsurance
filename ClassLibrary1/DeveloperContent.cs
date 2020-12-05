using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperRepo
{
    //POCO
    // Class(think of book example) gives the attributes of the object/program.
    // Object/program is the the physcial "book"--
    // --that gives data to the atttributes used in the class.
    // Contructors are special methods that go inside a class when you create--
    // --an object of that class.
    public class DeveloperContent
    {
        // getter and setters allow getting access and allow modification 
        public string FullName { get; set; }
        public int IdNum { get; set; }
        public bool HasPluralsight { get; set; }

        public DeveloperContent() { }

        // Constructor for DeveloperContent class from above(calling the strings)
        public DeveloperContent(string fullName, int idNum, bool hasPluralsight)
        {
            FullName = fullName;
            IdNum = idNum;
            HasPluralsight = hasPluralsight;

        }
       
    }
}
