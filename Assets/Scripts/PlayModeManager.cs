using UnityEngine;

public class PlayModeManager : MonoBehaviour
{
    [SerializeField] private SettingsSO _difficultSettings;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Ball _ball;

    private void OnEnable()
    {
        _enemy.Init(_difficultSettings.EnemySpeed);
        _ball.Init(_difficultSettings.BallSpeed, _difficultSettings.SpeedMultiplier);
    }
}
