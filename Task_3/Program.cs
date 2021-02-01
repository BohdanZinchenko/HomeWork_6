using System;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Login list check program ");
            Console.WriteLine("Student of Pm Academy Zinchenko Bohdan");


            //var createLogin = new CreateLoginCsv();       // this Class for creation list of csv file with login and password 
           //createLogin.GenerateLoginsPasswords();        // this Class for creation list of csv file with login and password 
           //createLogin.WriteToCsv();                     // this Class for creation list of csv file with login and password 


            var workWithFile = new ReadPassLogin();

            if (!workWithFile.GetLogin())
            {
                return;
            }

            Console.Write("How many threads you want to use ? ");
            if (!int.TryParse(Console.ReadLine(), out var num))
            {
                Console.WriteLine("Incorrect input");
                return;
            }

            workWithFile.ThreadLogin(num);
        }
    }
}
