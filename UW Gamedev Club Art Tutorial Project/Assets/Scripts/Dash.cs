using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Dash : MonoBehaviour
{
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
}
