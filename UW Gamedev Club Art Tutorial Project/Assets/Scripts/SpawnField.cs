using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SpawnField : MonoBehaviour
{
    BoxCollider2D boxCollider;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    public Vector2 getRandomPos()
    {
        Vector2 center = boxCollider.bounds.center;
        Vector2 extents = boxCollider.bounds.extents;
        float randomX = Random.Range(center.x - extents.x, center.x + extents.x);
        float randomY = Random.Range(center.y - extents.y, center.y + extents.y);
        return new Vector2(randomX, randomY);
    }
}
