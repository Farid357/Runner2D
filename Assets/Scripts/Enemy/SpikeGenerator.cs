using UnityEngine;
using Tools;
using Random = UnityEngine.Random;

public sealed class SpikeGenerator : MonoBehaviour
{
    [SerializeField] private int _startCount = 3;
    [SerializeField] private SpikeCollision _prefab;
    [SerializeField] private CoinGenerator _generator;
    private readonly ObjectsPool<SpikeCollision> _pool = new();

    private void Start()
    {
        _pool.Add(_startCount, _prefab);
        _generator.OnTryedSpawn += TrySpawn;
    }

    private void OnDisable()
    {
        _generator.OnTryedSpawn -= TrySpawn;
    }

    private void TrySpawn(Vector2 position)
    {
        var index = Random.Range(2, 3);

        if (index == 2 && position.y >= PlayerMovement.Position.y)
        {
            Spawn(position);
        }
    }

    private void Spawn(Vector2 position)
    {
        var spike = _pool.Get(_prefab);
        spike.transform.position = position;
        spike.gameObject.SetActive(true);
    }
}
