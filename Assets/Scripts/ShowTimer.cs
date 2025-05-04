using TMPro;
using UnityEngine;

public class ShowTimer : MonoBehaviour
{
    public void ShowCounter(TextMeshProUGUI text, int count)
    {
        text.text = count.ToString();
    }
}
