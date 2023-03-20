using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private float horizontal;
    private float speed = 10f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D player;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        flip();

        if(Input.GetButtonDown("Jump") && IsGrounded()){
            player.velocity = new Vector2(player.velocity.x, jumpingPower);
        }
    }

     void FixedUpdate() {
        player.velocity = new Vector2(horizontal * speed, player.velocity.y);

        
    }

    private bool IsGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, 1f, groundLayer);
    }

    private void flip(){
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f){
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
