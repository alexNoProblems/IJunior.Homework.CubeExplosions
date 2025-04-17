using UnityEngine;

public class ExplosionVFXSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _explosionVFXPrefab;
    [SerializeField] private float  _explosionVFXLifetime = 2f;

    public void Spawn(Vector3 position)
    {
        if (_explosionVFXPrefab == null)
            return;

        GameObject visualEffect = Instantiate(_explosionVFXPrefab, position, Quaternion.identity);
        
        Destroy(visualEffect, _explosionVFXLifetime);
    }
}
