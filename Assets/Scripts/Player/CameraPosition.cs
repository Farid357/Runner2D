using UnityEngine;

public sealed class CameraPosition : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    
    private void Update()
    {
        transform.position = PlayerMovement.Position - _offset;
    }
}
