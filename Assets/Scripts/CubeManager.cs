using UnityEngine;

public class CubeManager : MonoBehaviour
{
    private const int _startChance = 100;

    private CubeSpawner _spawner;
    private CubeColorChanger _colorChanger;
    private CubePhysics _physics;

    private void Start()
    {
        _spawner = GetComponent<CubeSpawner>();
        _colorChanger = GetComponent<CubeColorChanger>();
        _physics = GetComponent<CubePhysics>();

        if (_spawner == null || _colorChanger == null || _physics == null)
            Debug.LogError("CubeManager: отсутствует один или несколько компонентов");

        CubeExplosion[] allExplosions = FindObjectsOfType<CubeExplosion>();

        foreach (var explosion in allExplosions)
        {
            explosion.SetDependencies(_spawner, _colorChanger, _physics);
            explosion.SetChance(_startChance);
            _colorChanger.ChangeColor(explosion.gameObject);
        }
    }
}
