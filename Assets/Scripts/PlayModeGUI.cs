using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayModeGUI : MonoBehaviour
{
    [SerializeField] private SceneAsset _playMode;
    [SerializeField] private SceneAsset _menuScene;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _endGame;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private TextMeshProUGUI _playerScore;
    [SerializeField] private TextMeshProUGUI _enemyScore;
    [SerializeField] private TextMeshProUGUI _winnerName;
    [SerializeField] private Ball _ball;
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;

    private void Start()
    {
        _menu.SetActive(false);
        _endGame.SetActive(false);
    }

    private void OnEnable()
    {
        _ball.Goaled += OnBallGoaled;
        _player.Winned += OnWinnerFounded;
        _enemy.Winned += OnWinnerFounded;
    }

    private void OnDisable()
    {
        _ball.Goaled -= OnBallGoaled;
        _player.Winned -= OnWinnerFounded;
        _enemy.Winned -= OnWinnerFounded;
    }

    public void OnExitClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_menuScene.name);
    }

    public void OnRestartClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_playMode.name);
    }

    public void OnPauseClick()
    {
        Time.timeScale = Time.timeScale == 0 ? 1f : 0f;
        _menu.SetActive(!_menu.activeSelf);
    }

    public void OnPlayClick()
    {
        Time.timeScale = 1f;
        _menu.SetActive(false);
    }

    private void OnBallGoaled(bool isPlayer)
    {
        if (!isPlayer)
            ChangeScore(_enemyScore);
        else
            ChangeScore(_playerScore);
    }

    private void ChangeScore(TextMeshProUGUI text)
    {
        text.text = (int.Parse(text.text) + 1).ToString();
    }

    private void OnWinnerFounded(string name)
    {
        _winnerName.text = name;
        Time.timeScale = 0f;
        _endGame.SetActive(true);
        _pauseButton.SetActive(false);
    }
}
