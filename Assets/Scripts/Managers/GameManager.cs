using System;
using Unity.Netcode;

namespace Managers
{
    public class GameManager : NetworkBehaviour
    {
        public static Action<ulong> OnClientConnected;

        private void Awake()
        {
            NetworkManager.OnClientConnectedCallback += InvokeRpc;
        }

        [Rpc(SendTo.Everyone, RequireOwnership = false)]
        private void InvokeRpc(ulong id)
        {
            OnClientConnected?.Invoke(id);
        }
    }
}