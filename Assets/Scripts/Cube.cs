using System;
using UnityEngine;

[RequireComponent(typeof(CubeClickHandler), typeof(CubeColorizer), typeof(CubeExplosionLogic))]
public class Cube : MonoBehaviour
{
    public event Action<Cube> OnClicked;

    public CubeColorizer Colorizer {get; private set; }
    public CubeExplosionLogic ExplosionLogic { get; private set; }

    private void Awake()
    {
        Colorizer = GetComponent<CubeColorizer>();
        ExplosionLogic = GetComponent<CubeExplosionLogic>();
    }

    public void Initialize(int separationChance)
    {
        ExplosionLogic.SetChance(separationChance);
        Colorizer.SetRandomColor();
    }

    public void HandleClick()
    {
        OnClicked?.Invoke(this);
    }
}