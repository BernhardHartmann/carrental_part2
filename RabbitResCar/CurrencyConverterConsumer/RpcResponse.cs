﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverterClient
{
    public class RpcResponse
    {
        public string fromCCY { get; set; }
        public string toCCY { get; set; }
        public double exchangeRate { get; set; }
    }
}
