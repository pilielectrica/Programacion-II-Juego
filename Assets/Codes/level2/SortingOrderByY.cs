using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SortingOrderByY : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private int sortingOffset = 0;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        // Cuanto más abajo (menor Y), mayor orden (se dibuja "encima")
        int order = Mathf.RoundToInt(transform.position.y * -100f) + sortingOffset;
        spriteRenderer.sortingOrder = order;
    }
}
