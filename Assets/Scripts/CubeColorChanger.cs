using UnityEngine;

public class CubeColorChanger : MonoBehaviour
{
    public void ChangeColor(GameObject cube)
    {
       if (cube.TryGetComponent<CubeVisual>(out var visual))
            visual.SetRandomColor();
       else
            Debug.LogWarning("CubeColorChanger: CubeVisual не найден на Cube");
    }
}
