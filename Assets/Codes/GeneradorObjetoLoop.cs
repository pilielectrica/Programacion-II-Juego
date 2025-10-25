using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GeneradorObjetoLoop : MonoBehaviour
{
    [Header("Tilemap del campo")]
    [SerializeField] private Tilemap tilemapCampo; // El Tilemap donde hay pasto
    [SerializeField] private TileBase tileValido;  // Tile que permite spawn (pasto)

    [Header("Prefabs o referencias en escena")]
    [SerializeField] private GameObject objetoPrefab;          // Hada u objeto
    [SerializeField] private GameObject sistemaParticulasPrefab; // Efecto de partículas

    [Header("Tiempos")]
    [SerializeField, Range(0.5f, 10f)] private float tiempoEspera = 1f;
    [SerializeField, Range(0.5f, 10f)] private float tiempoIntervalo = 1f;
    


[Header("Duración del objeto")]
[SerializeField, Range(0.5f, 20f)] private float duracionObjeto = 2f;


    private void Start()
    {
        // ✅ Crear copias inactivas si los objetos vienen de la escena
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

        InvokeRepeating(nameof(GenerarObjetoLoopMethod), tiempoEspera, tiempoIntervalo);
    }

    private void GenerarObjetoLoopMethod()
    {
        if (tilemapCampo == null || tileValido == null || objetoPrefab == null || sistemaParticulasPrefab == null)
        {
            Debug.LogError("❌ Prefabs o referencias no asignadas en GeneradorObjetoLoop.", this);
            return;
        }

        // Obtener todas las celdas del Tilemap
        BoundsInt bounds = tilemapCampo.cellBounds;
        List<Vector3> celdasValidas = new List<Vector3>();

        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            TileBase tile = tilemapCampo.GetTile(pos);
            if (tile == tileValido)
            {
                // Guardar la posición central del tile
                celdasValidas.Add(tilemapCampo.GetCellCenterWorld(pos));
            }
        }

        if (celdasValidas.Count == 0) return;

        // Elegir aleatoriamente una celda válida
        Vector3 spawnPos = celdasValidas[Random.Range(0, celdasValidas.Count)];

        // Instanciar objeto y partículas
        GameObject objetoGenerado = Instantiate(objetoPrefab, spawnPos, Quaternion.identity);
        objetoGenerado.SetActive(true);

        GameObject particulasGeneradas = Instantiate(sistemaParticulasPrefab, spawnPos, Quaternion.identity);
        particulasGeneradas.SetActive(true);

        // Desaparecer ambos después de 2 segundos
        StartCoroutine(DesaparecerObjeto(objetoGenerado, duracionObjeto));
StartCoroutine(DesaparecerObjeto(particulasGeneradas, duracionObjeto));

    }

    private IEnumerator DesaparecerObjeto(GameObject objeto, float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        if (objeto != null)
            Destroy(objeto);
    }

    private void OnDestroy()
    {
        CancelInvoke(nameof(GenerarObjetoLoopMethod));
    }
}
