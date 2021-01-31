using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fade1 : MonoBehaviour
{
    public float duration = 1f;
    public float stay = 1f;
    public CanvasGroup canvGroup1;
    // public CanvasGroup canvGroup2;

    private bool isFaded = false;
    private int slide = 1;
    private float timeNow;
    // Start is called before the first frame update
    void Start()
    {
        timeNow = Time.time;
        // fade in at start
        Fade();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape")) {
            SceneManager.LoadScene("title");
        }
    }

    public void Fade() {
        // start fade in
        StartCoroutine(fadeIn(canvGroup1, canvGroup1.alpha, isFaded ? 0 : 1));
    }
    public void DestroyIt() {
        Destroy(gameObject);
    }

    public IEnumerator fadeIn(CanvasGroup canvGroup, float start, float end) {
        float counter = 0f;
        while (counter < duration) {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / duration);

            yield return null;
        }
    }
}
