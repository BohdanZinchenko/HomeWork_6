using System;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Text.Json;
using System.Threading;
using Microsoft.IdentityModel.Tokens;

namespace Task_3
{
    
    public  class LoginClient
    {
        private static int _login = 0;
        private static int  _notLogin = 0;

        
       
        public static void StartLogin(ConcurrentQueue<PasswordLogin> collection,CountdownEvent cdEvent)
        {
            var elem = new PasswordLogin();
            while (collection.TryDequeue(out elem))
            {
                var token = Login(elem.Login, elem.Password);
                if (token == null)
                {
                    Interlocked.Increment(ref _login);
                }
                else
                {
                    Interlocked.Increment(ref _notLogin);
                }
                cdEvent.Signal();
                
            }

        }
        private static string Login(Guid login, int password)
        {
            var rand = new Random();
            if (rand.NextDouble() < 0.5)
            {
                return null;
            }

            var freezTime = rand.Next(1, 1000);

            Thread.Sleep(freezTime);
            
            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.CreateToken(new SecurityTokenDescriptor()).ToString();


        }

        public static void WriteCountOfLogin()
        {
            var loginStruct = new LoginAndNotLogin()
            {
                Successful = _login,
                Failed = _notLogin
            };
            try
            {
                JsonSerializer.Serialize(loginStruct);
            }
            catch
            {
                Console.WriteLine("something gone wrong with writing File ");
            }
            File.WriteAllText("result.json", JsonSerializer.Serialize(loginStruct));

        }
    }
}