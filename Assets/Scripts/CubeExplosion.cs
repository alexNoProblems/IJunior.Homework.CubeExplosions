using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    private const int _minNewCubes = 2;
    private const int _maxNewCubes = 6;
    private const int _minRandomChance = 0;
    private const int _maxRandomChance = 100;
    private const int _chanceDivisionFactor = 2;
    private const int _minSeparationChanceValue = 1;

    private CubeSpawner _spawner;
    private CubeColorChanger _colorChanger;
    private CubePhysics _physics;
    private int _separationChance = 100;

    public void SetDependencies(CubeSpawner spawner, CubeColorChanger colorChanger, CubePhysics physics)
    {
        _spawner = spawner;
        _colorChanger = colorChanger;
        _physics = physics;
    }

    public void SetChance(int chance)
    {
        _separationChance = chance;
    }
    
    public void TryExplodeOrDestroy()
    {
        int chance = Random.Range(_minRandomChance, _maxRandomChance + 1);

        if (chance < _separationChance)
            Explode();
        else
            Destroy(gameObject);
    }

    private void Explode()
    {
        int cubesCount = Random.Range(_minNewCubes, _maxNewCubes + 1);

        for (int i = 0; i < cubesCount; i++)
        {
            GameObject cube = _spawner.Spawn(transform);

            if (cube.TryGetComponent<CubeExplosion>(out var explosion))
            {
                int newChance = Mathf.Max(_minSeparationChanceValue, _separationChance / _chanceDivisionFactor);
                explosion.SetChance(newChance);
                explosion.SetDependencies(_spawner, _colorChanger, _physics);
            }

            _colorChanger.ChangeColor(cube);
            _physics.ApplyPhysics(cube, transform.position);
        }

        Destroy(gameObject);
    }
}
