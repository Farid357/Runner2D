using UnityEngine;

public sealed class Root : MonoBehaviour
{
    [SerializeField] private SpikeGenerator _spikeGenerator;
    [SerializeField] private CoinGenerator _coinGenerator;

    private void Awake()
    {
        _spikeGenerator.Init(_coinGenerator);
    }
}