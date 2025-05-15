using System.Collections.Generic;
using UnityEngine;

public class Exploser : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private float _explosionRadius = 5;
    [SerializeField] private float _explosionForce = 700;

    private void OnEnable()
    {
        _rayCaster.StartedDivision += OnExplode;
    }

    private void OnDisable()
    {
        _rayCaster.StartedDivision -= OnExplode;
    }

    public void OnExplode(Cube _cube)
    {
        _explosionForce /= _cube.GetScale(_cube.gameObject);
        _explosionRadius /= _cube.GetScale(_cube.gameObject);

        foreach (Rigidbody cubes in GetExplodableObjects())
        {
            cubes.AddExplosionForce(_explosionForce, _cube.transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }
}
