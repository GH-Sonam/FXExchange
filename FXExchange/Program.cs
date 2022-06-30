using FXExchange.Interfaces;
using FXExchange.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FXExchange
{
    class FXExchange
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var processExchangeService = host.Services.GetService<IProcessExchange>();

            bool loop = true;

            Console.WriteLine("=============Exchange==================");

            while (loop)
            {
                Console.WriteLine("Usage: Exchange <currency pair> <amount to exchange>");
                Console.WriteLine("Press 'exit' to break.");
                string userRequest = Console.ReadLine();

                if (userRequest == "exit")
                {
                    loop = false;
                    break;
                }


                ErrorList errorList = new ErrorList();
                decimal exchangePrice = processExchangeService.ProcessExchangeRequest(userRequest, errorList);

                if (!string.IsNullOrWhiteSpace(errorList.ErrorMessage))
                    Console.WriteLine(errorList.ErrorMessage);
                else
                    Console.WriteLine(exchangePrice);

                Console.WriteLine();
            }

        }

        //public static double ExchangeCalculator(string exchangeRate, double quantity)
        //{ 

        //}


        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<IFxExchangeValidator, FxExchangeValidator>();
                    services.AddScoped<IFxExchangeCalculator, FxExchangeCalculator>();
                    services.AddScoped<IProcessExchange, ProcessExchange>();
                    services.AddSingleton<IExchangeRateInterface, ExchangeRate>();
                });

            return hostBuilder;
        }
    }
}
