using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    static internal bool onPause = false;

    public void PausePlay()
    {
        onPause = !onPause;
        Debug.Log("onPause: " + onPause);
    }
}
