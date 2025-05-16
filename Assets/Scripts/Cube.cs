using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 10f;
    [SerializeField] private float _explosionForce = 100f;
    [SerializeField] private float _splitChance = 1f;

    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    public void Initialise(Transform cubeScalse)
    {
        transform.localScale = cubeScalse.localScale;
    }

    public float GetChance()
    {
        return _splitChance;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void AddExplosionForce()
    {
        _rigidBody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }

    public float GetScale(GameObject newCube)
    {
        return newCube.transform.localScale.x;
    }
}
