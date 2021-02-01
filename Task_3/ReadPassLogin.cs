using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;


namespace Task_3
{
    public class ReadPassLogin
    {
        private readonly ConcurrentQueue<PasswordLogin> _concurrentCollection= new ConcurrentQueue<PasswordLogin>();
        public bool GetLogin()
        {
            try
            {
                var streamReader = new StreamReader("LoginsCsv.csv");
                
                while (true)
                {
                    var splits = streamReader.ReadLine()?.Split(';');
                    if (splits == null)
                    {
                        break;
                    }
                    var newPassLog = new PasswordLogin()
                    {
                       Login = Guid.Parse(splits[0]),
                        Password = int.Parse(splits[1])
                    };

                    _concurrentCollection.Enqueue(newPassLog);

                }
               

            }
            catch
            {
                Console.WriteLine("File don`t founded");
                return false;
            }

            return true;

        }
        public void ThreadLogin(int numOfThread)
        {
            var cdEvent = new CountdownEvent(_concurrentCollection.Count);

            for (var i = 0; i < numOfThread; i++)
            {
                Thread newThread = new Thread(() => LoginClient.StartLogin(_concurrentCollection, cdEvent));
                newThread.Start();
            }

            cdEvent.Wait();

            LoginClient.WriteCountOfLogin();

        }

    }
    
}