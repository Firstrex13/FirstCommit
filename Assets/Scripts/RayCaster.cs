using System;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Cube _cube;

    public event Action<Cube> StartDivision;

    private void Update()
    {
        if (Input.mousePosition != null)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            Physics.Raycast(ray, out hit);

            if (hit.collider.GetComponent<Cube>())
            {
                _cube = hit.collider.GetComponent<Cube>();

                if (Input.GetMouseButton(0))
                {
                    StartDivision?.Invoke(_cube);
                }
            }
        }
    }
}
