using UnityEngine;

public class PlataformaBalsa : MonoBehaviour
{
    private Transform player;
    private Vector3 offset;
    private bool sobreBalsa;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            offset = player.position - transform.position;
            sobreBalsa = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sobreBalsa = false;
            player = null;
        }
    }

    void LateUpdate()
    {
        if (sobreBalsa && player != null)
        {
            player.position = transform.position + offset;
        }
    }
}
