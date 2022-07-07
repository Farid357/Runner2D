using UnityEngine;

public sealed class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    private const int LeftButton = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftButton))
        {
            _player.Jump();
        }
    }
}
