using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Monster : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer; 
    public float speed = 3f;
    public float spawnDelay = 2f;
    bool spawned = false;
    Rigidbody2D rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(spawnDelay > 0)
        {
            spawnDelay -= Time.fixedDeltaTime;
            return;
        } else if (!spawned)
        {
            spawned = true;
            spriteRenderer.color = spriteRenderer.color + new Color(0, 0, 0, 1);
            GetComponent<Collider2D>().enabled = true;
        }
        Vector2 direction = Chalice.Instance.transform.position - transform.position;
        // make this force-based.
        rb.AddForce(direction.normalized * speed * Time.fixedDeltaTime, ForceMode2D.Force);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle - 90));
    }

    public void ApplyKnockback(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }
}
