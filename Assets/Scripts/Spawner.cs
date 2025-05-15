using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CalculatorOfDivision _calculatorOfDivision;
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Cube _cube;

    private float _spawnRadius = 3f;
    private int _minCubesCount = 2;
    private int _maxCubesCount = 6;
    private int _numberToDecreaseScale = 2;

    private void OnEnable()
    {
        _calculatorOfDivision.PerfomedDivision += OnCreateCubes;
    }

    private void OnDisable()
    {
        _calculatorOfDivision.PerfomedDivision -= OnCreateCubes;
    }

    private void OnCreateCubes()
    {
        Vector3 position = transform.position;

        int currentCubCount = Random.Range(_minCubesCount, _maxCubesCount + 1);

        for (int i = 0; i < currentCubCount; i++)
        {
            GameObject newCube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);

            newCube.transform.position = position + Random.insideUnitSphere * _spawnRadius;

            newCube.transform.localScale = transform.localScale / _numberToDecreaseScale;

            if (_cube != null)
            {
                _cube.GetComponent<Cube>();

                _cube.Initialise(newCube.transform);
            }
        }
    }
}
