using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 locationToSpawnIn;
    public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
            //bumpPlayer();
            //collision.gameObject.GetComponent<playerShooter>().takeDamage(damage);
        }

    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(sceneToLoad));
    }

    IEnumerator LoadLevel(string stringLevelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(sceneToLoad);
    }
}
