using UnityEngine;

public class GameOfLife : ProcessingLite.GP21
{
    GameCell[,] cells; //Our game grid matrix
    bool[,] nextGenCells; //Our game grid matrix of next gen cells. En bool som avgör om de är levande eller döda.
    float cellSize = 0.8f; //Size of our cells
    int numberOfColums;
    int numberOfRows;
    int spawnChancePercentage = 40;
    public int calculateNumberOfGen;

    //Räkna antal generationer o
    //Skulle kunna färga stabila former.

    void Start()
    {
        //Lower framerate makes it easier to test and see whats happening.
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 4;

        //Calculate our grid depending on size and cellSize
        numberOfColums = (int)Mathf.Floor(Width / cellSize);
        numberOfRows = (int)Mathf.Floor(Height / cellSize);

        //Initiate our matrix array
        cells = new GameCell[numberOfColums, numberOfRows];
        nextGenCells = new bool[numberOfColums, numberOfRows];


        //Create all objects

        //For each row
        for (int y = 0; y < numberOfRows; ++y)
        {
            //for each column in each row
            for (int x = 0; x < numberOfColums; ++x)
            {
                //Create our game cell objects, multiply by cellSize for correct world placement
                cells[x, y] = new GameCell(x * cellSize, y * cellSize, cellSize);

                //Random check to see if it should be alive
                if (Random.Range(0, 100) < spawnChancePercentage)
                {
                    cells[x, y].alive = true;
                }
            }
        }
    }

    void Update()
    {
        //Clear screen
        Background(0);

        //TODO: update buffer
        CalculateCellState();

        UpdateCellState();

        //Draw all cells.
        DrawCells();
    }

    private void DrawCells()
    {
        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColums; x++)
            {

                //Draw current cell
                cells[x, y].Draw();

                if (nextGenCells[x, y] == false)
                {
                    Fill(0, 0, 255);

                    //Fill(Random.Range(0, 250), Random.Range(0, 250), Random.Range(0, 250));
                }

                Stroke(0);

                // Jag vill ebart byta färg på nyfödda celler, men bevara färgern på de gamla.

                //if .


                calculateNumberOfGen = calculateNumberOfGen++;
                print(calculateNumberOfGen);
            }
        }

    }


    private void CalculateCellState()
    {
   
        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColums; x++)
            {
                int liveNeighbors = 0;

                //Try empty men finns ingenting där
                try
                {
                    //Övre rad
                    //if (y != numberOfRows - 1)
                    {
                        if (CheckCell(x - 1, y + 1))
                        {
                            liveNeighbors = liveNeighbors + 1;
                        }

                        if (CheckCell(x, y + 1))
                        {
                            liveNeighbors = liveNeighbors + 1;
                        }

                        if (CheckCell(x + 1, y + 1))
                        {
                            liveNeighbors = liveNeighbors + 1;
                        }
                    }

                    //Mellanrad

                    //if (x != 1 || x != numberOfColums - 1 )
                    {
                        if (CheckCell(x - 1, y))
                        {
                            liveNeighbors = liveNeighbors + 1;
                        }

                        if (CheckCell(x + 1, y))
                        {
                            liveNeighbors = liveNeighbors + 1;
                        }
                    }

                    //Bottenrad

                    //if (y != -1)
                    {
                        if (CheckCell(x - 1, y - 1))
                        {
                            liveNeighbors = liveNeighbors + 1;
                        }

                        if (CheckCell(x, y - 1))
                        {
                            liveNeighbors++;
                        }

                        if (CheckCell(x + 1, y - 1))
                        {
                            liveNeighbors += 1;
                        }
                    }
                }
                catch (System.Exception)
                {
                    //Try and catch, men det finns inget att catcha så därför är denna tom. 
                }
                NoteNextGenCells(liveNeighbors, x, y);
            }

        }
    }

    private void NoteNextGenCells(int liveNeighbors2, int x, int y)
    {
        bool isAliveNextGen = cells[x, y].alive;

        if (liveNeighbors2 == 3)
        {
            isAliveNextGen = true;
        }
        if (liveNeighbors2 < 2)
        {
            isAliveNextGen = false;
        }
        if (liveNeighbors2 > 3)
        {
            isAliveNextGen = false;
        }
        /*
        Any live cell with two or three live neighbours survives.
        Any dead cell with three live neighbours becomes a live cell.
        All other live cells die in the next generation. Similarly, all other dead cells stay dead.
        */


        //Debug.Log("position: " + x + " " + y);
        //Debug.Log("Grannar: " + liveNeighbors2 + " ska vi leva next gen? " + isAliveNextGen);
        nextGenCells[x, y] = isAliveNextGen;
    }

    private bool CheckCell(int cellX, int cellY)
    {
        return cells[cellX, cellY].alive;
    }

    private void UpdateCellState()
    {
        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColums; x++)
            {
                //loopar igenom cells och sätter det till next gencells värden.
                cells[x, y].alive = nextGenCells[x, y];
            }
        }
    }

    }




    //You will probebly need to keep track of more things in this class
    public class GameCell : ProcessingLite.GP21
{
    public float x, y; //Keep track of our position
    float size; //our size

    //Keep track if we are alive
    public bool alive = false;

    //Constructor
    public GameCell(float x, float y, float size)
    {
        //Our X is equal to incoming X, and so forth
        //adjust our draw position so we are centered
        this.x = x + size / 2;
        this.y = y + size / 2;

        //diameter/radius draw size fix
        this.size = size / 2;
    }

    public void Draw()
    {
        //If we are alive, draw our dot.
        if (alive)
        {
            //draw our dots
            Circle(x, y, size);

        }
    }
}