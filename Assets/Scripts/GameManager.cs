using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static int playerHealth = 20;
    public static int dirtySocks = 0;
    public static int cleanSocks = 4;   // hardcoding for game jam reasons
    public static dontDestroy BGMinstance;

    public static void reset()
    {
        playerHealth = 20;
        dirtySocks = 0;
        cleanSocks = 4;
    }
}
