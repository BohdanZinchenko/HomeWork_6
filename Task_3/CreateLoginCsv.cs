using System;
using System.Collections.Generic;
using System.IO;


namespace Task_3
{
    public class CreateLoginCsv
    {
        private readonly List<PasswordLogin> _listOfLoginsPasswords = new List<PasswordLogin>();
        public void GenerateLoginsPasswords()
        {
            
            var ranNum = new Random();
            for (int i = 0; i < 2000; i++)
            {
                var newPasLogin = new PasswordLogin()
                {
                    Login = Guid.NewGuid(),
                    Password = ranNum.Next(1, 10000000)
                };
                _listOfLoginsPasswords.Add(newPasLogin);
                
                
            }
        }

        public void WriteToCsv()
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter("LoginsCsv.csv", true))
                {
                    foreach (var item in _listOfLoginsPasswords)
                    {
                        streamWriter.WriteLine($"{item.Login};{item.Password}");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Pls close file First");
                
            }
        }
    }
}