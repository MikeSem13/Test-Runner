using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable] public class PanelModel
{
    [Header("Главные переменные")]
    public string PanelId;
    public GameObject PanelPrefab;

    [Header("Анимация")]
    public Animator Animator;
    
    [Header("Булевые переменные")]
    public bool HaveBackground;
    public bool TimeStop;
}
