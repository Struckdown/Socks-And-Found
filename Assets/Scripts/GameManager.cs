using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static Vector2 startPosition = new Vector2();
    public static int playerHealth = 20;
    public static int dirtySocks = 0;
    public static int cleanSocks = 1;

    public static void reset()
    {
        playerHealth = 20;
        dirtySocks = 0;
        cleanSocks = 0;
    }
}
