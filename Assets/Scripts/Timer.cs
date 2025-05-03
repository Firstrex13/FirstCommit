using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;

    private Coroutine _counter;
    private int _count;
    private float delay = 0.5f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_counter == null)
            {
                _counter = StartCoroutine(StartCounter(delay));
            }
            else
            {
                StopCoroutine(_counter);
                _counter = null;
            }
        }

        ShowCounter();
    }

    private IEnumerator StartCounter(float delay)
    {
        WaitForSeconds _waitForSeconds = new WaitForSeconds(delay);

        while (enabled)
        {
            yield return _waitForSeconds;
            _count++;
        }
    }

    private void ShowCounter()
    {
        _counterText.text = _count.ToString();
    }
}




