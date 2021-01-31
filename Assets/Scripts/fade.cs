using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade : MonoBehaviour
{
    public float duration = 1f;
    public float stay = 1f;
    public CanvasGroup canvGroup1;
    public CanvasGroup canvGroup2;

    private bool isFaded = false;
    private int slide = 1;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        // fade in at start
        Fade();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= duration * 3 + stay * 3) {
            Debug.Log(1);
            StartCoroutine(fadeIn(canvGroup2, canvGroup2.alpha, 0));
        } else if (Time.time >= duration * 2 + stay * 2){
            StartCoroutine(fadeIn(canvGroup2, canvGroup2.alpha, 1));
        } else if (Time.time >= duration + stay) {
            StartCoroutine(fadeIn(canvGroup1, canvGroup1.alpha, 0));
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
