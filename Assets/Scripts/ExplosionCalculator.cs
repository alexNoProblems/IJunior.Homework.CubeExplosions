using UnityEngine;

public class ExplosionCalculator : MonoBehaviour
{
    private const float MaxScaleFactor = 1f;

    [SerializeField] private float _minExplosionRadius = 4f;
    [SerializeField] private float _maxExplosionRadius = 6f;
    [SerializeField] private float _minExplosionForce = 8f;
    [SerializeField] private float _maxExplosionForce = 15f;

    public void Calculate(Vector3 scale, out float radius, out float force)
    {
        float sizeFactor = MaxScaleFactor - scale.magnitude;

        radius = Mathf.Lerp(_minExplosionRadius, _maxExplosionRadius, sizeFactor);
        force = Mathf.Lerp(_minExplosionForce, _maxExplosionForce, sizeFactor);
    }
}
