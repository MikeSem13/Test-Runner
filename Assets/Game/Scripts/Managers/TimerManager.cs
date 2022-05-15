using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
   public PlayerObstacleDetector ObstacleDetector;
   
   public List<TimerModel> TimerModels = new List<TimerModel>();

   private void Start()
   {
      foreach (var timer in TimerModels)
      {
         timer.CurrentTime = timer.StartTime;
      }
   }

   private void Update()
   {
      if(ObstacleDetector.IsGameover) WorkOfTimer("Timer Text");
   }

   public void GetTextForTimer(GameObject Panel, int indexOfTimer, int IndexOfPanelChild)
   {
      TimerModels[indexOfTimer].TextOfTimer = Panel.transform.GetChild(IndexOfPanelChild).gameObject;
   }

   public void WorkOfTimer(string timerId)
   {
      TimerModel timerModel = TimerModels.FirstOrDefault(model => model.TimerId == timerId);

      timerModel.CurrentTime -= Time.deltaTime;
      
      ConvertTextsOfTimer(timerModel);
   }

   public void ConvertTextsOfTimer(TimerModel timerMode)
   {
      timerMode.TextOfTimer.GetComponent<Text>().text = timerMode.CurrentTime.ToString("0");
   }
}
