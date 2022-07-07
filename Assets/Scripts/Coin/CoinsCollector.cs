using System;
using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    public event Action<int> OnGettedNewRecord;
    public event Action<int> OnAdded;
    private const string Key = "xnksnd";
    private int _count;
    private int _bestRecord;

    private void OnEnable()
    {
        _bestRecord = PlayerPrefs.GetInt(Key, _count);
        OnGettedNewRecord?.Invoke(_bestRecord);
        CoinCollision.OnCollected += Add;
    }

    private void OnDestroy()
    {
        CoinCollision.OnCollected -= Add;
    }

    private void Add()
    {
        _count += 1;
        OnAdded?.Invoke(_count);
        TrySetNewRecord();
    }

    private void TrySetNewRecord()
    {
        if (_bestRecord < _count)
        {
            _bestRecord = _count;
            OnGettedNewRecord?.Invoke(_bestRecord);
            Save();
        }
    }

    private void Save()
    {
        PlayerPrefs.SetInt(Key, _bestRecord);
        PlayerPrefs.Save();
    }
}
