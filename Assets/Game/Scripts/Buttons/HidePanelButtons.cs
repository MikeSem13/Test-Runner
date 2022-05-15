using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePanelButtons : MonoBehaviour
{
    public string PanelId;
    public PanelManager _panelManager;

    public Animator AnimatorOfButton;

    public void StartToHide()
    {
        AnimatorOfButton.SetTrigger("Click");
        _panelManager.HideLastPanel();
    }
}
