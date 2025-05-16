using System;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Cube _cube;

    public event Action<Cube> StartedDivision;

    private void Update()
    {
        if (Input.mousePosition != null)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit) != false)
                {
                    if (hit.collider.TryGetComponent<Cube>(out _cube))
                    {
                        _cube = hit.collider.GetComponent<Cube>();

                        StartedDivision?.Invoke(_cube);
                    }
                }
            }
        }
    }
}
