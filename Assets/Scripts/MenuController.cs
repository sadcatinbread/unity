using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public bool failed = false;
    public TMP_Text temp;
    public int score = 0;
    private bool paused = false;
    public void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && paused == false){
            Time.timeScale = 0;
            paused = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && paused == true){
            Time.timeScale = 1;
            paused = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }

        if(failed == true){
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        temp.text = string.Concat(score);
    }
    public void resumeTime(){
        Time.timeScale = 1;
        paused = false;
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
    }
    public void Singleplayer(){
        SceneManager.LoadScene("Singleplayer");
        Time.timeScale = 1;
        failed = false;
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
    }
    public void Multiplayer(){
        SceneManager.LoadScene("Multiplayer");
    }
    public void Menu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit(){
        Application.Quit();
    }
}
