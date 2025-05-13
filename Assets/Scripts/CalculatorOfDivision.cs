using System;
using UnityEngine;

public class CalculatorOfDivision : MonoBehaviour
{
    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosion _explosion;

    private float _splitChance = 1f;

    public event Action PerfomDivision;


    private void OnEnable()
    {
        _rayCaster.StartDivision += OnCalculateDivision;
    }

    private void OnDisable()
    {
        _rayCaster.StartDivision -= OnCalculateDivision;
    }

    private void OnCalculateDivision(Cube _cube)
    {
        if (UnityEngine.Random.value < _splitChance)
        {
            _splitChance /= 2;

            PerfomDivision?.Invoke();

            _cube.Destroy();
        }
        else
        {
            _cube.Destroy();
        }
    }
}
