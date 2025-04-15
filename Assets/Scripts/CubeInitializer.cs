using UnityEngine;
using System.Collections.Generic;

public class CubeInitializer : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;
    
    private readonly List<Cube> _registeredCubes = new();

    private void Start()
    {
        if (_spawner == null)
        {
            Debug.LogError("CubeInitializer: Spawner не назначен в инспекторе");

            return;
        }
        
       _spawner.SpawnInitialCubes(_registeredCubes.ToArray());
    }

    public void RegisterCube(Cube cube)
    {
        if (!_registeredCubes.Contains(cube))
            _registeredCubes.Add(cube);
    }
}
