using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 20f;
    public Rigidbody2D blt;


    public Player player;

    void Start()
    {
        blt.velocity = transform.right * speed;
        player = Player.FindObjectOfType<Player>();    
    }

    void Update(){
        blt.velocity = transform.right * speed;
    }

    void FixedUpdate() {
        if(Vector2.Distance(transform.position, player.transform.position) > 5){
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        //Animation here
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null){
            enemy.TakeDamage(MainMenuScript.damage);
        }
        Debug.Log(MainMenuScript.damage);
        if(!hitInfo.name.Contains("Bullet") && !hitInfo.name.Contains("Player")){
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

}
