using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private float _repeatRate = 1f;
    private int _poolCpacity = 10;
    private int _maxSize = 10;

    private ObjectPool<Cube> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(
            createFunc: () => Instantiate(_cube),
            actionOnGet: (cube) => ActionOnGet(cube),
            actionOnRelease: (cube) => OnReleaseCube(cube),
            actionOnDestroy: (cube) => Destroy(cube),
            collectionCheck: true,
            defaultCapacity: _poolCpacity,
            maxSize: _maxSize
            );
    }      

    private void Start()
    {
        StartCoroutine(CreateCube(_repeatRate));
    }

    private IEnumerator CreateCube(float delay)
    {
        while (enabled)
        {
            yield return new WaitForSeconds(delay);
            GetCube();
        }
    }

    private void ActionOnGet(Cube cube)
    {
        cube.CubeDeleted += OnCubeDeleted;
        TakePosition(cube);
        cube.gameObject.SetActive(true);
    }

    private void TakePosition(Cube cube)
    {
        int maxPosition = 8;
        int height = 13;
        Vector3 SpawnArea = new Vector3(Random.Range(-maxPosition, maxPosition), height, Random.Range(-maxPosition, maxPosition));

        cube.transform.position = SpawnArea;
    }

    private void GetCube()
    {
        _pool.Get();
    }

    private void OnCubeDeleted(Cube cube)
    {
        cube.CubeDeleted -= OnCubeDeleted;
        _pool.Release(cube);
    }

    private void OnReleaseCube(Cube cube)
    {
        cube.gameObject.SetActive(false);  
    }
}
