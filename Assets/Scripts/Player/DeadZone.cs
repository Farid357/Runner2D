using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public sealed class DeadZone : MonoBehaviour
{
    public event Action OnPlayerCatched;
    private Camera _camera;
    private Vector2 _screenMin;
    private float Offest = 4.8f;

    private void Start()
    {
        _camera = Camera.main;
        _screenMin = _camera.ScreenToWorldPoint(Screen.safeArea.min);
       
    }

    private void Update()
    {
        transform.position = new Vector3(PlayerMovement.Position.x, _screenMin.y - Offest, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement player))
        {
            collision.gameObject.SetActive(false);
            OnPlayerCatched.Invoke();
        }
    }
}
