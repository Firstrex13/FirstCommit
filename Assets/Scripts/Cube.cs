using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private int _delay;
    private int _minRange = 2;
    private int _maxRange = 6;
    private bool _isTouched = false;

    private Rigidbody _rigidBody;

    public event Action<Cube> CubeDeleted;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _delay = UnityEngine.Random.Range(_minRange, _maxRange);
    }

    private void ClearVelocity()
    {
        _rigidBody.linearVelocity = Vector3.zero;
        _rigidBody.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            if (_isTouched)
            {
                return;
            }

            _isTouched = true;

            StartCoroutine(DeleteWithDelay(_delay));
            SetColor();
        }
    }

    private IEnumerator DeleteWithDelay(int delay)
    {
        yield return new WaitForSeconds(delay);
        ClearVelocity();
        CubeDeleted?.Invoke(this);
    }

    private void SetColor()
    {
        GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 1);
    }
}
