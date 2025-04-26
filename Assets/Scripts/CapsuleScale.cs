
using UnityEngine;

public class CapsuleScale : MonoBehaviour
{
    [SerializeField] private float _scaleSpeed;
    private Vector3 _scaleVector;
    void Update()
    {
        _scaleVector = Vector3.one;
        transform.localScale += _scaleVector * _scaleSpeed * Time.deltaTime;
    }
}
