using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment3 : ProcessingLite.GP21
{

    Vector2 circlePosition;
    float circleDiam = 1f;
    
    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Background(100,50,60);
        Circle(circlePosition.x, circlePosition.y, circleDiam);
        Fill(90, 90, 80);


        //Get mouse position 
        if (Input.GetMouseButtonDown(0))
        {
            circlePosition.x = MouseX;
            circlePosition.y = MouseY;

            Debug.Log("Mustryck X" + MouseX + "Mustryck Y" + MouseY);

        }

        //Get Line
        if (Input.GetMouseButton(0))
        {
            Line(circlePosition.x, circlePosition.y, MouseX, MouseY);
        }

        //Fire Direction
        if (Input.GetMouseButtonUp(0))
        {
            direction = new Vector2(MouseX - circlePosition.x, MouseY - circlePosition.y);
            Debug.Log(direction);

        }

        //Wall container
        if (!Input.GetMouseButton(0))
        {
            if (circlePosition.y >= Height || circlePosition.y <= 0)
            {
                direction.y *= -1;
            }
            //Om X positionen är större än bredden samt mindre eller lika med 0
            if (circlePosition.x >= Width || circlePosition.x <= 0)
            {
                direction.x *= -1;
            }

            circlePosition += direction * Time.deltaTime;

        }

    }

}