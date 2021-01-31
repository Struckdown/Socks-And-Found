using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void play() {
        //Cursor.visible = false;   // We probably don't want to hide the mouse if this is a mouse shooting game
        SceneManager.LoadScene("Main");
        GameManager.playerHealth = 20;  //Kinda bad to hardcode this here, but gamejam crunch
    }

    public void quit() {
        Application.Quit();
    }

}