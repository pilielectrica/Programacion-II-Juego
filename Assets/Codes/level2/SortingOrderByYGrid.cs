using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SortingOrderByYGrid : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private int sortingOffset = 0; // ajuste manual

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        // Cuanto más abajo (menor Y), mayor sortingOrder → se dibuja encima
        spriteRenderer.sortingOrder = -(int)(transform.position.y * 100) + sortingOffset;
    }
}
