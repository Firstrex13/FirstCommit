using System;
using UnityEngine;

public class CalculatorOfDivision : MonoBehaviour
{
    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploser _explosion;

    private int _numberToDecreaseChance = 2;
    private float _currentChance;

    public event Action PerfomDivision;

    private void OnEnable()
    {
        _rayCaster.StartDivision += OnCalculateDivision;
    }

    private void OnDisable()
    {
        _rayCaster.StartDivision -= OnCalculateDivision;
    }

    private void OnCalculateDivision(Cube cube)
    {
        if (UnityEngine.Random.value < cube.GetChance())
        {
            _currentChance = cube.GetChance();
            _currentChance /= _numberToDecreaseChance;

            PerfomDivision?.Invoke();

            cube.Destroy();
        }
        else
        {
            PerfomDivision?.Invoke();
            cube.Destroy();
        }
    }
}
