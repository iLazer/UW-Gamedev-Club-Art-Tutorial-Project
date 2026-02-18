using UnityEngine;

public class Teleporter_Example : MonoBehaviour
{
    [SerializeField] Transform target;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Chalice chalice))
        {
            chalice.transform.position = target.position;
        }
    }
}
