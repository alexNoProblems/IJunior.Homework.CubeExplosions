using UnityEngine;

public class CubeAreaExplosion : MonoBehaviour
{
    private const float MaxAttenuation = 1f;

    public void ExplodeArea(Vector3 origin, float radius, float forceMultiplier)
    {
        Collider[] colliders = Physics.OverlapSphere(origin, radius);

        foreach (var collider in colliders)
        {
            Rigidbody rigidbody = collider.attachedRigidbody;

            if (rigidbody == null || rigidbody.gameObject == gameObject)
                continue;
            
            Vector3 direction = (rigidbody.position - origin).normalized;
            float distance = Vector3.Distance(rigidbody.position, origin);
            float attenuation = Mathf.Clamp01(MaxAttenuation - distance / radius);

            float force = forceMultiplier * attenuation;

            rigidbody.AddForce(direction * force, ForceMode.Impulse);
        }
    }

}
