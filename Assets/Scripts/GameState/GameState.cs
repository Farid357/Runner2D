using UnityEngine.UI;
using UnityEngine;

public sealed class GameState : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _continueButton;

    private void OnEnable()
    {
        if (_exitButton != null)
            _exitButton.onClick.AddListener(Exit);
        if (_pauseButton != null)
            _pauseButton.onClick?.AddListener(Pause);
        if (_continueButton != null)
            _continueButton.onClick?.AddListener(Continue);
    }

    private void OnDestroy()
    {
        if (_exitButton != null)
            _exitButton.onClick.RemoveListener(Exit);
        if (_pauseButton != null)
            _pauseButton.onClick?.RemoveListener(Pause);

        if (_continueButton != null)
            _continueButton.onClick?.RemoveListener(Continue);
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }

    private void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
