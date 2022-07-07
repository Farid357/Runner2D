using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(AudioSource))]
public sealed class SpikeCollision : MonoBehaviour
{
    public static event Action OnPlayerCatched;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement player))
        {
            _audioSource.Play();
            OnPlayerCatched.Invoke();
            player.gameObject.SetActive(false);
        }
    }
}
