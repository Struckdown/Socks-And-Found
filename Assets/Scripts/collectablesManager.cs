using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class collectablesManager : MonoBehaviour
{
    public static collectablesManager instance;
    public TextMeshProUGUI textClean;
    public TextMeshProUGUI textDirty;
    public int cleanSocks = 0;
    public int dirtySocks = 0;
    public AudioSource audioSourceDirty;
    public AudioSource audioSourceClean;
    public AudioSource audioSourceCleanSocks;

    // Start is called before the first frame update
    void Start()
    {
        cleanSocks = GameManager.cleanSocks;
        dirtySocks = GameManager.dirtySocks;
        textClean.text = "x" + cleanSocks.ToString();
        textDirty.text = "x" + dirtySocks.ToString();
        if (instance==null) {
            instance = this;
        }
    }

    // Update is called once per frame
    public void changeCleanSocks(int sockValue) {
        audioSourceClean.Play();
        cleanSocks += sockValue;
        textClean.text = "x" + cleanSocks.ToString();
        GameManager.cleanSocks = cleanSocks;
    }
    public void changeDirtySocks(int sockValue) {
        audioSourceDirty.Play();
        dirtySocks += sockValue;
        textDirty.text = "x" + dirtySocks.ToString();
        GameManager.dirtySocks = dirtySocks;
    }
    public void cleanDirtySocks() {
        if (dirtySocks != 0) audioSourceCleanSocks.Play();
        cleanSocks += dirtySocks;
        dirtySocks = 0;
        // updates text
        textClean.text = "x" + cleanSocks.ToString();
        textDirty.text = "x" + dirtySocks.ToString();
        GameManager.cleanSocks = cleanSocks;
        GameManager.dirtySocks = dirtySocks;
    }
    public bool shoot() {
        if (cleanSocks == 0) return false;
        cleanSocks--;
        textClean.text = "x" + cleanSocks.ToString();
        GameManager.cleanSocks = cleanSocks;
        return true;
    }
}
