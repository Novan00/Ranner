using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private PlayerHealth _playerHealth;

    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _playerHealth.Died += OnDied;
        _restartButton.onClick.AddListener(OnRestsrtButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
    }

    private void OnDisable()
    {
        _playerHealth.Died -= OnDied;
        _restartButton.onClick.RemoveListener(OnRestsrtButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnDied()
    {
        _gameOverGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnRestsrtButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
