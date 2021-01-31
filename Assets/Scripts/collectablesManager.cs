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

    // Start is called before the first frame update
    void Start()
    {
        if (instance==null) {
            instance = this;
        }
    }

    // Update is called once per frame
    public void changeCleanSocks(int sockValue) {
        cleanSocks += sockValue;
        textClean.text = "x" + cleanSocks.ToString();
    }
    public void changeDirtySocks(int sockValue) {
        dirtySocks += sockValue;
        textDirty.text = "x" + dirtySocks.ToString();
    }
    public void cleanDirtySocks() {
        cleanSocks += dirtySocks;
        dirtySocks = 0;
        // updates text
        textClean.text = "x" + cleanSocks.ToString();
        textDirty.text = "x" + dirtySocks.ToString();
    }
}
