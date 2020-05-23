using System;
using System.Collections.Generic;
using System.Text;

namespace RpcClientCCY
{
    //TODO: include this class in the microservice communicating with the currency converter.
    public class RpcResponse
    {
        public string fromCCY { get; set; }
        public string toCCY { get; set; }

        public double exchangeRate { get; set; }
    }
}
