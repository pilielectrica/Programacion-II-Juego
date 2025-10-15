using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class ContadorDeHadas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fairyCounterTMP;

    public int fairyCount = 0;
    private int _fairyCount;
    public void ActualizarContador()
    {Debug.Log ("el contador de hadas va: "+ fairyCount);
        fairyCount++;
        _fairyCount = fairyCount;
        fairyCounterTMP.text = _fairyCount.ToString();
        
    }
}

