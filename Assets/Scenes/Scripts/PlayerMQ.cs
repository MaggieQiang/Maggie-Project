using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMQ : MonoBehaviour
{
    float movementX;
    float movementY;
    float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 v = movementValue.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;


    }
    // Update is called once per frame

void FixedUpdate()
    {
        float XmoveDistance = movementX * speed * Time.fixedDeltaTime;
        float YmoveDistance = movementY * speed * Time.fixedDeltaTime;

        // transform.position = new Vector2(transform.position.x + XmoveDistance, transform.position.y + YmoveDistance);

        // rb.LinearVelocity = new Vector2(XmoveDistance, YmoveDistance);
    }
    void Update()

    {
        
    }
}
