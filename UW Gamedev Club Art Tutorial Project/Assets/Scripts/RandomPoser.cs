using UnityEngine;

public class RandomPoser : MonoBehaviour
{
    [SerializeField] SpawnField spawnField;
    private void Start()
    {
        RandomizePosition();
    }
    public void RandomizePosition()
    {
        transform.position = spawnField.getRandomPos();
    }
}
