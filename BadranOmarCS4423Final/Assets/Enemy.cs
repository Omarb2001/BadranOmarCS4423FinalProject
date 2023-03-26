using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float speed = 2;
    public Rigidbody2D rb;
    //public GameObject enemy;
    
    public void TakeDamage (float damage){
        health -= damage;
        if(health<=0){
            Die();
        }
    }

    void start(){
    }
    void Die() {
        
        Destroy(gameObject);
    }

    

    public void MoveToward(Vector3 position){
        Move(position - transform.position);
    }

    public void Move(Vector3 offset){
        if(offset != Vector3.zero){
            offset.Normalize();
            //offset *= Time.fixedDeltaTime;
            //rb.MovePosition(transform.position + ((offset)*speed));
            Vector3 vel = offset *= speed;
            rb.velocity = vel;
        }else{
            Stop();
        //asc.ChangeAnimationState("Idle"); 
        }
    }

    public void Stop(){
        rb.velocity = Vector3.zero;
    }


}
