using UnityEngine;
using TMPro;

public class HUDHadas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fairyCounterTMP;

    // Este método recibe el valor directamente desde el evento
    public void ActualizarContador(int nuevoValor)
    {
        fairyCounterTMP.text = nuevoValor.ToString();
    }
}

