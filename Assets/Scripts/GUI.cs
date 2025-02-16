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

    private void Start()
    {
        _menu.SetActive(false);
        _difficult.SetActive(false);
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
