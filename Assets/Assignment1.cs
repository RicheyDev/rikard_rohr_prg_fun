using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment1 : ProcessingLite.GP21
{
    //Hjälpmedel för att hitta position
    [Header("Rectangle position")]

    [SerializeField] float rectXPosition = 1.25f;
    [SerializeField] float rectYPosition = 8.35f;
    [SerializeField] float rectWidth = 1f;
    [SerializeField] float rectHeight = 4f;

    [Header("Circle position")]

    [SerializeField] float circleX = 1.47f;
    [SerializeField] float CircleY = 3f;
    [SerializeField] float CircleSize = 1f;

    [SerializeField] float xPosition = 0f;
    [SerializeField] float yPosition = 0f;
    //Hjälpmedel för att hitta position


    // Circle Movements
    float yCirclePosition = 3f;
    bool dirUp = true;
    // Circle Movements

    //Cycle values
    float xMovementValueCycle = 0;
    float MovementConstantCycle = 0.5f;
    //Cycle values

    void Start()
    {
        NoStroke(); //Removes strokes for all underlying shapes.
    }

    void Update()
    {
        Background(12, 0, 10);

        MovementCycle();

        LetterR();
        LetterI();
        LetterC();
        LetterH();
        LetterE();
        LetterY();
        LetterExclamation();

        Circles();
    }

    private void LetterExclamation()
    {
        Fill(Random.Range(10, 255), Random.Range(0, 0), Random.Range(160, 255));

        Rect(16.91f, 8.4f, 16.6f, 4.9f); //Top
        Rect(16.91f, 4.47f, 16.6f, 4f); //Bottom
    }

    private void LetterY()
    {
        Fill(255, 200, 100);

        Rect(13.01f, 8.4f, 13.33f, 6.2f); //Left Y
        Rect(13.15f, 6.55f, 15.46f, 6.2f); //Middle Y
        Rect(15.46f, 8.4f, 15.12f, 6.21f); //Right Y
        Rect(14.44f, 6.34f, 14.06f, 4f); //Bottom Y
    }

    private void LetterE()
    {
        Fill(Random.Range(100, 255), Random.Range(10, 100), Random.Range(160, 255));

        Rect(10.46f, 8.35f, 10.15f, 4f); //Left E
        Rect(10.34f, 8.35f, 12.3f, 8.04f); //Top E
        Rect(11.55f, 6.27f, 10.16f, 5.93f); //Middle E
        Rect(10.32f, 4.32f, 12.28f, 4f); //Bottom E
    }

    private void LetterH()
    {
        Fill(100, 202, 100);

        Rect(7.38f, 8.35f, 7.07f, 4f); //Left H
        Rect(9.46f, 6.25f, 7.17f, 5.9f); //Left H
        Rect(9.5f, 8.35f, 9.19f, 4f); //Right H
    }

    private void LetterC(float x = 3, float y = 3)
    {
        Fill(200, 202, 100);

        Rect(4.89f, 8.35f, 4.6f, 4f); //Left C
        Rect(6.51f, 8.35f, 4.78f, 8.06f); //Left C
        Rect(4.8f, 4.3f, 6.52f, 4f); //Bottom C
    }

    private void LetterI()
    {
        Fill(Random.Range(1, 200), Random.Range(10, 100), Random.Range(160, 255));

        Rect(4.06f, 8.35f, 3.79f, 4f);
    }

    private void LetterR()
    {
        Fill(90, 202, 50);

        Rect(1.25f, 8.35f, 1f, 4f); //Left Side R
        Rect(1.25f, 8.35f, 3.2f, 8.1f); //Top R
        Rect(1.25f, 6.42f, 3.2f, 6.16f); //Bottom Higher R
        Rect(3.2f, 8.35f, 2.95f, 6.19f); //Right R
        Rect(2.64f, 6.38f, 2.35f, 4f); //Bottom Lower R
    }

    void Circles()
    {
        Fill(100, 202, 150);

        Circle(1.6f + xMovementValueCycle, yCirclePosition, 1f);

        CircleVibrate();

        Fill(90, 150, 150);
        Circle(3.6f + +xMovementValueCycle, 3f, 1f);

        Fill(100, 10, 190);
        Circle(6f + xMovementValueCycle, yCirclePosition, 1f);

        Fill(10, 167, 20);
        Circle(7.2f + xMovementValueCycle, 3f, 1f);

        Fill(80, 100, 90);
        Circle(9.7f + xMovementValueCycle, yCirclePosition, 1f);

        Fill(255, 255, 150);
        Circle(11.8f + xMovementValueCycle, 3f, 1f);

        Fill(80, 202, 20);
        Circle(14f + xMovementValueCycle, yCirclePosition, 1f);

        Fill(200, 10, 190);
        Circle(16.49f + xMovementValueCycle, 3f, 1f);
    }

    private void CircleVibrate()
    {
        // Upp and down 
        if (dirUp)
        {
            yCirclePosition += Time.deltaTime * 1.6f;
        }
        else
        {
            yCirclePosition -= Time.deltaTime * 1.6f;
        }

        if (yCirclePosition <= 2f)
        {
            dirUp = true;
        }
        if (yCirclePosition >= 3f)
        {
            dirUp = false;
        }
    }

    //Ändrar värdet så förflyttning sker x antal punkter i en loop. 
    private void MovementCycle()
    {
        xMovementValueCycle = xMovementValueCycle + MovementConstantCycle * Time.deltaTime * 4;

        if (xMovementValueCycle >= 1f || xMovementValueCycle <= 0f)
        {
            MovementConstantCycle = MovementConstantCycle *  -1;
        }
    }

}




