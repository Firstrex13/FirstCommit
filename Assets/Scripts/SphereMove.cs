
using UnityEngine;

public class SphereMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private void Update()
    {
        transform.position += new Vector3(0, 0, _speed * Time.deltaTime);
    }
}
