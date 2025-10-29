using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ContadorDeHadas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fairyCounterTMP;

    [Header("Contador")]
    public int fairyCount = 0;  // Cargas actuales
    private int _fairyCount;

    [Header("Evento cuando se recoge un hada")]
    public UnityEvent onFairyCollected;

    [Header("Evento cuando se dispara un proyectil")]
    public UnityEvent onFairyUsed;

    // Se llama al recolectar un hada
    public void ActualizarContador()
    {
        fairyCount++;
        ActualizarTexto();

        Debug.Log("El contador de hadas va: " + fairyCount);

        // Disparar evento de recolectar
        onFairyCollected?.Invoke();
    }

    // Se llama al disparar un proyectil / usar un hada
    public void UsarHada(int cantidad = 1)
{
    Debug.Log("🧚‍♀️ Se llamó a UsarHada()");
    fairyCount = Mathf.Max(fairyCount - cantidad, 0);
    ActualizarTexto();

    Debug.Log("Hadass usadas. Quedan: " + fairyCount);
    onFairyUsed?.Invoke();
}


    private void ActualizarTexto()
    {
        _fairyCount = fairyCount;
        if (fairyCounterTMP != null)
            fairyCounterTMP.text = _fairyCount.ToString();
    }
}
