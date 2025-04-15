using UnityEngine;

[RequireComponent(typeof(Cube))]
public class CubeRegistrar : MonoBehaviour
{
    [SerializeField] private CubeInitializer _initializer;

    private void Awake()
    {
        Cube cube = GetComponent<Cube>();

        if (_initializer != null && cube != null)
        {
            _initializer.RegisterCube(cube);         
        }
    }
}
