using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed = 5f;
    public static Player Instance { get; private set; }
    Rigidbody2D rb;
    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set velocity to player's input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(moveHorizontal, moveVertical);
        inputVector = Vector2.ClampMagnitude(inputVector, 1f);
        rb.linearVelocity = inputVector * speed;
    }
}
