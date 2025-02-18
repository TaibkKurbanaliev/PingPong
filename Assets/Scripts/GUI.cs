using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUI : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private SceneAsset _playMode;
    [SerializeField] private SceneAsset _menuScene;
    [SerializeField] private GameObject _difficult;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private SettingsSO _difficultSettings;
    [SerializeField] private TextMeshProUGUI _playerScore;
    [SerializeField] private TextMeshProUGUI _enemyScore;
    [SerializeField] private Ball _ball;

    private void Start()
    {
        _menu.SetActive(false);
        _difficult.SetActive(false);
    }

    private void OnEnable()
    {
        _ball.Goaled += OnBallGoaled;
    }

    private void OnDisable()
    {
        _ball.Goaled -= OnBallGoaled;
    }

    private void OnBallGoaled(bool isPlayer)
    {
        Debug.Log("Goal");
        if (!isPlayer)
            ChangeScore(_enemyScore);
        else 
            ChangeScore(_playerScore);
    }

    private void ChangeScore(TextMeshProUGUI text)
    {
        text.text = (int.Parse(text.text)+1).ToString();
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

    public void OnRestartClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_playMode.name);
    }

    public void OnExitClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_mainMenu.name);
    }

    public void OnVSCPUClick()
    {
        _mainMenu.SetActive(false);
        _difficult.SetActive(true);
    }

    public void OnEasyClick()
    {
        _difficultSettings.SetDifficult(Difficult.Easy);
        SceneManager.LoadScene(_playMode.name);
    }

    public void OnMediumClick()
    {
        _difficultSettings.SetDifficult(Difficult.Medium);
        SceneManager.LoadScene(_playMode.name);
    }
    public void OnHardClick()
    {
        _difficultSettings.SetDifficult(Difficult.Hard);
        SceneManager.LoadScene(_playMode.name);
    }
}
