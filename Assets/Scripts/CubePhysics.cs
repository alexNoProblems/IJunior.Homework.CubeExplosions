using UnityEngine;

public class CubePhysics : MonoBehaviour
{
    [SerializeField] private float _initialVelocity = 0f;
    [SerializeField] private float _initialAngularVelocity = 0f;
    [SerializeField] private float _mass = 2f;
    [SerializeField] private float _linearDrag = 3f;
    [SerializeField] private float _angularDrag = 2f;
    [SerializeField] private bool _useGravity = true;
    [SerializeField] private float _minExplosionForce = 0.5f;
    [SerializeField] private float _maxExplosionForce = 1.5f;

    public void ApplyPhysics(GameObject cube, Vector3 explosionOrigin)
    {
        if (cube.TryGetComponent<Rigidbody>(out var rigidbody) == false)
        rigidbody = cube.AddComponent<Rigidbody>();

        rigidbody.velocity = Vector3.one * _initialVelocity;
        rigidbody.angularVelocity = Vector3.one * _initialAngularVelocity;

        rigidbody.mass = _mass;
        rigidbody.drag = _linearDrag;
        rigidbody.angularDrag = _angularDrag;
        rigidbody.useGravity = _useGravity;

        float randomForce = Random.Range(_minExplosionForce, _maxExplosionForce);
        Vector3 direction = (cube.transform.position - explosionOrigin).normalized;
        rigidbody.AddForce(direction * randomForce, ForceMode.Impulse);
    }
}
