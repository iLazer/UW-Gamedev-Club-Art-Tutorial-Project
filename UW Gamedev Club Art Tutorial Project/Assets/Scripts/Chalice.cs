using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Chalice : MonoBehaviour
{
    [SerializeField] Transform match;
    [SerializeField] UnityEvent onDie;
    public float speed = 100f;
    public float clampDistance = 0.1f;
    public static Chalice Instance { get; private set; }
    public void Awake()
    {
        Instance = this;
    }
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Vector2 direction = match.position - transform.position;
        if(direction.magnitude < clampDistance)
        {
            rb.linearVelocity = Vector2.zero;
            transform.position = match.position;
            return;
        }
        // make this force-based.
        rb.AddForce(direction.normalized * speed * Time.fixedDeltaTime, ForceMode2D.Force);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Monster monster))
        {
            onDie.Invoke();
        };
    }
}
