using Tools;
using UnityEngine;
using System.Collections;
using System;

public sealed class PlatformGenerator : MonoBehaviour
{
    public event Action<Vector2> OnSpawned;
    [SerializeField] private Transform _player;
    [SerializeField] private Ground _groundPrefab;
    [SerializeField, Min(2)] private int _startCount = 15;
    [SerializeField] private float _delay;

    private WaitForSeconds _wait;
    private readonly ObjectsPool<Ground> _pool = new();
    private Vector3 _playerPosition;

    private void Start()
    {
        _playerPosition = _player.position;
        _wait = new WaitForSeconds(_delay);
        _pool.Add(_startCount, _groundPrefab);
        StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        var previousGround = _pool.Get(_groundPrefab);
        var xOffset = 4.3f;
        previousGround.transform.position = new Vector2(_playerPosition.x + xOffset + 1.8f, _playerPosition.y);
        previousGround.gameObject.SetActive(transform);
        float xPosition = 0;

        while (true)
        {
            yield return _wait;
            var ground = _pool.Get(_groundPrefab);
            var yOffset = UnityEngine.Random.Range(-0.4f, 0.8f);

            if (previousGround != null)
            {
                var groundPosition = previousGround.transform.position;
                xPosition += xOffset + 3f;
                var yPosition = _playerPosition.y + yOffset;
                ground.transform.position = new Vector2(xPosition, yPosition);
                ground.gameObject.SetActive(true);
                float newObjectYPosition = Mathf.Abs(ground.transform.position.y + 1.3f);
                OnSpawned?.Invoke(new Vector2(ground.transform.position.x, newObjectYPosition));
            }
        }
    }
}
