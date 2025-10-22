using System.Collections;
using UnityEngine;

public class GeneradorObjetoLoop : MonoBehaviour
{
    [Header("Prefabs o referencias en escena")]
    [SerializeField] private GameObject objetoPrefab;
    [SerializeField] private GameObject sistemaParticulasPrefab;

    [Header("Tiempos")]
    [SerializeField, Range(0.5f, 5f)] private float tiempoEspera = 1f;
    [SerializeField, Range(0.5f, 5f)] private float tiempoIntervalo = 1f;

    void Start()
    {
        // ✅ Si los objetos son de la escena, se hace una copia inactiva para usarla como plantilla
        if (objetoPrefab != null && objetoPrefab.scene.IsValid())
        {
            GameObject copia = Instantiate(objetoPrefab);
            copia.SetActive(false);
            objetoPrefab = copia;
        }

        if (sistemaParticulasPrefab != null && sistemaParticulasPrefab.scene.IsValid())
        {
            GameObject copiaParticulas = Instantiate(sistemaParticulasPrefab);
            copiaParticulas.SetActive(false);
            sistemaParticulasPrefab = copiaParticulas;
        }

        InvokeRepeating(nameof(GenerarObjetoLoop), tiempoEspera, tiempoIntervalo);
    }

    void GenerarObjetoLoop()
    {
        if (objetoPrefab == null || sistemaParticulasPrefab == null)
        {
            Debug.LogError("❌ Prefabs o referencias no asignadas en GeneradorObjetoLoop.", this);
            return;
        }

        // Generar posición aleatoria
        float posX = Random.Range(-7f, 7f);
        float posY = Random.Range(-3.36f, 3.66f);
        Vector3 posicionAleatoria = new Vector3(posX, posY, 0f);

        // Instanciar desde las copias desactivadas
        GameObject objetoGenerado = Instantiate(objetoPrefab, posicionAleatoria, Quaternion.identity);
        objetoGenerado.SetActive(true);

        GameObject particulasGeneradas = Instantiate(sistemaParticulasPrefab, posicionAleatoria, Quaternion.identity);
        particulasGeneradas.SetActive(true);

        // Desaparecer ambos después de 2 segundos
        StartCoroutine(DesaparecerObjeto(objetoGenerado, 2f));
        StartCoroutine(DesaparecerObjeto(particulasGeneradas, 2f));
    }

    private IEnumerator DesaparecerObjeto(GameObject objeto, float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        if (objeto != null)
            Destroy(objeto);
    }

    void OnDestroy()
    {
        CancelInvoke(nameof(GenerarObjetoLoop));
    }
}
