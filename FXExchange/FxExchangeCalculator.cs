using FXExchange.Helper;
using FXExchange.Interfaces;
using FXExchange.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FXExchange
{
    public class FxExchangeCalculator : IFxExchangeCalculator
    {
        public decimal ProcessExchange(string sourceCurrency, string targetCurrency, double quantity, Dictionary<string, RateExchangeModel> exchangeRequest)
        {
            return (decimal)((exchangeRequest[sourceCurrency].Amount / exchangeRequest[targetCurrency].Amount) * quantity);
        }        
    }
}
