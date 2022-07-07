using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(AudioSource), typeof(SpriteRenderer))]
public sealed class CoinCollision : MonoBehaviour
{
    public static event Action OnCollected;
    private SpriteRenderer _renderer;
    private AudioSource _audioSource;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement player))
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            _renderer.enabled = false;
            OnCollected?.Invoke();
            PlayerMovement.IncreaseSpeed();
        }

    }
}
