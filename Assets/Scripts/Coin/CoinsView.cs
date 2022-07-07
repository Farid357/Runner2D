using TMPro;
using UnityEngine;

public sealed class CoinsView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private TextMeshProUGUI _bestRecordText;
    [SerializeField] private CoinsCollector _collector;

    private void OnEnable()
    {
        _collector.OnAdded += Display;
        _collector.OnGettedNewRecord += DisplayBestRecord;
    }

    private void OnDisable()
    {
        _collector.OnAdded -= Display;
        _collector.OnGettedNewRecord -= DisplayBestRecord;
    }

    private void Display(int count)
    {
        _coinsText.text = count.ToString();
    }

    private void DisplayBestRecord(int count)
    {
        _bestRecordText.text = count.ToString();
    }
}
