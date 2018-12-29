using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager {

    private static int lives = 3;
    private static int points = 0;
    private static int pointsForLife = 10;
    private static int currentPointsForLife = 0;


    

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


       public static int Points
        {
        get
        {
            return points;
        }

        set {
            currentPointsForLife += value - points;
            if (currentPointsForLife >= pointsForLife)
            {
                 lives++;
                 currentPointsForLife -= pointsForLife;
            }
            points = value;
            Debug.Log("You have points: " + points);
        }
    }

}
