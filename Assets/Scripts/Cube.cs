using UnityEngine;

public class Cube : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private float _splitChance = 1f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public float GetChance()
    {
        return _splitChance;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
