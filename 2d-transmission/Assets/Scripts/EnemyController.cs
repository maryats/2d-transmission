using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    float movementSpeed = .05f;

    public bool runForwards = true;

    void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {

        Vector2 oPos = transform.position;
        float calculatedPosition;

        if (runForwards)
        {
            transform.position = new Vector2(oPos.x + movementSpeed, oPos.y);
        }
        else
        {
            transform.position = new Vector2(oPos.x - movementSpeed, oPos.y);
        }

        
    }

    void WallCollisionHandler(Collider2D collider)
    {
        if (collider.tag == "Right Edge")
        {
            runForwards = false;
            Debug.Log("Triggered");

            // Or
            // JumpBackwards()
        }
        else if (collider.tag == "Left Edge")
        {
            runForwards = true;

            // Or
            // JumpForwards()
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        WallCollisionHandler(collider);
    }
}
