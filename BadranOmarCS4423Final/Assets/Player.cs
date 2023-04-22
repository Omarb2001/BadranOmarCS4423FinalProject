using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float health = 100;
    public bool checkpoint1 = false;
    public bool checkpoint2 = false;

     [SerializeField] private Transform spikeCheck;
    [SerializeField] private LayerMask spikeLayer;

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
            if(checkpoint2){
                transform.position = LevelOneScript.cp2.position;
            }else if(checkpoint1){
                transform.position = LevelOneScript.cp1.position;
            }else{
                transform.position = LevelOneScript.spawnPoint.position;
            }
    }

    
    private bool touchingSpikes(){
        return Physics2D.OverlapCircle(spikeCheck.position, 0.5f, spikeLayer);
    }


    // Update is called once per frame
    void Update()
    {
        if(!checkpoint1 && (Vector3.Distance(transform.position, LevelOneScript.cp1.position) < 3)){
            checkpoint1 = true;
        }

        if(!checkpoint2 && (Vector3.Distance(transform.position, LevelOneScript.cp2.position) < 3)){
            checkpoint2 = true;
        }

        if(touchingSpikes()){
            TakeDamage(100f);
        }
        
    }
}
