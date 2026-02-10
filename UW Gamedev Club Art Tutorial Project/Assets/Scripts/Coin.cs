using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    [SerializeField] SpawnField spawnField;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
        {
            // You can add coin collection logic here, such as increasing the player's score.
            Score.Instance.score += 1; // Assuming you have a Score class to manage the player's score.
            transform.position = spawnField.getRandomPos();
        }
    }
}
