using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjetoLoop : MonoBehaviour
{
    [SerializeField] private GameObject objetoPrefab; // Prefab del hada
    [SerializeField] private GameObject sistemaParticulasPrefab; // Prefab del sistema de partículas

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoEspera;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoIntervalo;

    void Start()
    {
        InvokeRepeating(nameof(GenerarObjetoLoop), tiempoEspera, tiempoIntervalo);
    }

    void GenerarObjetoLoop()
    {
        // Generar una posición aleatoria
        float posX = Random.Range(-7f, 7f);
        float posY = Random.Range(-3.36f, 3.66f);
        Vector3 posicionAleatoria = new Vector3(posX, posY, 0f);

        // Instanciar el objeto en la posición aleatoria
        GameObject objetoGenerado = Instantiate(objetoPrefab, posicionAleatoria, Quaternion.identity);
        
        // Instanciar el sistema de partículas en la misma posición
        GameObject particulasGeneradas = Instantiate(sistemaParticulasPrefab, posicionAleatoria, Quaternion.identity);
        
        // Llamar a la coroutine para que desaparezca el objeto después de 2 segundos
        StartCoroutine(DesaparecerObjeto(objetoGenerado, 2f));
        StartCoroutine(DesaparecerObjeto(particulasGeneradas, 2f)); // También destruir las partículas
    }

    private IEnumerator DesaparecerObjeto(GameObject objeto, float tiempo)
    {
        yield return new WaitForSeconds(tiempo); // Espera el tiempo especificado
        Destroy(objeto); // Destruir el objeto
    }
}
