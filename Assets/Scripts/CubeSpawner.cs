using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private const int MaxSeparationChance = 100;

    [SerializeField] private CubeFactory _factory;
    [SerializeField] private CubeAreaExplosion _areaExplosion;
    [SerializeField] private ExplosionVFXSpawner _explosionVFXSpawner;
    [SerializeField] private ExplosionCalculator _explosionCalculator;
    [SerializeField] private List<Cube> _initialCubes = new();
    [SerializeField] private float _spawnOffsetRadius = 0.2f;
    [SerializeField] private float _scaleFactor = 0.5f;
    [SerializeField] private int _minCubesNumber = 2;
    [SerializeField] private int _maxCubesNumber = 6;

    private void Start()
    {
        foreach (var cube in _initialCubes)
        {
            if (cube == null)
                continue;
            
            cube.Initialize(MaxSeparationChance);
            cube.Clicked += HandleCubeClicked;
        }
    }

    private void HandleCubeClicked(Cube clickedCube)
    {
        clickedCube.Clicked -= HandleCubeClicked;

        Vector3 origin = clickedCube.transform.position;
        Vector3 scale = clickedCube.transform.localScale;

        if (clickedCube.ExplosionLogic.ShouldExplode() == true)
        {
            SpawnNewCubes(clickedCube);
        }
        else
        {
            _explosionCalculator.Calculate(scale, out float radius, out float force);
            _areaExplosion?.ExplodeArea(origin, radius, force);
            _explosionVFXSpawner?.Spawn(origin);
        }

        Destroy(clickedCube.gameObject);
    }

    private void SpawnNewCubes(Cube cubeParent)
    {
        int cubesCount = Random.Range(_minCubesNumber, _maxCubesNumber + 1);
        int newChance = cubeParent.ExplosionLogic.GetNextChance();
        
        Vector3 origin = cubeParent.transform.position;
        Vector3 newScale = cubeParent.transform.localScale * _scaleFactor;

        for (int i = 0; i < cubesCount; i++)
        {
            Vector3 offset = Random.insideUnitSphere * _spawnOffsetRadius;
            Cube newCube = _factory.CreateCube(origin + offset, newScale, newChance, origin);

            newCube.Clicked += HandleCubeClicked;
        }
    }
}
