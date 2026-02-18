using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Dash_Example : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float cooldown;
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference dashAction;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        if (dashAction != null)
            dashAction.action.Enable();
        if (moveAction != null)
            moveAction.action.Enable();
    }

    private void OnDisable()
    {
        if (dashAction != null)
            dashAction.action.Disable();
        if (moveAction != null)
            moveAction.action.Enable();
    }

    Rigidbody2D rb;
    float lastDash;
    private void Update()
    {
        if (lastDash + cooldown > Time.time) return; // Dont dash on cooldown

        if (dashAction.action.ReadValue<float>() == 1)
        {
            Vector2 target = moveAction.action.ReadValue<Vector2>();
            if (target != Vector2.zero)
            {
                lastDash = Time.time;
                rb.AddForce(target * speed, ForceMode2D.Impulse);
            }
        }
    }
}
