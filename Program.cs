using System.ComponentModel;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace BasicAuthentication;

class Program
{
    class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

    }

    class DataUser
    {
        public static List<User> users = new List<User>();
    }

    public static void Main()
    {
        char select = 'Y';
        do
        {
            HomeMenu();
            int input = int.Parse(Console.ReadLine());

            if (input == 1)
            {
                Create();
                Console.Write("Back to Home? Y/N : ");
                select = char.Parse(Console.ReadLine());
            }
            else if (input == 2)
            {
                Show();
                Menu();
            }
            else if (input == 3)
            {
                Search();
                Console.Write("Back to Home? Y/N : ");
                select = char.Parse(Console.ReadLine());
            }
            else if (input == 4)
            {
                Login();
                Console.Write("Back to Home? Y/N : ");
                select = char.Parse(Console.ReadLine());
            }
            else if (input == 5)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Input yang anda masukkan salah");

                Console.Write("Back to Home? Y/N : ");
                select = char.Parse(Console.ReadLine());
            }
        } while (select == 'Y' || select == 'y');

        Console.ReadKey();
    }
    
    public static void HomeMenu()
    {
        Console.Clear();
        Console.WriteLine("== BASIC AUTHENTICATION");
        Console.WriteLine("\t1. Create User");
        Console.WriteLine("\t2. Show User");
        Console.WriteLine("\t3. Search User");
        Console.WriteLine("\t4. Login User");
        Console.WriteLine("\t5. Exit");
        Console.WriteLine();
        Console.Write("Input : ");
    }
    
    public static void Menu()
    {
        Console.WriteLine("Menu");
        Console.WriteLine("\t1. Edit User");
        Console.WriteLine("\t2. Delete User");
        Console.WriteLine("\t3. Back");
        Console.WriteLine("");
        int inputMenu = int.Parse(Console.ReadLine());

        if (inputMenu == 1)
        {
            Update();
        }
        else if (inputMenu == 2)
        {
            Delete();
        }
        else if (inputMenu == 3)
        {
            HomeMenu();
        }
    }
    
    public static void Create()
    {
        Console.Clear();
        User user = new User();

        Console.Write("First Name : ");
        user.FirstName = Console.ReadLine();
        Console.Write("Last Name : ");
        user.LastName = Console.ReadLine();
        Console.Write("Password : ");
        user.Password = Console.ReadLine();
        if (user.Password.Length < 8 || !user.Password.Any(char.IsDigit) || !user.Password.Any(char.IsLower) || !user.Password.Any(char.IsUpper))
        {
            Console.WriteLine("Password must have at least 8 characters, with at least one Capital letter, at least one lower case letter and at least one number");
        }
        else
        {
            user.Id = DataUser.users.Count > 0 ? DataUser.users.Max(x => x.Id) + 1 : 1;
            DataUser.users.Add(user);
            Console.WriteLine();
            Console.WriteLine("Data User Berhasil Dibuat");
        }
    }

    public static void Show()
    {
        Console.Clear();
        var listResult = DataUser.users.ToList();

        foreach (var item in listResult)
        {
            User user = new User();
            Console.WriteLine("==SHOW USER");
            Console.WriteLine("===================");
            Console.WriteLine($"ID: {item.Id}");
            Console.WriteLine($"FirstName: {item.FirstName}");
            Console.WriteLine($"LastName: {item.LastName}");
            Console.WriteLine($"Username: {item.FirstName.Substring(0, 2) + item.LastName.Substring(0, 2)}");

            Console.WriteLine($"Password: {item.Password}");
            Console.WriteLine("===================");
        }
        Console.ReadKey();
    }
   
    public static void Search()
    {
        Console.Clear();
        Console.WriteLine("* Keterangan : Sensitive Case");
        Console.WriteLine("==Cari Akun==");
        Console.Write("Masukkan Nama : ");
        string searchName = Console.ReadLine();
        Console.WriteLine("=============================");

        User user = DataUser.users.SingleOrDefault(x => 
            x.UserName == searchName || 
            x.FirstName == searchName || 
            x.LastName == searchName);

        while (user == null)
        {
            Console.WriteLine("== Akun Tidak Ditemukan ==");
            Console.Write("Masukkan Nama : ");
            searchName = Console.ReadLine();

            user = DataUser.users.SingleOrDefault(x =>
                x.UserName == searchName ||
                x.FirstName == searchName ||
                x.LastName == searchName);
        }

        Console.WriteLine();
        var listResult = DataUser.users.ToList();
        foreach (var User in listResult.Where(x =>
            x.UserName == searchName ||
            x.FirstName == searchName ||
            x.LastName == searchName))
        {
            Console.WriteLine("===================");
            Console.WriteLine($"ID : {User.Id}");
            Console.WriteLine($"FirstName : {User.FirstName}");
            Console.WriteLine($"LastName : {User.LastName}");
            Console.WriteLine($"Username: {User.FirstName.Substring(0, 2) + User.LastName.Substring(0, 2)}");
            Console.WriteLine($"Password : {User.Password}");
            Console.WriteLine("===================");
        }
    }
    
    public static void Login()
    {
        Console.Clear();

        Console.WriteLine("==LOGIN==");
        Console.Write("USERNAME :");
        string username
            Console.WriteLine("Login Berhasil");
        }
        else = Console.ReadLine();
        Console.Write("PASSWORD :");
        string password = Console.ReadLine();

        User login = DataUser.users.SingleOrDefault(x => x.UserName == username && x.Password == password);
        if (login != null)
        {
        {
            Console.WriteLine("Login Gagal");
        }
    }
    
    public static void Update()
    {
        Console.Write("Id yang Ingin Diubah :");
        int id = int.Parse(Console.ReadLine());
        User user = DataUser.users.SingleOrDefault(x => x.Id == id);
        while (user == null)
        {
            Console.WriteLine("Id User Tidak Ditemukan");
            Console.Write("Id yang Ingin Diubah :");
            id = int.Parse(Console.ReadLine());
            user = DataUser.users.SingleOrDefault(x => x.Id == id);
        }

        Console.WriteLine();
        foreach (var User in DataUser.users.Where(x => x.Id == id))
        {
            Console.Write("First Name : ");
            User.FirstName = Console.ReadLine();
            Console.Write("Last Name : ");
            User.LastName = Console.ReadLine();
            Console.Write("Password :");
            User.Password = Console.ReadLine();
        }

        Console.WriteLine();
        Console.WriteLine("User Sudah Berhasil Di Edit");
    }

    public static void Delete()
    {
        Console.WriteLine("Id Yang Ingin Dihapus :");
        int id = int.Parse(Console.ReadLine());
        User user = DataUser.users.SingleOrDefault(x => x.Id == id);

        while (user == null)
        {
            Console.WriteLine("Id User Tidak Ditemukan");
            Console.Write("Id Yang Ingin Dihapus :");
            id = int.Parse(Console.ReadLine());
            user = DataUser.users.SingleOrDefault(x => x.Id == id);
        }

        DataUser.users.Remove(user);
        Console.WriteLine();
        Console.WriteLine("Akun Berhasil Dihapus");
    }
}