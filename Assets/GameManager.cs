using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager {

    // private static int lives = 0;

//  private static int abilityPoints = 0; 
    private static int points = 0;
    private static int pointsForAbility = 1;
    private static int currentPointsForAbility = 0;
    public static bool abilityTrue = false;

 // private static int abilityPoints2 = 0;
    private static int points2 = 0;
    private static int pointsForAbility2 = 1;
    private static int currentPointsForAbility2 = 0;
    public static bool abilityTrue2 = false;

    
/*
    public static int Lives
    {
        get
        {
            return lives;
        }

        set
        {
            lives = value;
        }
    }
*/

       public static int Points
       {
           get
           {
           return points;
           }

           set
           {
                currentPointsForAbility += value - points;
                if (currentPointsForAbility >= pointsForAbility)
                {
                //              lives++;
                abilityTrue = true;
                }
                else
                {
                abilityTrue = false;
                }
                points = value;
                Debug.Log("You have points: " + points);
           }
       }

       public static int Points2
       {
           get
           {
            return points2; 
           }

           set
           {
                currentPointsForAbility2 += value - points2;
                if (currentPointsForAbility2 >= pointsForAbility2)
                {
                //              lives++;
                abilityTrue2 = true;
                }
                else
                {
                abilityTrue2 = false;
                }
                points2 = value;
                Debug.Log("You have points: " + points2);

           }


       }






}
