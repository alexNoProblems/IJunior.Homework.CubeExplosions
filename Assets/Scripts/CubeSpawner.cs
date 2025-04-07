using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private float _spawnOffsetRadius = 0.2f;
    [SerializeField] private float _scaleFactor = 0.5f;

    public GameObject Spawn(Transform source)
    {
        Vector3 offset = Random.insideUnitSphere * _spawnOffsetRadius;
        GameObject cube = Instantiate(_cubePrefab, source.position + offset, Quaternion.identity);

        cube.transform.localScale = source.localScale * _scaleFactor;

        return cube;
    }
}
