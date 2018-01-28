using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float movementSpeed = .01f;

    public bool runForwards = true;

    private SpriteRenderer mySpriteRenderer;

    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        gameObject.SetActive(false);
    }

    void Update()
    {
        UpdatePosition();

        if (runForwards)
        {
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }
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

    void CollisionHandler(Collider2D collider)
    {
        if (collider.tag == "Right Edge")
        {
            runForwards = false;
            //Debug.Log("Triggered");

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
        CollisionHandler(collider);
    }
}
