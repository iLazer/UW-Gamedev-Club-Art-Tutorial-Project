using UnityEngine;
using UnityEngine.Events;

public class SpawnDelay : MonoBehaviour
{
    [SerializeField] SpriteRenderer targetRender;
    [SerializeField] float spawnDelay = 2f;
    [SerializeField] UnityEvent onSpawn;
    public bool spawned {  get; private set; }
    private void FixedUpdate()
    {
        if (spawnDelay > 0)
        {
            spawnDelay -= Time.fixedDeltaTime;
        }
        if(!spawned && spawnDelay <= 0)
        {
            spawned = true;
            targetRender.color = targetRender.color + new Color(0,0, 0, 1);
            onSpawn.Invoke();
        }
    }
}
