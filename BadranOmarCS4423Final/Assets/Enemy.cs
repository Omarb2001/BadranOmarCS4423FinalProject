using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float speed = 5f;
    //public Rigidbody2D rb;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float range = 0.20f;
    // Update is called once per frame
    public float fireRate = 1f * MainMenuScript.difficulty;
    public float lastShootTime = 0.25f;

    public Transform patrol1;

    public Transform patrol2;

    Vector3 Origin;
    public int patrolDest = 0;
    public bool isDead = false;

    
    public void TakeDamage (float damage){
        health -= damage;
        if(health<=0 && !isDead){
            isDead = true;
            Destroy(gameObject);
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
        MainMenuScript.EnemyDead();
    }

    

    public void Patrol(){
        if(patrolDest == 0){
            transform.position = Vector2.MoveTowards(transform.position, patrol1.position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, patrol1.position) < .2f || transform.position.x > patrol1.position.x){
                transform.localScale = new Vector3(-1,1,1);
                firePoint.localScale = new Vector3(-1,1,1);
                patrolDest = 1;
            }else{
                transform.localScale = new Vector3(1f,1,1);
                firePoint.localScale = new Vector3(-1,1,1);
            }
        }

        if(patrolDest == 1){
            transform.position = Vector2.MoveTowards(transform.position, patrol2.position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, patrol2.position) < .2f || transform.position.x < patrol2.position.x){
                transform.localScale = new Vector3(1,1,1);
                firePoint.localScale = new Vector3(-1,1,1);
                patrolDest = 0;
            }else{
                transform.localScale = new Vector3(-1,1,1);
                firePoint.localScale = new Vector3(1,1,1);
            }
        }
    }

    public void Chase(Transform plyrtrans){
        if (transform.position.x > plyrtrans.position.x && Vector2.Distance(transform.position, plyrtrans.position)>4){
            transform.localScale = new Vector3(-1,1,1);
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (transform.position.x < plyrtrans.position.x&& Vector2.Distance(transform.position, plyrtrans.position)>4){
            transform.localScale = new Vector3( 1,1,1);
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if(Vector2.Distance(transform.position, plyrtrans.position)<6){
                Shoot();
        }
        

    }

    public void Shoot(){
         GameObject bullet;
         if(Time.time > lastShootTime + fireRate){
                bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                if(transform.localScale.x <0){
                 bullet.transform.Rotate(0,180,0);
                }   
                lastShootTime = Time.time;
                Destroy(bullet, range);
            }
    }


}
