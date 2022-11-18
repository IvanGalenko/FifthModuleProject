namespace FifthModuleProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //(string Name, string LastName, string[] favcolors) User = EnterUser();
            //Console.WriteLine("Ваше имя: {0}",User.Name);
            //Console.WriteLine("Ваша фамилия: {0}",User.LastName);
            //Console.WriteLine("Длина массива: {0}", User.favcolors.GetUpperBound(0));
        }
        static (string Name,
            string LastName,
            int Age,
            bool HasPets,
            string[] Pets,
            string[] favcolors)
            EnterUser()
        {
            (string Name, string LastName, int age, bool HasPets, string[] Pets, string[] favcolors) User;
            Console.Write("Введите Ваше имя: ");
            string Name = Console.ReadLine();

        }



        //(string name, string lname, string[] favcolors) User;
        //User.name = "Иван";
        //    User.lname = "Галенко";
        //    User.favcolors = new string[3];
        //    User.favcolors[0] = "Red";
        //    User.favcolors[1] = "Black";
        //    User.favcolors[2] = "Blue";
        //    return User;


    }
}