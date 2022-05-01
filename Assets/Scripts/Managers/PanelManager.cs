using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelManager : Singleton<PanelManager>
{
   public TimerManager TimerManager;
   private PauseManager _pause;

   public List<PanelModel> Panels;

   public GameObject Canvas;
   public GameObject BackGround;
   
   private List<PanelInstanceModel> _listInstanceModels = new List<PanelInstanceModel>();
   public List<PanelInstanceModel> ListInstanceModels { get { return _listInstanceModels; } }

   private void Start()
   {
      _pause = GetComponent<PauseManager>();
   }

   public void ShowPanels(string panelId)
   {
      PanelModel panelModel = Panels.FirstOrDefault(panel => panel.PanelId == panelId);

      panelModel.Animator = panelModel.PanelPrefab.GetComponent<Animator>();

      if (panelModel != null)
      {
         var newInstatiatePanel = Instantiate(panelModel.PanelPrefab, transform);

         if(panelModel.PanelId == "GameOver_Panel") TimerManager.GetTextForTimer(newInstatiatePanel,0,1);

         newInstatiatePanel.transform.SetParent(Canvas.transform);
         
         newInstatiatePanel.transform.localPosition = Vector3.zero;

         _listInstanceModels.Add(new PanelInstanceModel
         {
            PanelId = panelId,
            PanelInstance = newInstatiatePanel,
            HaveBackground = panelModel.HaveBackground,
            TimeStop = panelModel.TimeStop
         });

         if (panelModel.HaveBackground) BackGround.SetActive(true);
         
         if(panelModel.TimeStop) _pause.TimeStop();
      }
   }

   public void HideLastPanel()
   {
      if (AnyPanelShowing())
      {
         var _lastPanel = _listInstanceModels[_listInstanceModels.Count - 1];

         _listInstanceModels.Remove(_lastPanel);
         
         Destroy(_lastPanel.PanelInstance);
         
         if(BackGround.activeSelf) BackGround.SetActive(false);
         
         if(_lastPanel.TimeStop) _pause.TimeContinuie();
      }
   }

   public bool AnyPanelShowing()
   {
      return GetCountOfPanelsInQueue() > 0;
   }
   
   public int GetCountOfPanelsInQueue()
   {
      return _listInstanceModels.Count;
   }
}
