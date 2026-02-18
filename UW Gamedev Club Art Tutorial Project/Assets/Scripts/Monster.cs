using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Monster : MonoBehaviour
{
    public float speed = 3f;
    Rigidbody2D rb;
    public void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    { 
        Vector2 direction = Chalice.Instance.transform.position - transform.position;
        // force-based.
        rb.AddForce(direction.normalized * speed * Time.fixedDeltaTime, ForceMode2D.Force);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle - 90));
    }

    public void ApplyKnockback(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }
}
