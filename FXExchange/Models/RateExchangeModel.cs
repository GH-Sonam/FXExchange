using System;
using System.Collections.Generic;
using System.Text;

namespace FXExchange.Models
{
    public class RateExchangeModel
    {
        public string Currency { get; set; }
        public string ISO { get; set; }
        public double Amount { get; set; }
    }
}
