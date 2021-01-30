using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// Quits the player when the user hits escape

public class quit : MonoBehaviour {
    void Update() {
        // TODO: if something, quit
        if (Input.GetKey("escape")) {
            SceneManager.LoadScene("title");
        }
    }
}
