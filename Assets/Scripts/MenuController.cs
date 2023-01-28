using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Singleplayer(){
        SceneManager.LoadScene("Singleplayer");
    }
    public void Multiplayer(){
        SceneManager.LoadScene("Multiplayer");
    }
    public void Quit(){
        Application.Quit();
    }
}
