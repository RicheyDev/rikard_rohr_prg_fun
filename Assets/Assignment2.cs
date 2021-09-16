using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment2 : ProcessingLite.GP21
{
    int numberOfLines = 18;
    int selector = 0;

    void Start()
    {
        InvokeRepeating("Switcher", 0, 0.25f);
    }

    void Switcher()
    {
        selector++;
        selector %= 6;
    }

    void Update()
    {
        Background(25, 0, 51);
        
        for (int i = 0; i <= numberOfLines; i++)
        {
             
        float y1 = Height - i * Height / numberOfLines; //Höjden
        float x2 = i * Width / numberOfLines;  //Bredden

        int colorValue1 = Random.Range(0, 101);
        int colorValue2 = Random.Range(0, 201);
        int colorValue3 = Random.Range(0, 101);

            if (i % 5 == selector)
                Stroke(colorValue1, colorValue2, colorValue3);
            else
                Stroke(200,100,100);

        Line(0, y1, x2, 0);
        }

    }
}


