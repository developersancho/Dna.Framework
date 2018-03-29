using System;
using Dna;
using Dna.Framework;
using WebApplication1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set Up the DNA Framework
            //Framework.Build();
            new DefaultFrameworkConstruction()
                .UseFileLogger()
                .Build();
            var result = WebRequests.PostAsync("http://localhost:1127/api/values/test");

            var result2 = WebRequests.PostAsync<SettingsDataModel>("http://localhost:1127/api/values/test",
                new SettingsDataModel { Id = "some id", Name = "Luke", Value = "10" },
                sendType: KnownContentSerializers.Json,
                returnType: KnownContentSerializers.Json);
            var a = result;
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
