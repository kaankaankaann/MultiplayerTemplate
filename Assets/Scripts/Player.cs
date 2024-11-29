using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public string Name { get; private set; }
    public PlayerCanvasController CanvasController { get; private set; }

    private void Awake()
    {
        CanvasController = GetComponentInChildren<PlayerCanvasController>();
    }

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) return;
        base.OnNetworkSpawn();

        Name = NetworkManagerUI.Instance.nameInputField.text;
    }
}
