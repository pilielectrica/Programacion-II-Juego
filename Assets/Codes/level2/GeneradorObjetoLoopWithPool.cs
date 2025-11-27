using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GeneradorObjetoLoopWithPool : MonoBehaviour
{

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoEspera;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoIntervalo;

    private ObjectPool objectPool;
    [SerializeField] private Mover player;

    private bool disparando = false;

    [SerializeField] private Bazooka bazooka; // arrastrás tu bazooka en el inspector

    private bool balasdisponibles = false;

    [SerializeField] private ContadorDeHadas hadasContador;
    private int balasDisparadas = 0;

    [Header("Evento para restar un hada cuando disparamos")]
    [SerializeField] public UnityEvent alDispararHada;

    [SerializeField] private AudioClip[] sonidosDeDisparo;

    private void Awake()
    {
        objectPool = GetComponent<ObjectPool>();
    }
    void Update()
    {
       /* Debug.Log("cantidad de balas disparadas: " + balasDisparadas);
        Debug.Log("es posible disparar: " + balasdisponibles);*/

        contadorBalas();

        if (player.BazookaTaken && Input.GetKeyDown(KeyCode.Space))
        {
            if (!disparando && balasdisponibles)
            {
                InvokeRepeating(nameof(GenerarObjetoLoop), tiempoEspera, tiempoIntervalo);
                disparando = true;
                Debug.Log("▶ Disparo iniciado");
                

             
                


            }
            else
            {
                CancelInvoke(nameof(GenerarObjetoLoop));
                disparando = false;
                Debug.Log("⏹ Disparo detenido por tecla Space");
            }
        }
    }



    void GenerarObjetoLoop()
    {
        // SI NO QUEDAN BALAS → DETENER DISPARO ACÁ
        if (!balasdisponibles)
        {
            Debug.Log("❌ No quedan balas, deteniendo disparo...");
            CancelInvoke(nameof(GenerarObjetoLoop));
            disparando = false;
            balasDisparadas--;
            return;
        }
        AudioSource tiroAudio = GetComponent<AudioSource>();
        int index = Random.Range(0, sonidosDeDisparo.Length);

        tiroAudio.PlayOneShot(sonidosDeDisparo[index]);
        // Si todavía quedan balas, seguís disparando
        GameObject pooledObject = objectPool.GetPooledObject(bazooka._mirandoDerecha);

        if (pooledObject != null)
        {
            pooledObject.transform.position = transform.position;
            pooledObject.transform.rotation = Quaternion.identity;
            pooledObject.SetActive(true);
        }

        balasDisparadas++; // cada bala consume una
        alDispararHada?.Invoke();
        

    }

    void contadorBalas()
    {
        if (hadasContador.fairyCount == 0) { balasdisponibles = false; }
        
        else
        {
            balasdisponibles = true;
        }
    }
}