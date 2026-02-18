using UnityEngine;

public class MovingRock : MonoBehaviour
{
    // Our speed. The [SerializeField] component allows us to edit this in our inspector.
    [SerializeField] float speed = 1f;
    // [SerializeField] Transform target; // incase you want to target a specific object!

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Likely not needed in this case!
    void Start()
    {
        
    }

    // FixedUpdate is called 50 times per second.
    void FixedUpdate()
    {
        float timeStep = speed * Time.fixedDeltaTime;

        // transform.position is position, transform.rotation is rotation.
        // Go ahead and look through methods like transform.rotation.SetEulerRotation
        // or transform.position.set.

        // For example, this moves the gameobject's position up every frame.
        // transform.position = transform.position + Vector3.up * timeStep;

        // This rotates the object.
        // transform.Rotate(new Vector3(0, 0, timeStep));
    }
}
