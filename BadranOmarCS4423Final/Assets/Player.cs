using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float health = 100;


    public void TakeDamage(float damage){
        health -= damage;
        Debug.Log("damage");
        if (health <=0){
            die();
        }
    }

    void die(){
        MainMenuScript.lives -=1;
        if(MainMenuScript.lives < 1){
            //GameOver
            Debug.Log("Game Over");
            GameOver();
        }else{
            Respawn();
        }
    }

    
     void GameOver(){
        //idk yet
        health = 100;
        Debug.Log("Player destroyed");
        MainMenuScript.EndGame();
        Destroy(gameObject);
    }
    void Respawn(){
            health = 100;
            transform.position = LevelOneScript.spawnPoint.position;
    }

    


    // Update is called once per frame
    void Update()
    {
        
    }
}
