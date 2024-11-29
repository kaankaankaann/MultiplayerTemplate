using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class PlayerCanvasController : NetworkBehaviour
{
    private Dictionary<ulong, PlayerCanvasController> _otherPlayers = new();
    public TMP_Text playerName;

    private void RefreashCanvasList(ulong obj)
    {
        _otherPlayers = new();
        foreach (var client in NetworkManager.Singleton.ConnectedClients)
        {
            if (client.Value.ClientId != OwnerClientId)
            {
                _otherPlayers.Add(client.Value.ClientId, client.Value.PlayerObject.GetComponent<Player>().CanvasController);
            }
        }
        SetNameRpc(OwnerClientId, NetworkManagerUI.Instance.nameInputField.text);
    }

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) return;
        GameManager.OnClientConnected += RefreashCanvasList;
        GetComponent<Canvas>().enabled = false;
    }

    private void Update()
    {
        foreach (var item in _otherPlayers)
        {
            item.Value.transform.LookAt(Camera.main.transform);
        }
    }

    [Rpc(SendTo.NotMe , RequireOwnership = false)]
    public void SetNameRpc(ulong id, string name)
    {
        foreach (var item in NetworkManager.Singleton.ConnectedClients)
        {
            if (item.Value.ClientId == id)
            {
                item.Value.PlayerObject.GetComponent<Player>().CanvasController.playerName.text = name;
            }
        }
    }
}
