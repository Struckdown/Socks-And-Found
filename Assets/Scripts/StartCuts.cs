using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCuts : MonoBehaviour
{

    public Animator transition;
    public string nextScene = "Main";

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(LoadLevel());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void publicStart()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(2);


        SceneManager.LoadScene(nextScene);
    }
}
