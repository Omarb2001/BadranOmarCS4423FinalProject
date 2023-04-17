using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player1Prefab;
    public Player player2Prefab;
    public Player player3Prefab;
 
    public GameObject Live;
    public GameObject Pause;
    public Image[] hearts;
    public Text enemiesRemaining;

    static Player player;
    public static bool paused = false;
    
    public static Transform spawnPoint; //probably adding a a checkpoint system.

    
    

    void Awake()
    {
        spawnPoint = GameObject.Find("SpawnPoint").transform;
        if(MainMenuScript.playerName.Contains("Player1")){
            player = Instantiate(player1Prefab, spawnPoint.position, spawnPoint.rotation); 
        }else if(MainMenuScript.playerName.Contains("Player2")){
            player = Instantiate(player2Prefab, spawnPoint.position, spawnPoint.rotation); 
        } else {
            player = Instantiate(player3Prefab, spawnPoint.position, spawnPoint.rotation); 
        }
        hearts[0].enabled = true;
        hearts[1].enabled = true;
        hearts[2].enabled = true;
        enemiesRemaining.text = MainMenuScript.numOfEnemies + " enemies remaining";
        Live.active = true;
        Pause.active = false;
        Debug.Log("starting Game");
    }

   
    
    
    void FixedUpdate()
    {
        if(MainMenuScript.numOfEnemies<1){
            MainMenuScript.EndGame();
        }
        death();
        enemydeath();
    }

    public void death(){
        if(MainMenuScript.lives<3)
            hearts[MainMenuScript.lives].enabled = false;
    }

    public void enemydeath(){
        enemiesRemaining.text = MainMenuScript.numOfEnemies + " enemies remaining";
    }

    public void pause(){
        paused = true;
        Time.timeScale = 0;
        Live.active = false;
        Pause.active = true;
    }

    public void resume(){
        paused = false;
        Time.timeScale = 1;
        Live.active = true;
        Pause.active = false;
    }
}
