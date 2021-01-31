using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fade1 : MonoBehaviour
{
    public float duration = 1f;
    public float stay = 1f;
    public CanvasGroup canvGroup;
    // public CanvasGroup canvGroup2;

    private bool isFaded = false;
    private int slide = 1;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(1);
        // fade in at start
        StartCoroutine(fadeIn(canvGroup, canvGroup.alpha, isFaded ? 0 : 1));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape")) {
            SceneManager.LoadScene("title");
        }
    }

    public IEnumerator fadeIn(CanvasGroup canvGroup, float start, float end) {
        float counter = 0f;
        Time.timeScale = 1; // Dirty fix, something is setting time scale to 0 when we lose the game, this is the easy fix
        while (counter < duration) {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / duration);
            Debug.Log("counter" + counter + "duration" + duration);

            yield return null;
        }
    }
}
