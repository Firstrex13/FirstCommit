using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private HandlerOfActions _handlerOfActions;
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Cube _cube;

    private float _spawnRadius = 3f;
    private int _minCubesCount = 2;
    private int _maxCubesCount = 6;
    private int _numberToDecreaseScale = 2;

    public void CreateCubes(Cube cube)
    {

        int currentCubCount = Random.Range(_minCubesCount, _maxCubesCount + 1);

        for (int i = 0; i < currentCubCount; i++)
        {
            GameObject newCube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);

            Vector3 position = cube.transform.position;

            Vector3 currentScale = cube.transform.localScale;

            newCube.transform.position = position + Random.insideUnitSphere * _spawnRadius;

            newCube.transform.localScale = currentScale / _numberToDecreaseScale;

            if (_cube != null)
            {
                _cube.GetComponent<Cube>();

                _cube.Initialise(newCube.transform);
            }
        }
    }
}
