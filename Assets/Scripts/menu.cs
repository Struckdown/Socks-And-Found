using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        GameManager.reset();
        Time.timeScale = 1f;    // This was an annoying bug to fix... Pause was not tested (we never reverted back to normal time scale, which broke stuff)
    }


    // Pretty sure this function is unused at this point?
    public void play() {
        //Cursor.visible = false;   // We probably don't want to hide the mouse if this is a mouse shooting game
        SceneManager.LoadScene("Main");
        Debug.Log("Tried to play main");
        GameManager.playerHealth = 20;  //Kinda bad to hardcode this here, but gamejam crunch
    }

    public void quit() {
        Application.Quit();
    }

}