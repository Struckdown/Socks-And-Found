using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introCard : MonoBehaviour
{
    public float duration = 1f;
    public float stay = 1f;
    public CanvasGroup canvGroup;
    private bool isFaded = false;
    private bool fadingOut = false;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        Fade();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= duration + stay){
        //code something
            StartCoroutine(fadeIn(canvGroup, canvGroup.alpha, 0));
        } else if (Time.time >= duration * 2 + stay){
        //code something
            Destroy(gameObject);
        }
    }
    public void Fade() {
        // start fade in
        StartCoroutine(fadeIn(canvGroup, canvGroup.alpha, isFaded ? 0 : 1));
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
