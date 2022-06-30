using FXExchange.Models;
using System;
using System.Collections.Generic;
using System.Text;
using FXExchange.Models;
using System.Threading.Tasks;
using FXExchange.Interfaces;

namespace FXExchange
{
    public class ProcessExchange : IProcessExchange
    {
        private readonly IFxExchangeCalculator fxExchangeCalculator;

        private readonly IFxExchangeValidator fxExchangeValidator;
        private readonly IExchangeRateInterface exchangeRateInterface;

        public ProcessExchange(IFxExchangeCalculator fxExchangeCalculatorService, IFxExchangeValidator fxExchangeValidatorService, IExchangeRateInterface exchangeRateInterfaceService)
        {
            fxExchangeValidator = fxExchangeValidatorService;
            fxExchangeCalculator = fxExchangeCalculatorService;
            exchangeRateInterface = exchangeRateInterfaceService;
        }

        public decimal ProcessExchangeRequest(string input, ErrorList errorMessages)
        {
            Dictionary<string, RateExchangeModel> exchangeRate = exchangeRateInterface.GetExchangeRate();

            ExchangeRequest exchangeRequest = fxExchangeValidator.ValidateRequest(input, exchangeRate, errorMessages);

            if (!string.IsNullOrWhiteSpace(errorMessages.ErrorMessage))
            return -1;

            return fxExchangeCalculator.ProcessExchange(exchangeRequest.SourceCurrency, exchangeRequest.TargetCurrency, exchangeRequest.InputQuantity, exchangeRate);

        }


    }
}
