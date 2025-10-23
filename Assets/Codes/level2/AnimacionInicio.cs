using UnityEngine;

public class AnimacionInicio : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Luego dispara otra por trigger (si la transición está configurada)
        animator.SetTrigger("BarcoIntro");
    }
}
