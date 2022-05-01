using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPanelButton : MonoBehaviour
{
    public string PanelId;
    
    public Animator AnimatorOfButton;

    public PanelManager _panelManager;

    public void ShowPanelByButton()
    {
        _panelManager.ShowPanels(PanelId);
    }

    public void AnimationToShowPanel()
    {
        AnimatorOfButton.SetTrigger("Click");
    }
}
