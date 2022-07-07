using UnityEngine;
using Tools;
using Random = UnityEngine.Random;
using System;

public sealed class SpikeGenerator : MonoBehaviour, ITryingGenerator
{
    [SerializeField] private int _startCount = 3;
    [SerializeField] private SpikeCollision _prefab;
    private ITryingGenerator _spawner;
    private readonly ObjectsPool<SpikeCollision> _pool = new();

    public event Action<Vector2> OnTriedSpawn;

    public void Init(ITryingGenerator spawner)
    {
        _spawner = spawner ?? throw new ArgumentNullException(nameof(spawner));
        _pool.Add(_startCount, _prefab);
        _spawner.OnTriedSpawn += TrySpawn;
    }

    private void OnDisable()
    {
        _spawner.OnTriedSpawn -= TrySpawn;
    }

    private void TrySpawn(Vector2 position)
    {
        var index = Random.Range(2, 3);

        if (index == 2 && position.y >= PlayerMovement.Position.y)
        {
            Spawn(position);
        }
        else
        {
            OnTriedSpawn?.Invoke(position);
        }
    }

    private void Spawn(Vector2 position)
    {
        var spike = _pool.Get(_prefab);
        spike.transform.position = position;
        spike.gameObject.SetActive(true);
    }
}
