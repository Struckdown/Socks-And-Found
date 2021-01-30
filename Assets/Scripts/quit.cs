using UnityEngine;
using System.Collections;

// Quits the player when the user hits escape

public class quit : MonoBehaviour {
    void Update() {
        // TODO: if something, quit
        if (Input.GetKey("escape")) {
            Application.Quit();
        }
    }
}
