using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;

public class PointManager : MonoBehaviour    //gestione del punteggio 
{
   [SerializeField] Text PointText;

   [SerializeField] Text EndPointText;
   public static PointManager instance;

   [SerializeField] int points;

   private void Awake() {
       instance = this;
   }

   private void Start()
   {
       points = SaveGame.GetPoints();
       RenderPoints();
   }

   public void AddPoints(int pointsToAdd)
   {
       points += pointsToAdd;
       RenderPoints();
   }

   private void RenderPoints() 
   {
       PointText.text = points.ToString();
       EndPointText.text = points.ToString();
   }

   public void SavePoints()
   {
       SaveGame.SavePoints(points);
   }

   public void zeroPoints() 
   {
        points = 0;
        SaveGame.SavePoints(points);    
   }
}
