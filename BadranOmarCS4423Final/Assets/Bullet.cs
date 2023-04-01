using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 20f;
    public static float damage = 0f;
    public Rigidbody2D blt;
    void Start()
    {
        blt.velocity = transform.right * speed;    
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        //Animation here
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null){
            enemy.TakeDamage(damage);
        }
        if(!hitInfo.name.Contains("Bullet") && !hitInfo.name.Contains("Player")){
            Destroy(gameObject);
        }
    }

}
