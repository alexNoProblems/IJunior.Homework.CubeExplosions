using UnityEngine;

public class CubeFuze : MonoBehaviour
{
    [SerializeField] private float _minExplosionForce = 0.5f;
    [SerializeField] private float _maxExplosionForce = 1.5f;
    [SerializeField] private float _upward = 0.2f;
    
    public void Explode(Rigidbody rigidbody, Vector3 origin)
    {
        if (rigidbody == null)
        {
            Debug.LogError("CubeFuze: Rigidbody не передан");

            return;
        }
           
        if (rigidbody.GetComponent<SpawnedCube>() == null)
            return;
        
        Vector3 direction = (rigidbody.position - origin).normalized;

        float force = Random.Range(_minExplosionForce, _maxExplosionForce);
        Vector3 upwardForce = Vector3.up * _upward;
        rigidbody.AddForce(direction * force + upwardForce, ForceMode.Impulse);
    }
}
