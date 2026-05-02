using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BlackHole : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;
    Collider2D col;
    Rigidbody2D rb;
    private void Start()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Chalice chalice))
        {
            chalice.onDie.Invoke();
        }
        if (collision.gameObject.TryGetComponent(out Monster monster))
        {
            Destroy(monster.gameObject);
        }
    }

    private void Update()
    {
        rb.linearVelocity = Random.insideUnitCircle * speed;
    }
}
