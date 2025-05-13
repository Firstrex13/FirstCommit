using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    [SerializeField] private int _explosionForce = 500;

    private float _splitChance = 1f;
    private int _minCubesCount = 2;
    private int _maxCubesCount = 6;

    private void OnMouseUpAsButton()
    {
        if (Random.value < _splitChance)
        {
            _splitChance /= 2;
            CreateCubes();

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void CreateCubes()
    {
        Vector3 position = transform.position;
        int currentCubCount = Random.Range(_minCubesCount, _maxCubesCount + 1);

        for (int i = 0; i < currentCubCount; i++)
        {
            GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            float newScale = transform.localScale.x / 2;

            newCube.transform.localScale = new Vector3(newScale, newScale, newScale);

            newCube.transform.position = position + Random.insideUnitSphere;

            newCube.GetComponent<Renderer>().material.color = Random.ColorHSV();

            newCube.AddComponent<Rigidbody>();
            newCube.AddComponent<CubeCreator>();

            Vector3 explosionDirection = (newCube.transform.position - position).normalized;

            newCube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, position, 5f);

            Destroy(gameObject);
        }
    }
}
