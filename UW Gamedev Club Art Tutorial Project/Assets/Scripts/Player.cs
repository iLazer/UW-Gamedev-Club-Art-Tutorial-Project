using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float acceleration = 10f;

    public static Player Instance { get; private set; }

    [SerializeField] private InputActionReference moveAction;

    Rigidbody2D rb;

    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        if (moveAction != null)
            moveAction.action.Enable();
    }

    private void OnDisable()
    {
        if (moveAction != null)
            moveAction.action.Disable();
    }

    void FixedUpdate()
    {
        Vector2 targetInput = moveAction.action.ReadValue<Vector2>();
        Vector2 targetVelocity = targetInput * speed;
        Vector2 currVelocity = rb.linearVelocity;
        Vector2 targetVelocityChange = targetVelocity - currVelocity;
        Vector2 targetVelocityChangeClamped = Vector2.ClampMagnitude(targetVelocityChange, acceleration * Time.fixedDeltaTime);
        rb.linearVelocity += targetVelocityChangeClamped;
    }
}
