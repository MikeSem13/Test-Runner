using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public bool IsPause;
    
    public void TimeStop()
    {
        Time.timeScale = 0;
        IsPause = true;
    }

    public void TimeContinuie()
    {
        Time.timeScale = 1;
        IsPause = false;
    }
}
