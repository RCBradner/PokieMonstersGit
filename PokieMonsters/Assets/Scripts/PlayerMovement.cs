using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.5f;
    public Transform movePoint;
    private float horizontal, vertical;
    bool walkingVert = false;
    bool walkingHor = false;
    bool controlsEnabled = true;

    public bool up, down, left, right = false;

    public bool movingInGrass = false;

    public LayerMask stopsMovement, tallGrass;

    void Start()
    {
        movePoint.parent = null;
    }

    void Update()
    {
        if(controlsEnabled)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }
        else
        {
            horizontal = 0;
            vertical = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) < 0.01f)
        {
            if (Mathf.Abs(horizontal) == 1 && !walkingVert)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(horizontal, 0, 0), 0.1f, stopsMovement))
                {
                    walkingHor = true;
                    movePoint.position += new Vector3(horizontal, 0, 0);
                }
            }
            else walkingHor = false;
            if (Mathf.Abs(vertical) == 1 && !walkingHor)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0, vertical, 0), 0.1f, stopsMovement))
                {
                    walkingVert = true;
                    movePoint.position += new Vector3(0, vertical, 0);
                }
            }
            else walkingVert = false;
        }

        FindDirection();

        if (walkingHor || walkingVert)
        {
            if (Physics2D.OverlapCircle(transform.position, 0.1f, tallGrass))
            {
                movingInGrass = true;
            }
            else movingInGrass = false;
        }
        else movingInGrass = false;
    }

    public void ToggleControls(bool state)
    {
        controlsEnabled = state;
    }

    void FindDirection()
    {
        if (movePoint.position.x > transform.position.x)
        {
            right = true;
        }
        else right = false;

        if (movePoint.position.x < transform.position.x)
        {
            left = true;
        }
        else left = false;

        if (movePoint.position.y > transform.position.y)
        {
            up = true;
        }
        else up = false;

        if (movePoint.position.y < transform.position.y)
        {
            down = true;
        }
        else down = false;
    }

}
