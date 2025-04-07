using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private CubeExplosion _explosion;

    private void Awake()
    {
        if (_explosion == null && TryGetComponent(out CubeExplosion explosion))
            _explosion = explosion;
    }

    private void OnMouseDown()
    {
        _explosion.TryExplodeOrDestroy();
    }
}
