
using UnityEngine;

public class PlayerObstacleDetector : MonoBehaviour
{
   public PanelManager PanelManager;

   public string PanelId;

   public bool IsGameover = false;
   
   public void OnControllerColliderHit(ControllerColliderHit hit)
   {
      if (hit.transform.tag == "Obstacle" && IsGameover == false)
      {
         if(PanelManager.ListInstanceModels.Count < 1) PanelManager.ShowPanels(PanelId);
         IsGameover = true;
         OffComponents();
      }
   }

   public void OffComponents()
   {
      GetComponent<BoxCollider>().enabled = false;
      GetComponent<PlayerMovement>().enabled = false;
   }
}
