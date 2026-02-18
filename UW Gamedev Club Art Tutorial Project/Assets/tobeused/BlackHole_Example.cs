using UnityEngine;

public class BlackHole_Example : MonoBehaviour
{
    [SerializeField] float timeAlive;
    [SerializeField] float speed;
    private void FixedUpdate()
    {
        transform.position += (Vector3)(speed * Random.insideUnitCircle) * Time.fixedDeltaTime;
        timeAlive -= Time.fixedDeltaTime;
        if(timeAlive < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Monster monster))
        {
            Destroy(monster.gameObject);
        }
    }
}
