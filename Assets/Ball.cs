using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : ProcessingLite.GP21
{
    //Our class variables
    public Vector2 position; //Ball position
    public Vector2 velocity; //Ball direction

    public float ballSize;
    Color ballColor;

    //Ball Constructor, called when we type new Ball(x, y);
    public Ball(float x, float y, float size, Color color)
    {
        //Set our position when we create the code.
        position = new Vector2(x, y);

        //Create the velocity vector and give it a random direction.
        velocity = new Vector2();
        velocity.x = Random.Range(0, 11) - 5;
        velocity.y = Random.Range(0, 11) - 5;

        ballSize = size;
        ballColor = color;

    }

    //Draw our ball
    public void Draw()
    {
        int r = Mathf.RoundToInt(ballColor.r * 255);
        int g = Mathf.RoundToInt(ballColor.g * 255);
        int b = Mathf.RoundToInt(ballColor.b * 255);
        Fill(r, g, b);
        Circle(position.x, position.y, ballSize);
    }

    //Update our ball
    public void UpdatePos()
    {
        position += velocity * Time.deltaTime;

        if (position.x < 0 || position.x > Width)
        {
            velocity.x *= -1;
        }
        if (position.y < 0 || position.y > Height)
        {
            velocity.y *= -1;
        }

    }
    
    public void BallColor()
    {
        Fill(255, 0, 191);
    }
}
