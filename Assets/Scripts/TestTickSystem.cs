using System;
using UnityEngine;
// ignore this it's just for debug
public class TestTickSystem : MonoBehaviour
{
   public ScoreManager scoreManager;
   void Start()
   {
      TimeTickSystem.OnTick += TimeTickSystem_OnTick;
   }
   

   void TimeTickSystem_OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
   {
      Debug.Log("tick: " + e.tick);
      /*scoreManager.AddScore(5);*/
   }
}