using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;

    private Coroutine _counter;
    private int _count; 
    float delay = 0.5f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_counter == null)
            {
                _counter = StartCoroutine(Counter(delay));
            }
            else
            {
                StopCoroutine(_counter);
                _counter = null;
            }
        }
    }

    private IEnumerator Counter(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            _count++;
            _counterText.text = _count.ToString();
        }
    }
}




