using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{

    public Animator transition;
    public bool transitionAutomatically = false;
    public float timeBeforeAutoTransition = 3.0f;
    public string autolevelTransitionLevelName = "onlyUseForAutoTransitionsDoNotuseIfUsingDoors";
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        if (transitionAutomatically)
        {
            StartCoroutine(AutoLoadLevel(autolevelTransitionLevelName));
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoadNextLevel(string stringLevelName)
    {
        StartCoroutine(LoadLevel(stringLevelName));
    }

    IEnumerator AutoLoadLevel(string stringLevelName)
    {
 
        yield return new WaitForSeconds(timeBeforeAutoTransition);

        StartCoroutine(LoadLevel(stringLevelName));
    }

    IEnumerator LoadLevel(string stringLevelName)
    {
        transition.SetTrigger("Start");

        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.GetComponentInChildren<healthManager>().invulnerable = true;
        }

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(stringLevelName);
    }
}
