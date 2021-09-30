using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4 : ProcessingLite.GP21
{
    float circleDiam = 1f;
    public Vector2 direction;

    float charactersOffset = 1.2f;

    //Character 1
    float character1PosX;
    float character1PosY;

    float speedChar1 = 5f;

    //Character 2
    Vector2 positionChar2X;
    Vector2 positionChar2Y;
    Vector2 accelerationChar2;
    Vector2 velocitychar2;

    float speedChar2 = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // Starting position + offset value on Y-Axis
        character1PosX = Width / 2;
        character1PosY = Height / 2 + charactersOffset;


        positionChar2X = new Vector2(Width / 2, Height / 2); //middle of the screen
        positionChar2Y = new Vector2(Width / 2, Height / 2); //middle of the screen

    }

    // Update is called once per frame
    void Update()
    {

        Background(100, 50, 60);

        /* 
        //Draw Character 1
        Circle(character1PosX, character1PosY, circleDiam);
        Fill(90, 90, 255);

        character1PosX += Input.GetAxis("Horizontal") * speedChar1 * Time.deltaTime;
        character1PosY +=  Input.GetAxis("Vertical") * speedChar1 * Time.deltaTime;

        */

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

        //Draw Character 2
        Circle(positionChar2X.x, positionChar2Y.y, circleDiam);
        Fill(255, 90, 80);

    }

}