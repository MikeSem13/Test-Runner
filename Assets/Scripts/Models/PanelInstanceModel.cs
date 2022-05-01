using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelInstanceModel
{
  [Header("Главные переменные")]
  public string PanelId;
  public GameObject PanelInstance;
  
  [Header("Анимация")]
  public Animator Animator;
  
  [Header("Булевые переменные")]
  public bool HaveBackground;
  public bool TimeStop;
}
