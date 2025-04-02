using TMPro;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    private const int _minNewCubes = 2;
    private const int _maxNewCubes = 6;
    private const int _minRandomChance = 0;
    private const int _maxRandomChance = 100;
    private const int _chanceDivisionFactor = 2;
    private const int _minSeparationChanceValue = 1;
    private const float _minExplosionForce = 0.5f;
    private const float _maxExplosionForce = 1.5f;
    
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private float _scaleFactor = 0.5f;
    [SerializeField] private float _spawnOffsetRadius = 0.2f;
    [SerializeField] private float _initialVelocity = 0f;
    [SerializeField] private float _initialAngularVelocity = 0f;
    [SerializeField] private float _mass = 2f;
    [SerializeField] private float _linearDrag = 3f;
    [SerializeField] private float _angularDrag = 2f;
    [SerializeField] private bool _useGravity = true;

    private int _separationChance = 100;
    
    private void OnMouseDown()
    {
        if (Random.Range(_minRandomChance, _maxRandomChance + 1) < _separationChance)
            Explode();
        else
            Destroy(gameObject);
    }

    private void Explode()
    {
        int cubesNumbers = Random.Range(_minNewCubes, _maxNewCubes + 1);

        for (int i = 0; i < cubesNumbers; i++)
        {
            GameObject newCube = CreateNewCube();
            ApplyPhysics(newCube);
        }

        Destroy(gameObject);
    }

    private GameObject CreateNewCube()
    {
        Vector3 offset = Random.insideUnitSphere * _spawnOffsetRadius;
        GameObject cube = Instantiate(_cubePrefab, transform.position + offset, Quaternion.identity);

        cube.transform.localScale = transform.localScale * _scaleFactor;

        TryChangeColor(cube);
        PassSeparationChance(cube);

        return cube;
    }

    private void TryChangeColor(GameObject cube)
    {
        if (cube.TryGetComponent<CubeColorChanger>(out var colorChanger))
            colorChanger.ChangeColor();
    }

    private void PassSeparationChance(GameObject cube)
    {
        if (cube.TryGetComponent<CubeExplosion>(out var script))
        {
            int newChance = Mathf.Max(_minSeparationChanceValue, _separationChance / _chanceDivisionFactor);
            script.SetChance(newChance);
        }
    }

    private void ApplyPhysics(GameObject cube)
    {
        if (!cube.TryGetComponent<Rigidbody>(out var rigidbody))
            rigidbody = cube.AddComponent<Rigidbody>();

        rigidbody.velocity = Vector3.one * _initialVelocity;
        rigidbody.angularVelocity = Vector3.one * _initialAngularVelocity;

        rigidbody.mass = _mass;
        rigidbody.drag = _linearDrag;
        rigidbody.angularDrag = _angularDrag;
        rigidbody.useGravity = _useGravity;

        Vector3 direction = Random.onUnitSphere;
        direction.y = Mathf.Abs(direction.y);

        float randomForce = Random.Range(_minExplosionForce, _maxExplosionForce);
        rigidbody.AddForce(direction * randomForce, ForceMode.Impulse);
    }

    public void SetChance(int chance)
    {
        _separationChance = chance;
    }
}
