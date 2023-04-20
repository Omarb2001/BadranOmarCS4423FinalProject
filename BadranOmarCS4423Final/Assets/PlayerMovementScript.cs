using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private float horizontal;
    private float speed = 10f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    public AnimationState asc;

    [SerializeField] private Rigidbody2D player;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
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
        if(!IsGrounded()){
            asc.ChangeAnimationState("Idle");
        }else if(IsGrounded() && horizontal != 0){
            asc.ChangeAnimationState("Walk");
        }else{
            asc.ChangeAnimationState("Idle");
        }
        
    }

    private bool IsGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void flip(){
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f){
            isFacingRight = !isFacingRight;
            transform.Rotate(0,180,0);
        }
    }
}
