using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ContadorDeHadas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fairyCounterTMP;

    public int fairyCount = 0;

    public UnityEvent onFairyCollected;
    public UnityEvent onFairyUsed;

    public void ActualizarContador()
    {
        fairyCount++;
        ActualizarTexto();
        Debug.Log($"🧚 Hadas totales: {fairyCount}");
        onFairyCollected?.Invoke();
    }

    public void UsarHada(int cantidad = 1)
    {
        fairyCount = Mathf.Max(fairyCount - cantidad, 0);
        ActualizarTexto();
        Debug.Log($"⚡ Hada usada. Quedan: {fairyCount}");
        onFairyUsed?.Invoke();
    }

    private void ActualizarTexto()
    {
        if (fairyCounterTMP != null)
            fairyCounterTMP.text = fairyCount.ToString();
    }
}
