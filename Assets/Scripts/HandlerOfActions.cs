using System;
using UnityEngine;

public class HandlerOfActions : MonoBehaviour
{
    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploser _explosion;
    [SerializeField] private float _currentChance;

    private int _numberToDecreaseChance = 2;
    private bool _isAllowed;

    private void OnEnable()
    {
        _rayCaster.StartedDivision += CalculateProbabilityOfDivision;
    }

    private void OnDisable()
    {
        _rayCaster.StartedDivision += CalculateProbabilityOfDivision;
    }

    private void CalculateProbabilityOfDivision(Cube cube)
    {
        if (UnityEngine.Random.value < cube.GetChance())
        {
            _currentChance = cube.GetChance();
            _currentChance /= _numberToDecreaseChance;
            _numberToDecreaseChance *= 2;
            cube.AddExplosionForce();
            _spawner.CreateCubes(cube);

        }
        else
        {
            _explosion.OnExplode(cube);
        }

        cube.Destroy();
    }
}
