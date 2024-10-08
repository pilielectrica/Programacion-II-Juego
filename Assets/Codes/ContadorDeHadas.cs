using UnityEngine;
using TMPro; // Importa el espacio de nombres de TextMeshPro

public class ContadorDeHadas : MonoBehaviour
{
    // Referencia al componente TextMeshPro del Canvas
    public TextMeshProUGUI fairyCounterTMP;

    // Variable para contar las hadas recogidas
    private int fairyCount = 0;

    // Método que se llama al recoger una hada
    public void CollectFairy()
    {
        fairyCount++; // Incrementa el contador
        UpdateFairyCounterTMP(); // Actualiza el texto en pantalla
    }

    // Método para actualizar el texto del contador en pantalla usando TextMeshPro
    private void UpdateFairyCounterTMP()
    {
        fairyCounterTMP.text = fairyCount.ToString();
    }
}

