using Unity.Netcode;
using UnityEngine;

public class NetworkSingleton<T> : NetworkBehaviour where T : Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            return _instance;
        }
    }

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) return;
        _instance = this as T; 
    }
}

