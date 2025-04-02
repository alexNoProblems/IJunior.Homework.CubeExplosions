using UnityEngine;

public class CubeColorChanger : MonoBehaviour
{
    private Renderer _renderer;

    public void ChangeColor()
    {
        InitRenderer();

        if(_renderer != null)
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            _renderer.material.color = randomColor;
        }
        else
        {
            Debug.LogError("Renderer не найден на объекте " + gameObject.name);
        }
    }

    private void Start()
    {
        InitRenderer();
        ChangeColor();
    }

    private void InitRenderer()
    {
        if(_renderer == null)
            _renderer = GetComponent<Renderer>();
    }
}
