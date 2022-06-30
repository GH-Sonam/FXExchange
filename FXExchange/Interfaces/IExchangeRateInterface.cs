using FXExchange.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FXExchange.Interfaces
{
    public interface IExchangeRateInterface
    {
        Dictionary<string, RateExchangeModel> GetExchangeRate();
    }
}
