
using UnityEngine;

public class CubeMoveRoateScale : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _scaleSpeed;
    [SerializeField] private float _rotationSpeed;
    private Vector3 _scaleVector;
    private void Update()
    {
        transform.Translate(0, 0, _speed * Time.deltaTime);
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime, Space.Self);
        _scaleVector = Vector3.one;
        transform.localScale += _scaleVector * _scaleSpeed * Time.deltaTime;
    }
}
