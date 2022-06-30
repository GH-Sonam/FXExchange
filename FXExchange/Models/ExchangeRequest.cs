using System;
using System.Collections.Generic;
using System.Text;

namespace FXExchange.Models
{
    public class ExchangeRequest
    {
        public string SourceCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public double InputQuantity { get; set; }
    }
}
