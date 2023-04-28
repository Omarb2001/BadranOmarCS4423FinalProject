using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public static float difficulty = 1f;
    public static string playerName = "Player1";

    public static string levelName = "LevelOneScript";
    public static float enemyDamage = 25f;
    public static float damage = 0f;
    public static int lives = 3;
    public static int numOfEnemies = 0;


    public void MainMenu(){
        SceneManager.LoadScene("MenuScreen");
    }
    public void Play(){
        SceneManager.LoadScene("SelectMapScreen");
    } //"play" button in Main Menu

    public void Quit(){
        Application.Quit();
    } //"Quit" Button in main Menu

    public void OptionsButton(){
        Debug.Log("switching scenes");
        SceneManager.LoadScene("OptionsScreen");
    } //"Options" Button
    

    public void LevelOne(){
        levelName = "LevelOneScene";
        numOfEnemies = 5;
        SceneManager.LoadScene("SelectCharacterScreen");
    }

    public void LevelTwo(){
        levelName = "LevelTwoScene";
        numOfEnemies = 6;
        SceneManager.LoadScene("SelectCharacterScreen");
    }

    public void LevelThree(){
        levelName = "LevelThreeScene";
        numOfEnemies = 6;
        SceneManager.LoadScene("SelectCharacterScreen");
    }

    public void PlayerOne(){
        playerName = "Player1";
        damage = 25f;
        SceneManager.LoadScene("SelectDifficultyScreen");
    }

    public void PlayerTwo(){
        playerName = "Player2";
        damage = 5f;
        SceneManager.LoadScene("SelectDifficultyScreen");
    }

    public void PlayerThree(){
        playerName = "Player3";
        damage = 20f;
        SceneManager.LoadScene("SelectDifficultyScreen");
    }

    public void Easy(){
        lives = 3;
        difficulty = 0.75f;
        enemyDamage = 25f;
        enemyDamage *= difficulty;
        SceneManager.LoadScene(levelName);
    }

    public void Normal(){
        lives = 3;
        difficulty = 1f;
        damage *= difficulty;
        enemyDamage = 25f;
        enemyDamage *= difficulty;
        SceneManager.LoadScene(levelName);
    }

    public void Hard(){
        lives = 3;
        difficulty = 1.35f;
        damage *= difficulty;
        enemyDamage = 25f;
        enemyDamage *= difficulty;
        SceneManager.LoadScene(levelName);
    }

    public static void EndGame(){
        if (numOfEnemies <1){
            SceneManager.LoadScene("YouWin");
        }else{
            SceneManager.LoadScene("YouLose");
        }
    }

    public static void EnemyDead(){
        numOfEnemies -=1;
    }

}
