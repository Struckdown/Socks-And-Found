using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCuts : MonoBehaviour
{

    public Animator transition;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(LoadLevel());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(2);
        // Debug.Log("Loaded Main");

        SceneManager.LoadScene("Main");
    }
}
