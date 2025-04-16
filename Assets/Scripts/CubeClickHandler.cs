using UnityEngine;

[RequireComponent(typeof(Cube))]
public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
    }

    private void OnMouseDown()
    {
        if (_cube == null)
            return;
        
        _cube.HandleClick();
    }
}
