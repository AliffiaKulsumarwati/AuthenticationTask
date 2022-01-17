using System;
using System.Collections.Generic;

namespace Username
{
    class Program
    {
        public static List<User> users = new List<User>();

        static void Main(string[] args)
        {
            MenuUtama();//Menu Utama
            Pilihan();
        }

        private static void Pilihan()
        {
            switch (PilihMenu())
            {
                case 1:
                    //Console.Clear();
                    users.Add(Regis(users));
                    Console.Clear();
                    MenuUtama();
                    Pilihan();
                    break;
                case 2:
                    UserAccounts(users);
                    break;
                case 3:
                    Search();
                    break;
                case 4:
                    Console.Clear();
                    Login(users);
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }

        private static void Login(List<User> users)

        {
           
            Console.WriteLine("=Login User=");//test
            Console.Write("Masukkan username: ");
            string inUser = Console.ReadLine();
            Console.Write("Masukkan Password: ");
            string inPwd = Console.ReadLine();

            foreach (User user in users)
            {
                if (user.UserName == inUser)
                {
                    if (BCrypt.Net.BCrypt.Verify(inPwd, user.Passwd))
                    {
                        Console.WriteLine("Berhasil Login!");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Password Salah!");
                        Login(users);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Email Salah");
                    Login(users);
                }
            }
            Kembali();

        }

        private static void UserAccounts(List<User> users)//now
        {
            if (users.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Belum ada Pengguna");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("=Pengguna Terdaftar=");
                foreach (User user in users)
                    user.TampilAkun();
                Console.WriteLine("=====");
            }
            Kembali();
        }

        private static User Regis(List<User> users)//regis user
        {
            string uName = "";
            string fName;
            string lName;
            string passwd;
            {
                Console.Clear();
                Console.WriteLine("=Registrasi User=");
                Console.Write("Nama Depan: ");
                fName = Console.ReadLine();
                Console.Write("Nama Belakang: ");
                lName = Console.ReadLine();
                Console.Write("Password Akun: ");
                string pw = Console.ReadLine();
                passwd = BCrypt.Net.BCrypt.HashPassword(pw);
                if (fName.Length >= 2 && lName.Length >= 2 && pw.Length >= 6)
                {
                    string[] uName1 = fName.Split();
                    string[] uName2 = lName.Split();
                    uName = uName1[0].Substring(0, 1) + "." + uName2[0].Substring(0, 2) + "@email.com";
                    uName = uName.ToString();
                }
                else
                {
                    Regis(users);
                    ErrorMes();
                }


            }
            return new User(fName, lName, uName, passwd);
        }

        private static void Search()
        {
            Console.Clear();
            Console.WriteLine("Fitur Belum Tersedia");
            Kembali();
        }

        private static int PilihMenu()
        {
            Console.Write("Pilih Menu: ");
            int selection = 0;
            try
            {
                selection = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.Clear();
                MenuUtama();
                Pilihan();
            }
            return selection;
        }

        private static void ErrorMes()//buat error
        {
            Console.WriteLine("Terjadi Kesalahan");
        }

        static void MenuUtama()
        {
            Console.WriteLine("=Basic Authentication=");
            Console.WriteLine("1. User Baru");
            Console.WriteLine("2. Info User");
            Console.WriteLine("3. Search");
            Console.WriteLine("4. Login");
            Console.WriteLine("5. Keluar");
        }

        static void Kembali()
        {
            Console.WriteLine("Kembali? (Y/N)");
            string inputan = Console.ReadLine().ToLower();
            switch (inputan)
            {
                case "y":
                    Console.Clear();
                    MenuUtama();
                    Pilihan();
                    break;
                case "n":
                    Console.Clear();
                    break;
                default:
                    Kembali();
                    break;
            }
        }
    }
}
