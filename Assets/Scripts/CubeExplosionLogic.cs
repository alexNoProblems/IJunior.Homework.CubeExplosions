using UnityEngine;

public class CubeExplosionLogic : MonoBehaviour
{
    private const int _minRandomChance = 0;
    private const int _maxRandomChance = 100;
    private const int _chanceDivisionFactor = 2;
    private const int _minSeparationChanceValue = 1;

    private int _separationChance = 100;

    public void SetChance(int chance)
    {
        _separationChance = chance;
    }

    public bool ShouldExplode()
    {
        return Random.Range(_minRandomChance, _maxRandomChance + 1) < _separationChance;
    }

    public int GetNextChance()
    {
        return Mathf.Max(_minSeparationChanceValue, _separationChance / _chanceDivisionFactor);
    }
}
