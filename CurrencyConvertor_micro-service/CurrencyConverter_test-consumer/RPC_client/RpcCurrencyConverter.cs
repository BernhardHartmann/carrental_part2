using System;
using System.Threading.Tasks;
using System.Text.Json;

namespace RpcClientCCY
{
    public class RpcCurrencyConverter
    {

        //TODO: the following main class is meant only for demonstration how to get values from the currency converter RPC in synchronous code flow.
        public static void Main(string[] args)
        {
            Console.WriteLine("RPC Client initiated");
            string fromCCY = args.Length > 0 ? args[0] : "USD";
            string toCCY = args.Length > 0 ? args[0] : "EUR";

            RpcRequest request = new RpcRequest
            {
                fromCCY = fromCCY,
                toCCY = toCCY
            };
            Console.WriteLine("RPC request prepared");

            RpcResponse rpcResponse = Task.Run(async () => await GetRpcResult(request)).Result;
            System.Threading.Thread.Sleep(3000);

            //Console for testing and demo only
            Console.WriteLine(rpcResponse.fromCCY);
            Console.WriteLine(rpcResponse.toCCY);
            Console.WriteLine(rpcResponse.exchangeRate);

            //Console.WriteLine(" Press [enter] to exit.");
            //Console.ReadLine();


            //Running test to deployment testing
            var counter = 0;
            var max = args.Length != 0 ? Convert.ToInt32(args[0]) : -1;
            while (max == -1 || counter < max)
            {
                Console.WriteLine($"Counter: {++counter}");
                System.Threading.Thread.Sleep(3000);

                Console.WriteLine(Task.Run(async () => await GetRpcResult(request)).Result.exchangeRate);

                /*
                RpcResponse rpcResponse2 = Task.Run(async () => await GetRpcResult(request)).Result;

                //Console for testing and demo only
                Console.WriteLine(rpcResponse.fromCCY);
                Console.WriteLine(rpcResponse.toCCY);
                Console.WriteLine(rpcResponse.exchangeRate);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
                */



            }

        }

        private static async Task<RpcResponse> GetRpcResult(RpcRequest request)
        {
            Console.WriteLine("async task started");
            string jsonRequest = JsonSerializer.Serialize(request);
            Console.WriteLine("stringify ok");
            var rpcClient = new RpcClientCCY();
            Console.WriteLine("rpcClient ok - waiting for response");
            var response = await rpcClient.CallAsync(jsonRequest);
            Console.WriteLine("reponse received");
            rpcClient.Close();

            RpcResponse rpcResponse = JsonSerializer.Deserialize<RpcResponse>(response);

            return rpcResponse;
        }
    }
}
