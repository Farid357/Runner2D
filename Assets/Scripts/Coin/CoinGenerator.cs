using UnityEngine;
using Tools;
using System;

public sealed class CoinGenerator : MonoBehaviour
{
    public event Action<Vector2> OnTryedSpawn;
    [SerializeField] private PlatformGenerator _generator;
    [SerializeField] private CoinCollision _prefab;
    [SerializeField] private int _startCount = 4;
    private readonly ObjectsPool<CoinCollision> _pool = new();

    private void OnEnable()
    {
        _generator.OnSpawned += TrySpawn;
        _pool.Add(_startCount, _prefab, transform);
    }

    private void OnDisable()
    {
        _generator.OnSpawned -= TrySpawn;
    }

    private void TrySpawn(Vector2 position)
    {
        float randomNumber = UnityEngine.Random.Range(2, 4);

        if (randomNumber == 3)
            Spawn(position);
        else
            OnTryedSpawn?.Invoke(position);
    }

    private void Spawn(Vector2 position)
    {
        var coin = _pool.Get(_prefab);
        coin.gameObject.SetActive(true);
        coin.GetComponent<SpriteRenderer>().enabled = true;
        coin.transform.position = position;
        coin.transform.parent = transform;
    }
}
