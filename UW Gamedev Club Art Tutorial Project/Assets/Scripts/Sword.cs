using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] Transform match;
    [SerializeField] Transform pivot;
    public float knockbackForce = 10f;
    public float swingSpeed = 360f; // degrees per second
    private void FixedUpdate()
    {
        pivot.position = match.position;
        // Rotate the sword to face the mouse cursor
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - match.position;
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float currentAngle = pivot.rotation.eulerAngles.z;
        float angleDifference = Mathf.DeltaAngle(currentAngle, targetAngle);
        float maxAngleChange = swingSpeed * Time.fixedDeltaTime;
        float angleChange = Mathf.Clamp(angleDifference, -maxAngleChange, maxAngleChange);
        float newAngle = currentAngle + angleChange;
        pivot.rotation = Quaternion.Euler(0, 0, newAngle);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Sword collided with: " + collision.gameObject.name);
        if (collision.gameObject.TryGetComponent(out Monster monster))
        {
            Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;
            monster.ApplyKnockback(knockbackDirection * knockbackForce);
        }
    }
}
