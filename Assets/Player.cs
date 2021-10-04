using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ProcessingLite.GP21
{
    public Vector2 position;

    public Vector2 positionChar2X;
    public Vector2 positionChar2Y;
    public Vector2 accelerationChar2;
    public Vector2 velocitychar2;

    float speedChar2 = 10f;

    public float circleDiam = 1f;

    public Player()
    {
        positionChar2X = new Vector2(Width / 2, Height / 2); //middle of the screen
        positionChar2Y = new Vector2(Width / 2, Height / 2); //middle of the screen
    }

    public void UpdatePlayer()
    {
        //Inputen från spelaren i X och Y led. Gånger farten. 
        float x = Input.GetAxisRaw("Horizontal") * speedChar2 * Time.deltaTime;
        float y = Input.GetAxisRaw("Vertical") * speedChar2 * Time.deltaTime;

        //Stoppar sedan accelerationsvärderna i en 2D vector. 
        accelerationChar2 = new Vector2(x, y);

        //Räknar sedan ut hastigheten som är hastigheten (Riktningen) + accelerationen gånger tiden. 
        velocitychar2 += accelerationChar2 * Time.deltaTime;

        //plussa på hastigheten på positionen.
        positionChar2X += new Vector2(x, y);
        positionChar2Y += new Vector2(x, y);


        if (velocitychar2.magnitude > 0.01f)
        {
            velocitychar2 = velocitychar2.normalized * 0.01f;
        }
        else if (velocitychar2 == Vector2.zero)
        {
            velocitychar2 *= 0.99f;
        }

        //Boarders
        if (positionChar2X.x > Width)
        {
            positionChar2X.x -= Width;
        }
        if (positionChar2X.x < 0)
        {
            positionChar2X.x += Width;
        }

        if (positionChar2Y.y > Height)
        {
            positionChar2Y.y -= Height;
        }
        if (positionChar2Y.y < 0)
        {
            positionChar2Y.y += Height;
        }

        //Draw Player
        Circle(positionChar2X.x, positionChar2Y.y, circleDiam);
        Fill(0, 255, 191);

    }

}
