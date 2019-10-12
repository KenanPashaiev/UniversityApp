using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    class RandomInfo
    {
        public static Random rnd = new Random();
        private static string[] _nameArray = new string[] { "Casanova", "Olds", "Jenson", "Tijerina", "Flora", "Casto", "Blunt", "Rinaldi", "Fontana", "Minnick", "Larios", "Raynor", "Fung", "Marek", "Valladares", "Clemmons", "Gracia", "Rohrer", "Fryer", "Folsom", "Gearhart", "Sumpter", "Kraemer", "Aceves", "Pettigrew", "Mclaurin", "Southern", "Barrows", "Landeros", "Janes", "Deguzman", "Fredericks", "Mcfall", "Ashe", "Mauro", "Merino", "Windsor", "Taber", "Armijo", "Bricker", "Pitman", "Morrill", "Sanches", "Conlon", "Deboer", "Reuter", "Stegall", "Clemente", "Romine", "Dykstra", "Ehlers", "Tallman", "Lovato", "Brent", "Pearl", "Pyles", "Cloutier", "Mccurry", "Mckeever", "Graziano", "Heflin", "Garman", "Isaacson", "Mcreynolds", "Meister", "Stroup", "Everson", "Halsey", "Mcewen", "Sparkman", "Yager", "Berryman", "Bucher", "Derr", "Jester", "Mickelson", "Sayers", "Whiteman", "Riordan", "Mcinnis", "Goolsby", "Jose", "Stidham", "Donley", "Johnsen", "Stallworth", "Franke", "Silvers", "Reitz", "Nathan", "Brogan", "Cardoso", "Linville", "Baptiste", "Gorski", "Rey", "Hazen", "Damon", "Shores", "Boling", "Jablonski", "Lemieux", "Hecht", "Dong", "Langlois", "Burrow", "Hernandes", "Mcdevitt", "Pichardo", "Lew", "Savoy", "Stillwell", "Teixeira", "Hildreth", "Matheson", "Warfield", "Hogg", "Tiller", "Bristol", "Rudy", "Unruh", "Matias", "Buxton", "Ambriz", "Chiang", "Pogue", "Pomeroy", "Hammock", "Bethel", "Miguel", "Cassell", "Towns", "Bunker", "Mcmichael", "Kress", "Newland", "Whitehurst", "Batten", "Fazio", "Calvillo", "Wallen", "Lung", "Sparrow", "Turney", "Steadman", "Battles", "Berlin", "Lindgren", "Mckeon", "Luckett", "Sherry", "Spradlin", "Timmerman", "Utley", "Beale", "Driggers", "Hintz", "Pellegrino", "Hazel", "Desmond", "Grim", "Spellman", "Boren", "Staten", "Schlegel", "Johnstone", "Maya", "Harwell", "Pinson", "Barreto", "Spooner", "Candelaria", "Hammett", "Sessions", "Mckeown", "Mccool", "Gilson", "Knudson", "Irish", "Spruill", "Kling", "Gerlach", "Carnahan", "Laporte", "Markley", "Flanigan", "Spires", "Cushman", "Plante", "Schlosser", "Sachs", "Hornsby", "Jamieson", "Armstead", "Kremer", "Madera", "Thornburg", "Briley", "Garris", "Jorgenson", "Moorman", "Vuong", "Ard", "Irons", "Fiedler", "Jackman", "Kuehn", "Jenks", "Bristow", "Mosby", "Aldana", "Maclean", "Creighton", "Freund", "Smothers", "Melson", "Lundgren", "Donato", "Usher", "Thornhill", "Lowman", "Button", "Mariano", "Mcbee", "Cupp", "Wickham", "Destefano", "Nutt", "Rambo", "Saxon", "Talbott", "Voigt", "Cedillo", "Mattison", "Speed", "Null", "Reiss", "Westphal", "Whittle", "Bernhardt", "Boatwright", "Bussey", "Eden", "Rojo", "Crites", "He", "Place", "Chaves", "Larose", "Thames", "Hoch", "Knotts", "Simone", "Binkley", "Koester", "Moye", "Pettis", "Napolitano", "Heffner", "Sasser", "Jessup", "Aguiar", "Ogrady", "Pippin", "Worth", "Shively", "Whitmire", "Cedeno", "Rutter", "Welborn", "Mcdougal", "Angell", "Hailey", "Sacco", "Neel", "Paniagua", "Pointer", "Rohde", "Holloman", "Strother", "Guffey", "Fenner", "Huntington", "Shane", "Yuen", "Gosnell", "Martini", "Loving", "Molloy", "Christ", "Olmos", "Oaks", "Badillo", "Ostrowski", "To", "Laplante", "Martindale", "Pleasant", "Richie", "Palomino", "Rodarte", "Stamps", "Peeples", "Ries", "Brownell", "Arana", "Roddy", "Tenney", "Walz", "Bolt", "Lindner", "Rigsby", "Matteson", "Fielder", "Deanda", "Drayton", "Randazzo", "Ridge", "Tarr", "Shade", "Upshaw", "Woodcock", "Hargrave", "Miley", "Langer", "Wilkie", "Yun" };
        private static string[] _subjectArray = new string[] { "Accounting and Finance", "Aeronautical and Manufacturing Engineering", "Agriculture and Forestry", "Anatomy and Physiology", "Anthropology", "Archaeology", "Architecture", "Art and Design", "Biological Sciences", "Building", "Business and Management Studies", "Chemical Engineering", "Chemistry", "Civil Engineering", "Classics and Ancient History", "Communication and Media Studies", "Complementary Medicine", "Computer Science", "Counselling", "Creative Writing", "Criminology", "Dentistry", "Drama Dance and Cinematics", "Economics", "Education", "Electrical and Electronic Engineering", "English", "Fashion", "Film Making", "Food Science", "Forensic Science", "General Engineering", "Geography and Environmental Sciences", "Geology", "Health And Social Care", "History", "History of Art Architecture and Design", "Hospitality Leisure Recreation and Tourism", "Information Technology", "Land and Property Management", "Law", "Linguistics", "Marketing", "Materials Technology", "Mathematics", "Mechanical Engineering", "Medical Technology", "Medicine", "Music", "Nursing", "Occupational Therapy", "Pharmacology and Pharmacy", "Philosophy", "Physics and Astronomy", "Physiotherapy", "Politics", "Psychology", "Robotics", "Social Policy", "Social Work", "Sociology", "Sports Science", "Veterinary Medicine", "Youth Work" };

        public static string GetRandomName()
        {
            //lock{

            //}
            return _nameArray[rnd.Next(0, 320)];
        }

        public static string GetRandomSubject()
        {
            return _subjectArray[rnd.Next(0, 64)];
        }

        public static int GetRandomMark()
        {
            return rnd.Next(40, 100);
        }

        public static int GetRandomNumber(int min, int max)
        {
            return rnd.Next(min, max);
        }

        public static int GetRandomAge(int min, int max)
        {
            return rnd.Next(min, max);
        }
    }
}
