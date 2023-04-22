using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapProjectile : MonoBehaviour
{
    private float speed = 20f;
    public Rigidbody2D blt;
    void Start()
    {
        blt.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        //Animation here
        Player player = hitInfo.GetComponent<Player>();
        if (player != null){
            player.TakeDamage(100.0f);
        }
        if(!hitInfo.name.Contains("Enemy") && !hitInfo.name.Contains("EnemyBullet")){
            Destroy(gameObject);
        }
    }

}