using FXExchange.Helper;
using FXExchange.Interfaces;
using FXExchange.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FXExchange
{
    public class ExchangeRate : IExchangeRateInterface
    {
        Dictionary<string, RateExchangeModel> exchangeRequest = new Dictionary<string, RateExchangeModel>();
        public Dictionary<string, RateExchangeModel> GetExchangeRate()
        {
            exchangeRequest = RateExchange.GetExchangeRate();
            return exchangeRequest;
        }
    }
}
