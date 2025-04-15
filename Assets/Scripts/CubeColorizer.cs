using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CubeColorizer : MonoBehaviour
{
     private Renderer _renderer;

     private void Awake()
     {
          _renderer = GetComponent<Renderer>();
          _renderer.material = new Material(_renderer.material);       
     }

     public void SetRandomColor()
     {
          Color randomColor = new Color(Random.value, Random.value, Random.value);
          _renderer.material.color = randomColor;
     }
}
