using UnityEngine;

public class CubeExplosionLogic : MonoBehaviour
{
    private const int MinRandomChance = 0;
    private const int MaxRandomChance = 100;
    private const int ChanceDivisionFactor = 2;
    private const int MinSeparationChanceValue = 1;

    private int _separationChance = 100;

    public void SetChance(int chance)
    {
        _separationChance = chance;
    }

    public bool ShouldExplode()
    {
        return Random.Range(MinRandomChance, MaxRandomChance + 1) < _separationChance;
    }

    public int GetNextChance()
    {
        return Mathf.Max(MinSeparationChanceValue, _separationChance / ChanceDivisionFactor);
    }
}
