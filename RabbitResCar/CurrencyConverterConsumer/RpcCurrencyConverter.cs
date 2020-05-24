using System;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;

namespace CurrencyConverterClient
{
    public class RpcCurrencyConverter
    {
        public static async Task<RpcResponse> GetRpcResult(RpcRequest request)
        {
            //JSON in .NET Core
            //string jsonRequest = JsonSerializer.Serialize(request);

            //JSON in .NET Framework
            string jsonRequest = JsonConvert.SerializeObject(request);

            var rpcClient = new RpcClientCCY();
      
            var response = await rpcClient.CallAsync(jsonRequest);
       
            rpcClient.Close();

            //JSON in .NET Core
            //RpcResponse rpcResponse = JsonSerializer.Deserialize<RpcResponse>(response);

            //JSON in .NET Framework
            RpcResponse rpcResponse = JsonConvert.DeserializeObject<RpcResponse>(response);

            return rpcResponse;
        }
    }
}
