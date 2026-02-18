using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    [SerializeField] SpawnField spawnField;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
        {
            Score.Instance.score += 1;
            transform.position = spawnField.getRandomPos();
        }
    }
}
