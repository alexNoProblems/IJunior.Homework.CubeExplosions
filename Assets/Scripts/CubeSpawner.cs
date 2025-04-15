using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private const int MaxSeparationChance = 100;

    [SerializeField] private CubeFactory _factory;
    [SerializeField] private float _spawnOffsetRadius = 0.2f;
    [SerializeField] private float _scaleFactor = 0.5f;
    [SerializeField] private int _minCubesNumber = 2;
    [SerializeField] private int _maxCubesNumber = 6;

    public void SpawnInitialCubes(Cube[] cubes)
    {
        foreach (var cube in cubes)
        {
            cube.Initialize(MaxSeparationChance);
            cube.OnClicked += HandleCubeClicked;
        }
    }

    private void HandleCubeClicked(Cube clickedCube)
    {
        clickedCube.OnClicked -= HandleCubeClicked;

        if (clickedCube.ExplosionLogic.ShouldExplode() == true)
            SpawnNewCubes(clickedCube);

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

            newCube.OnClicked += HandleCubeClicked;
        }
    }
}
