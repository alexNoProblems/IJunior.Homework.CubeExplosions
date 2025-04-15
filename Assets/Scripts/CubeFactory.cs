using UnityEngine;

public class CubeFactory : MonoBehaviour
{
   [SerializeField] private Cube _cubePrefab;
   [SerializeField] private CubeFuze _fuze;
   [SerializeField] private CubeInitializer _initializer;

   public Cube CreateCube(Vector3 position, Vector3 scale, int chance, Vector3 explosionOrigin, bool fuze = true)
   {
        Cube cube = Instantiate(_cubePrefab, position, Quaternion.identity);
        cube.transform.localScale = scale;
        cube.Initialize(chance);

        Rigidbody rigidbody = cube.GetComponent<Rigidbody>();

        if (rigidbody == null)
        {
            Debug.LogError($"CubeFactory: Rigidbody не найден у префаба {cube.name}");

            return cube;
        }

        cube.gameObject.AddComponent<SpawnedCube>();

        if (fuze == true)
            _fuze.Explode(rigidbody, explosionOrigin);
        
        _initializer.RegisterCube(cube);

        return cube;
   }
}
