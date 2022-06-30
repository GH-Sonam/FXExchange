using FXExchange.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FXExchange.Helper
{
    public static class RateExchange
    {
        static Dictionary<string, RateExchangeModel> exchangeRateList = new Dictionary<string, RateExchangeModel>()
        {
            { "EUR", new RateExchangeModel() { Currency = "Euro", ISO = "EUR", Amount = 743.94 }},
            {"USD", new RateExchangeModel() { Currency = "Amerikanske dollar", ISO = "USD", Amount = 663.11 }},
            { "GBP", new RateExchangeModel() { Currency = "Britiske pund", ISO = "GBP", Amount = 852.85 }},
            {"SEK", new RateExchangeModel() { Currency = "Svenske kroner", ISO = "SEK", Amount = 76.10 } },
            { "NOK", new RateExchangeModel() { Currency = "Norske kroner", ISO = "NOK", Amount = 78.40 }},
            { "CHF", new RateExchangeModel() { Currency = "Schweiziske franc", ISO = "CHF", Amount = 683.58 }},
            { "JPY", new RateExchangeModel() { Currency = "Japanske yen", ISO = "JPY", Amount = 5.9740 } },
            { "DKK", new RateExchangeModel() { Currency = "DKK", ISO = "DKK", Amount = 100 }}

        };

        public static Dictionary<string, RateExchangeModel> GetExchangeRate()
        {
            return exchangeRateList;
        }
    }
}
