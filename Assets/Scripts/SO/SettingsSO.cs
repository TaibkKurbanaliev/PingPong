
using UnityEngine;


public enum Difficult
{
    Easy,
    Medium,
    Hard,
}

[CreateAssetMenu]
public class SettingsSO : ScriptableObject
{
    public Difficult Difficult { get; private set; } = Difficult.Easy;
    public float BallSpeed { get; private set; } = 4f;
    public float SpeedMultiplier { get; private set; } = 0.1f;
    public float EnemySpeed { get; private set; } = 2f;

    public void SetDifficult (Difficult difficult)
    {
        Difficult = difficult;

        switch (Difficult)
        {
            case Difficult.Easy:
                BallSpeed = 4f;
                SpeedMultiplier = 0.1f;
                EnemySpeed = 2f;
                break;
            case Difficult.Medium:
                BallSpeed = 8f;
                SpeedMultiplier = 0.2f;
                EnemySpeed = 4f;
                break;
            case Difficult.Hard:
                BallSpeed = 10f;
                SpeedMultiplier = 0.3f;
                EnemySpeed = 6f;
                break;
        }
    }
}
