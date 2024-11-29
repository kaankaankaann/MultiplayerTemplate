using Unity.Netcode;
using UnityEngine;

public class ShooterController : NetworkBehaviour
{
    public LayerMask _playerLayer;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out RaycastHit hit, 500, _playerLayer))
        {
        }
    }
}
