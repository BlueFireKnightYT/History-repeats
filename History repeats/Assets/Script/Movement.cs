using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 input;
    public List<Vector2> newRecordedPositions = new List<Vector2>();

    public float speed;
    public float jumpHeight;

    public LayerMask groundLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        newRecordedPositions.Add(new Vector2(transform.position.x, transform.position.y));
        rb.linearVelocityX = input.x * speed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        { 
            RaycastHit2D jumpCheck = Physics2D.Raycast(transform.position, Vector2.down, .6f, groundLayer);

            if(jumpCheck)
            {
                rb.AddForceY(jumpHeight, ForceMode2D.Impulse);
            }
        }
    }
}
