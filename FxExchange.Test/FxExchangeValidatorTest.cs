using FXExchange;
using FXExchange.Helper;
using FXExchange.Interfaces;
using FXExchange.Models;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FxExchange.Test
{
    public class FxExchangeValidatorTest
    {
        Mock<IServiceProvider> mockServiceProvider = new Mock<IServiceProvider>();
        Mock<IServiceScope> mockServiceScope = new Mock<IServiceScope>();
        Mock<IFxExchangeValidator> fxValidator = new Mock<IFxExchangeValidator>();

        private readonly FxExchangeValidator fxExchangeValidator;
        Dictionary<string, RateExchangeModel> exchangeRateList;

        public FxExchangeValidatorTest()
        {
            mockServiceScope.SetupGet<IServiceProvider>(s => s.ServiceProvider).Returns(mockServiceProvider.Object);

            var serviceScopeFactoryMock = new Mock<IServiceScopeFactory>();
            serviceScopeFactoryMock.Setup(s => s.CreateScope()).Returns(mockServiceScope.Object);
            mockServiceProvider.Setup(s => s.GetService(typeof(IFxExchangeValidator))).Returns(fxValidator.Object);
            fxExchangeValidator = new FxExchangeValidator();
            exchangeRateList = RateExchange.GetExchangeRate();
        }

        [Fact]
        public void Test1()
        {
            //Arrange
            string input = "EUR/DKK 1";
            ErrorList errorList = new ErrorList(); ;

            //Act
            ExchangeRequest result = fxExchangeValidator.ValidateRequest(input, exchangeRateList, errorList);

            //Assert
            Assert.True(string.IsNullOrWhiteSpace(errorList.ErrorMessage));

            Assert.Equal(result.InputQuantity.ToString(),"1");
            Assert.Equal(result.SourceCurrency.ToString(), "EUR");
            Assert.Equal(result.TargetCurrency.ToString(), "DKK");
        }

        public void Sample_Success_Case()
        {
            //Arrange
            string input = "EUR/DKK 1";
            ErrorList errorList = new ErrorList(); ;

            //Act
            ExchangeRequest result = fxExchangeValidator.ValidateRequest(input, exchangeRateList, errorList);

            //Assert
            Assert.True(string.IsNullOrWhiteSpace(errorList.ErrorMessage));

            Assert.Equal(result.InputQuantity.ToString(), "1");
            Assert.Equal(result.SourceCurrency.ToString(), "EUR");
            Assert.Equal(result.TargetCurrency.ToString(), "DKK");
        }

        [Fact]
        public void EmptyRequest_Failure_Case()
        {
            //Arrange
            string input = "";
            ErrorList errorList = new ErrorList(); ;

            //Act
            ExchangeRequest result = fxExchangeValidator.ValidateRequest(input, exchangeRateList, errorList);

            //Assert
            Assert.True(!string.IsNullOrWhiteSpace(errorList.ErrorMessage));

            Assert.Equal(errorList.ErrorMessage, Constants.EmptyRequest);
        }

        [Fact]
        public void InvalidRequest_Failure_Case()
        {
            //Arrange
            string input = "EUR 1";
            ErrorList errorList = new ErrorList(); ;

            //Act
            ExchangeRequest result = fxExchangeValidator.ValidateRequest(input, exchangeRateList, errorList);

            //Assert
            //Assert
            Assert.True(!string.IsNullOrWhiteSpace(errorList.ErrorMessage));

            Assert.Equal(errorList.ErrorMessage, Constants.InvalidRequest);
        }

        [Fact]
        public void InvalidISoCode_Failure_Case()
        {
            //Arrange
            string input = "EUR/INR 1";
            ErrorList errorList = new ErrorList(); ;

            //Act
            ExchangeRequest result = fxExchangeValidator.ValidateRequest(input, exchangeRateList, errorList);

            //Assert
            //Assert
            Assert.True(!string.IsNullOrWhiteSpace(errorList.ErrorMessage));

            Assert.Equal(errorList.ErrorMessage, Constants.NotAvailableISO);
        }
    }
}
