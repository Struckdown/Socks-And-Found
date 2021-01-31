using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class door : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 locationToSpawnIn;
    public LevelTransition levelLoader;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit door, transition now");
            levelLoader.LoadNextLevel(sceneToLoad);
        }

    }


}
