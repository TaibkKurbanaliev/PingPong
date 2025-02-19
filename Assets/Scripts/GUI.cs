using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GUI : MonoBehaviour
{
    
    [SerializeField] private SceneAsset _playMode;
    [SerializeField] private GameObject _difficult;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _backButton;
    [SerializeField] private SettingsSO _difficultSettings;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioMixerGroup _mixer;

    private void Start()
    {
        _difficult.SetActive(false);
        _settings.SetActive(false);
        _backButton.SetActive(false);
    }

    public void OnVSCPUClick()
    {
        _mainMenu.SetActive(false);
        _difficult.SetActive(true);
        _backButton.SetActive(true);
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

    public void OnMusicOffClick()
    {
        _audioSource.mute = !_audioSource.mute;
    }

    public void OnSoundsOff()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void OnSettingsClick()
    {
        _settings.SetActive(true);
        _mainMenu.SetActive(false);
        _backButton.SetActive(true);
    }

    public void OnBackClick()
    {
        _mainMenu.SetActive(true);
        _backButton.SetActive(false);
        _settings.SetActive(false);
        _difficult.SetActive(false);
    }
}
