using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CalculatorOfDivision _calculatorOfDivision;

    private float _spawnRadius = 3f;
    private int _minCubesCount = 2;
    private int _maxCubesCount = 6;

    private void OnEnable()
    {
        _calculatorOfDivision.PerfomDivision += OnCreateCubes;
    }

    private void OnDisable()
    {
        _calculatorOfDivision.PerfomDivision -= OnCreateCubes;
    }

    public void OnCreateCubes()
    {
        Vector3 position = transform.position;

        int currentCubCount = Random.Range(_minCubesCount, _maxCubesCount + 1);

        for (int i = 0; i < currentCubCount; i++)
        {
            GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            newCube.transform.position = position + Random.insideUnitSphere * _spawnRadius;

            newCube.transform.localScale = Vector3.one / 2;

            newCube.GetComponent<Renderer>().material.color = Random.ColorHSV();

            newCube.AddComponent<Cube>();
            newCube.AddComponent<Rigidbody>();
        }
    }
}
