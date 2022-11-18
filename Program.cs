using System.Reflection;

namespace FifthModuleProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Все комментарии в файле Readme.md
            (string Name, string LastName, int Age, string[] Pets, string[] favcolors) User = EnterUser();
            PrintTuple(User);
        }
        static (string Name, string LastName, int Age, string[] Pets, string[] favcolors) EnterUser()
        {
            (string Name, string LastName, int Age, string[] Pets, string[] favcolors) User;
            Console.Write("Введите Ваше имя: ");
            User.Name = CheckStr();
            Console.Write("Введите Вашу фамилию: ");
            User.LastName = CheckStr();
            User.Age = CheckInt("Сколько Вам полных лет? ", true);
            bool HasPets = CheckBool("У вас есть животные? Да или нет: ");
            if (HasPets == true)
            {
                int PetsCount = CheckInt("Сколько у Вас животных? ", true);
                User.Pets = EnterArray(PetsCount);
            }
            else User.Pets = new string[0];
            int ColorsCount = CheckInt("Сколько у вас любимых цветов? ", false);
            if (ColorsCount > 0) User.favcolors = EnterArray(ColorsCount);
            else User.favcolors = new string[0];
            return User;
        }
        static string[] EnterArray(int Count)
        {
            string[] Array = new string[Count];
            for (int i = 0; i < Count; i++)
            {
                Console.Write("{0}-й: ", i + 1);
                Array[i] = CheckStr();
            }
            return Array;
        }
        static string CheckStr()
        {
            bool check = false;
            string temp;
            do
            {
                temp = Console.ReadLine().Trim();
                bool intstr = int.TryParse(temp, out int result);
                if ((temp.Length > 0)&(intstr==false)) check = true;
                else Console.Write("Повторите ввод: ");
            }
            while (check == false);
            return temp;
        }
        static int CheckInt(string Text, bool Positive)
        {
            Console.Write(Text);
            bool check, doublecheck = false;
            int result = 0;
            do
            {
                check = int.TryParse(Console.ReadLine(), out result);
                if (Positive)
                {
                    if ((check == false) | (result < 1))
                        Console.Write("Ошибка! Введите, пожалуйста, положительное число: ");
                    else doublecheck = true;
                }
                else
                {
                    if ((check == false) | (result < 0))
                        Console.Write("Ошибка! Введите, пожалуйста, неотрицательное число: ");
                    else doublecheck = true;
                }
            }
            while (doublecheck == false);
            return result;
        }
        static bool CheckBool(string Text)
        {
            Console.Write(Text);
            bool check = false;
            bool result = false;
            do
            {
                string temp = Console.ReadLine();
                if ((temp == "Да") | (temp == "да") | (temp == "ДА"))
                {
                    result = true;
                    check = true;
                }
                else if ((temp == "Нет") | (temp == "нет") | (temp == "НЕТ"))
                {
                    result = false;
                    check = true;
                }
                if (check == false) Console.Write(Text);
            }
            while (check == false);
            return result;
        }
        static void PrintTuple((string Name, string LastName, int Age, string[] Pets, string[] favcolors) User)
        {
            Console.Clear();
            Console.WriteLine("Ваше имя: {0}", User.Name);
            Console.WriteLine("Ваша фамилия: {0}", User.LastName);
            Console.WriteLine("Ваш возраст: {0}", User.Age);
            if (User.Pets.GetUpperBound(0)+1>0)
            {
                Console.WriteLine("У Вас есть питомцы:");
                foreach (var pet in User.Pets)
                {
                    Console.WriteLine(pet);
                }
            }
            else if (User.Pets.GetUpperBound(0)+1 == 0) Console.WriteLine("У Вас нет питомцев");
            if (User.favcolors.GetUpperBound(0) + 1 > 0)
            {
                Console.WriteLine("Количество любимых Вами цветов: {0}. Вот они:", User.favcolors.GetUpperBound(0)+1);
                foreach (var color in User.favcolors)
                {
                    Console.WriteLine(color);
                }
            }
            else if (User.favcolors.GetUpperBound(0) + 1 == 0) Console.WriteLine("У Вас нет любимых цветов");

        }
    }
}