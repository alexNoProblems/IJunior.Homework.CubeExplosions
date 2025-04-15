using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private void Awake()
    {
        if (_cube == null && TryGetComponent(out Cube cube))
            _cube = cube;
    }

    private void OnMouseDown()
    {
        if (_cube == null)
            return;
        
        _cube.HandleClick();
    }
}
