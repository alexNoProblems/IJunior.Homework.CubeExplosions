using UnityEngine;

public class CubeVisual : MonoBehaviour
{
   private Renderer _renderer;

   private void Awake()
   {
        _renderer = GetComponent<Renderer>();

        if (_renderer == null)
            Debug.LogError("CubeVisual: Renderer не найден на Cube");
   }

   public void SetColor(Color color)
   {
        _renderer.material.color = color;
   }

   public void SetRandomColor()
   {
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        SetColor(randomColor);
   }
}
