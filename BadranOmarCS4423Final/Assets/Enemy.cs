using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float speed = 2;
    public Rigidbody2D rb;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float range = 0.25f;
    // Update is called once per frame
    public float fireRate = 1f;
    public float lastShootTime = 0.25f;

    Vector3 Origin;

    
    public void TakeDamage (float damage){
        health -= damage;
        if(health<=0){
            Die();
        }
    }

    void Awake(){
        Origin = transform.position;
        Debug.Log(Origin);
    }

    void FixedUpdate(){
    }

    void Die() {
        Destroy(gameObject);
    }

    

    public void MoveToward(Vector3 position){
        Move(position - transform.position);
    }

    public void MoveTowardOrigin(){
        Move(Origin - transform.position);
    }

    public void Move(Vector3 offset){
        if(offset != new Vector3(2,0,0) && offset != new Vector3(-2,0,0)/*Vector3.zero*/){
            offset.Normalize();
            //offset *= Time.fixedDeltaTime;
            //rb.MovePosition(transform.position + ((offset)*speed));
            Vector3 vel = offset *= speed;
            rb.velocity = vel;
            //Debug.Log(offset);
        }else{
            //Debug.Log("stopping");
            Stop();
        //asc.ChangeAnimationState("Idle"); 
        }
    }

    public void Stop(){
        rb.velocity = Vector3.zero;
    }

    public void Shoot(){
         if (EnemyBullet.damage == 0){
            EnemyBullet.damage = 25f;
         }
         GameObject bullet;
         if(Time.time > lastShootTime + fireRate){
                bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                lastShootTime = Time.time;
                Destroy(bullet, range);
            }
    }

    public Vector3 GetOrigin(){
        return Origin;
    }


}
