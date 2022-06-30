using FXExchange.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FXExchange.Interfaces
{
    public interface IProcessExchange
    {
        decimal ProcessExchangeRequest(string input, ErrorList errorMessages);
    }
}
