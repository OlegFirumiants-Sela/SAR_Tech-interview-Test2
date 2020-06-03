using System;
using System.Collections.Generic;

namespace SeleniumTest
{
    public static class Helper
    {
        // target url for automation test
        public static string URL = @"http://automationpractice.com/index.php";
        // path for the location of the chrome driver, if necessary download and copy chromedriver.exe 
        // to the folder of the project (...\SAR_Tech-interview-Test2\SeleniumTest\SeleniumTest)
        public static string CHROMEDRIVERPATH = "../../../"; 
        static List<string> firstNameList = new List<string>
        {
            "Abraham", "Abbey", "Alon", "Anat",
            "Bob", "Bella", "Benjamin", "Batia",
            "Carl", "Chelsea", "Charles", "Chloe",
            "Doron", "Deborah", "David", "Dafna",
            "Eric", "Ella", "Eitan", "Eve",
            "Frank", "Faina", "Felix", "Funny",
            "Gerald", "Gaby", "Gabriel", "Gina",
            "Harold", "Hannah", "Hanan", "Holy",
            "Israel", "Inna", "Igor", "Isca",
            "Jacob", "Jane", "John", "Jacqueline",
            "Kumar", "Kristin", "Kobi", "Kim",
            "Lidor", "Lea", "Liron", "Linoy",
            "Murad", "Maria", "Maor", "Michal",
            "Nitzan", "Noa", "Nimrod", "Nissan",
            "Oren", "Orna", "Ofir", "Olga",
            "Peter", "Perah", "Paul", "Paulina",
            "Ron", "Rona", "Riccardo", "Reut",
            "Shalon", "Sonia", "Simon", "Sophia",
            "Tal", "Tova", "Tomer", "Talia",
            "Victor", "Victoria", "Vladimir", "Viola",
            "Zohar", "Zina", "Zeev", "Zoy"
        };
        static List<string> lastNameList = new List<string>
        {
            "Abrahams", "Avni",
            "Bottas", "Baruch",
            "Churekov", "Cherny",
            "Davidson", "Davidoff",
            "Erlich", "Eden",
            "Faruk", "Feinstein",
            "Gov", "Gordon",
            "Hadas", "Hadad",
            "Ivgy", "Israeli",
            "Jacobs", "Jeremiah",
            "Kupfer", "Koren",
            "Leon", "Liberman",
            "Mroon", "Meir",
            "Negev", "Nissanov",
            "Oscar", "Oren",
            "Rotem", "Ruben",
            "Shmuel", "Shemesh",
            "Tuval", "Terik",
            "Ulman", "Uri",
            "Varan", "Volach",
            "White", "Werner",
            "Zack", "Zohar"
        };
        static Random rnd = new Random();

        /// <summary>
        /// gets first name randomly from list of first names.
        /// </summary>
        /// <returns>string first name</returns>
        public static string GetFirstNameRandomly()
        {
            return firstNameList[rnd.Next(firstNameList.Count)];
        }

        /// <summary>
        /// gets last name randomly from list of last names.
        /// </summary>
        /// <returns>string last name</returns>
        public static string GetLastNameRandomly()
        {
            return lastNameList[rnd.Next(lastNameList.Count)];
        }

    }
}
