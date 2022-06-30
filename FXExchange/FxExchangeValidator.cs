using FXExchange.Helper;
using FXExchange.Interfaces;
using FXExchange.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FXExchange
{
    public class FxExchangeValidator : IFxExchangeValidator
    {
        public ExchangeRequest ValidateRequest(string inputRequest, Dictionary<string, RateExchangeModel> exchangeRateList, ErrorList errorMessages)
        {
            ExchangeRequest exchangeRequest = new ExchangeRequest();
            if (string.IsNullOrWhiteSpace(inputRequest))
            {
                errorMessages.ErrorMessage = Constants.EmptyRequest;
                return exchangeRequest;
            }

            exchangeRequest = ParseRequest(inputRequest);
            if (string.IsNullOrWhiteSpace(exchangeRequest.TargetCurrency) || string.IsNullOrWhiteSpace(exchangeRequest.SourceCurrency) || exchangeRequest.InputQuantity <= 0)

            {
                errorMessages.ErrorMessage = Constants.InvalidRequest;
                return exchangeRequest;
            }

            if (!exchangeRateList.ContainsKey(exchangeRequest.SourceCurrency) || !exchangeRateList.ContainsKey(exchangeRequest.TargetCurrency))
                errorMessages.ErrorMessage = Constants.NotAvailableISO;


            return exchangeRequest;


        }


        private ExchangeRequest ParseRequest(string inputRequest)
        {
            ExchangeRequest exchange = new ExchangeRequest();
            try
            {
                string[] splitRequest = inputRequest.Split(" ");
                string[] splitCurrency = splitRequest[0].Split("/");

                exchange.SourceCurrency = splitCurrency[0];
                exchange.TargetCurrency = splitCurrency[1];
                exchange.InputQuantity = Convert.ToDouble(splitRequest[1]);
                return exchange;
            }
            catch (Exception ex)
            {
                return exchange;
            }

        }


    }
}
