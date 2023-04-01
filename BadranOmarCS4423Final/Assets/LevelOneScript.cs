using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player1Prefab;
    public Player player2Prefab;
    public Player player3Prefab;

    static Player player;
    public static int numOfEnemies = 20;
    public static Transform spawnPoint;

    

    void Awake()
    {
        spawnPoint = GameObject.Find("SpawnPoint").transform;
        if(MainMenuScript.playerName.Contains("Player1")){
            player = Instantiate(player1Prefab, spawnPoint.position, spawnPoint.rotation); 
        }else if(MainMenuScript.playerName.Contains("Player2")){
            player = Instantiate(player3Prefab, spawnPoint.position, spawnPoint.rotation); 
        } else {
            player = Instantiate(player3Prefab, spawnPoint.position, spawnPoint.rotation); 
        }

        Debug.Log("starting Game");
    }

   public static void EndGame(){
            //something to end the game
    }

    
    
    void Update()
    {
        if(numOfEnemies<1){
            EndGame();
        }
    }
}
