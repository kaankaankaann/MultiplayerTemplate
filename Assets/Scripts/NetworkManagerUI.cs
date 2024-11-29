using DG.Tweening;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : Singleton<NetworkManagerUI>
{
    private CanvasGroup _group;
    [SerializeField] public TMP_InputField nameInputField;
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;

    private void Awake()
    {
        hostButton.onClick.AddListener(HostButtonHandler);
        clientButton.onClick.AddListener(ClientButtonHandler);
        _group = GetComponent<CanvasGroup>();
    }

    private void HostButtonHandler()
    {
        NetworkManager.Singleton.StartHost();

        _group.DOFade(0, 0.5f);
    }

    private void ClientButtonHandler()
    {
        NetworkManager.Singleton.StartClient();
        _group.DOFade(0, 0.5f);
    }
}
