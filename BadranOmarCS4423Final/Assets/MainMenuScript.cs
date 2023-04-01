using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public static float difficulty = 1;
    public static string playerName = "Player1";

    public static string levelName = "LevelOneScript";


    public void Play(){
        SceneManager.LoadScene("SelectMapScreen");
    } //"play" button in Main Menu

    public void Quit(){
        Application.Quit();
    } //"Quit" Button in main Menu

    public void Options(){
        SceneManager.LoadScene("OptionsScreen");
    } //"Options" Button that will exist in multiple scripts
    

    public void LevelOne(){
        levelName = "LevelOneScene";
        SceneManager.LoadScene("SelectCharacterScreen");
    }

    public void LevelTwo(){
        levelName = "LevelTwoScene";
        //SceneManager.LoadScene("SelectCharacterScreen");
    }

    public void LevelThree(){
        levelName = "LevelThreeScene";
        //SceneManager.LoadScene("SelectCharacterScreen");
    }

    public void PlayerOne(){
        playerName = "Player1";
        SceneManager.LoadScene("SelectDifficultyScreen");
    }

    public void PlayerTwo(){
        playerName = "Player2";
        SceneManager.LoadScene("SelectDifficultyScreen");
    }

    public void PlayerThree(){
        playerName = "Player3";
        SceneManager.LoadScene("SelectDifficultyScreen");
    }

    public void Easy(){
        difficulty = 0.75f;
        SceneManager.LoadScene(levelName);
    }

    public void Normal(){
        difficulty = 1f;
        SceneManager.LoadScene(levelName);
    }

    public void Hard(){
        difficulty = 1.25f;
        SceneManager.LoadScene(levelName);
    }

}
