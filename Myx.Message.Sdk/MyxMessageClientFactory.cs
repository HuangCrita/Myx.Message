using System;
using System.Collections.Generic;
using System.Text;

namespace Myx.Message.Sdk
{
    public class MyxMessageClientFactory
    {
        private static Dictionary<string, IMyxMessageClient> clients = new Dictionary<string, IMyxMessageClient>();
        public static IMyxMessageClient Create(string serverUrl)
        {
            if(!clients.ContainsKey(serverUrl))
            {
                clients.Add(serverUrl, new MyxMessageClient(serverUrl));
            }
            return clients[serverUrl];
        }
    }
}
