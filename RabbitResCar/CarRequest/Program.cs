using CarsRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyConverterClient;

namespace CarsRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectMessageToCars directmessages = new DirectMessageToCars();
            directmessages.SendMessageToCars();
            Console.ReadLine();

        //EXAMPLE exchange request
            //step 1 - create request
            RpcRequest request = new RpcRequest { fromCCY = "USD", toCCY = "EUR"};
            //step 2 - send request 
            RpcResponse testResponse = Task.Run(async () => await RpcCurrencyConverter.GetRpcResult(request)).Result;
            //step 3 - read response
            double exchangeRate = testResponse.exchangeRate;
        }
    }
}
