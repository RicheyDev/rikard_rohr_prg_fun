using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment5 : ProcessingLite.GP21
{
    public int numberOfBalls = 10;
    Ball[] balls;
    Player playerROHR;

    int textSize = 10;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = 0;

        balls = new Ball[numberOfBalls];

        playerROHR = new Player();


        //A loop that can be used for creating multiple balls.
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i] = new Ball(5, 5, 0.5f, Color.yellow);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Background(200, 40, 80);

        //Tell each ball to update it's position
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].UpdatePos();
            balls[i].Draw();

            bool hit = CircleCollision(
                balls[i].position.x,
                balls[i].position.y,
                balls[i].ballSize,
                playerROHR.positionChar2X.x,
                playerROHR.positionChar2Y.y,
                playerROHR.circleDiam);

            if (hit)
            {
                TextSize(100);
                Text("Game Over", Width / 2, Height / 2);             
                Time.timeScale = 0;
            }

        }

        Fill(0, 255, 60);
        playerROHR.UpdatePlayer();

       

    }

    bool CircleCollision(float x1, float y1, float size1, float x2, float y2, float size2)
    {
        float maxDistance = size1 / 2 + size2 / 2;

        //first a quick check to see if we are too far away in x or y direction
        //if we are far away we don't collide so just return false and be done.
        if (Mathf.Abs(x1 - x2) > maxDistance || Mathf.Abs(y1 - y2) > maxDistance)
        {
            return false;
        }
        //we then run the slower distance calculation
        //Distance uses Pythagoras to get exact distance, if we still are to far away we are not colliding.
        else if (Vector2.Distance(new Vector2(x1, y1), new Vector2(x2, y2)) > maxDistance)
        {
            return false;
        }
        //We now know the points are closer then the distance so we are colliding!
        else
        {
            return true;
        }
    }
    //A better way to do this is to have a circle object and pass the objects in to the function,
    //then we just have to pass 2 objects instead of 6 different values.


}


