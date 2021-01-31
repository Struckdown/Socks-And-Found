using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credits : MonoBehaviour
{
    public GameObject creditMenu;
    public GameObject mainMenu;
    public bool showCredit = false;
    public void toggleCredits() {
        showCredit = !showCredit;
        creditMenu.gameObject.SetActive(showCredit);
        mainMenu.gameObject.SetActive(!showCredit);
        // if (showCredit) {
        //     creditMenu.gameObject.SetActive(showCredit);
        //     mainMenu.gameObject.SetActive(!showCredit);
        // } else {
        //     mainMenu.gameObject.SetActive(showCredit);
        //     creditMenu.gameObject.SetActive(!showCredit);
        // }
    }
}
