using FXExchange.Models;
using System.Collections.Generic;

namespace FXExchange.Interfaces
{
    public interface IFxExchangeValidator
    {
        ExchangeRequest ValidateRequest(string inputRequest, Dictionary<string, RateExchangeModel> exchangeRateList, ErrorList errorMessages);
    }
}