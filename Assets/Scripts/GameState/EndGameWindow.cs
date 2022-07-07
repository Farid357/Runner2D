using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public sealed class EndGameWindow : MonoBehaviour
{
    [SerializeField] private GameObject _endGamePanel;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _homeButton;
    [SerializeField] private DeadZone _deadZone;

    private void Start()
    {
        _deadZone.OnPlayerCatched += Show;
        SpikeCollision.OnPlayerCatched += Show;
        _restartButton.onClick.AddListener(Restart);
        _homeButton.onClick.AddListener(GoToHome);
    }

    private void OnDestroy()
    {
        SpikeCollision.OnPlayerCatched -= Show;
        _deadZone.OnPlayerCatched -= Show;
        _restartButton.onClick.RemoveListener(Restart);
        _homeButton.onClick.RemoveListener(GoToHome);
    }

    private void Restart()
    {
        Load(SceneManager.GetActiveScene().buildIndex);
    }

    private void GoToHome()
    {
        Load(0);
    }

    public void Show()
    {
        _endGamePanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void Load(int index)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(index);
    }
}
