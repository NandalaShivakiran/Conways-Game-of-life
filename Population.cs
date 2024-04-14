using UnityEditor.PackageManager;
using UnityEngine;

public class Population : MonoBehaviour
{
    public enum PatternType
    {
        Pattern1,
        Pattern2,
        Pattern3
    }

    [SerializeField] private PatternType currentPattern = PatternType.Pattern1;

    private CellAliveOrDead[,] cells;
    public int Width { get; private set; }
    public int Height { get; private set; }
    private bool isFirstGeneration = true;

    private void Start()
    {
        InitializePopulation();
    }

    public void InitializePopulation()
    {
        Width = 40;
        Height = 40;
        cells = new CellAliveOrDead[Width, Height];

        if (currentPattern == PatternType.Pattern1)
        {
            SetPattern1();
        }
        else if (currentPattern == PatternType.Pattern2)
        {
            SetPattern2();
        }

        else if (currentPattern == PatternType.Pattern3)
        {
            SetPattern3();
        }
        

        Debug.Log("Initial Generation:");
        PrintPopulation();
    }

    private void SetPattern1()
    {
        SetCellAliveOrDead(20, 20, CellAliveOrDead.Alive);
        SetCellAliveOrDead(20, 21, CellAliveOrDead.Alive);
        SetCellAliveOrDead(21, 20, CellAliveOrDead.Alive);
        SetCellAliveOrDead(21, 21, CellAliveOrDead.Alive);
    }

    private void SetPattern2()
    {
        SetCellAliveOrDead(18, 19, CellAliveOrDead.Alive);
        SetCellAliveOrDead(18, 21, CellAliveOrDead.Alive);
        SetCellAliveOrDead(19, 22, CellAliveOrDead.Alive);
        SetCellAliveOrDead(20, 22, CellAliveOrDead.Alive);
        SetCellAliveOrDead(21, 22, CellAliveOrDead.Alive);
        SetCellAliveOrDead(22, 22, CellAliveOrDead.Alive);
        SetCellAliveOrDead(22, 21, CellAliveOrDead.Alive);
        SetCellAliveOrDead(22, 20, CellAliveOrDead.Alive);
        SetCellAliveOrDead(21, 19, CellAliveOrDead.Alive);
    }

    private void SetPattern3()
    {
        SetCellAliveOrDead(20, 20, CellAliveOrDead.Alive);
        SetCellAliveOrDead(21, 20, CellAliveOrDead.Alive);
        SetCellAliveOrDead(20, 19, CellAliveOrDead.Alive);
        SetCellAliveOrDead(21, 19, CellAliveOrDead.Alive);
        SetCellAliveOrDead(21, 24, CellAliveOrDead.Alive);
        SetCellAliveOrDead(22, 24, CellAliveOrDead.Alive);
        SetCellAliveOrDead(23, 24, CellAliveOrDead.Alive);
        SetCellAliveOrDead(21, 25, CellAliveOrDead.Alive);
        SetCellAliveOrDead(22, 26, CellAliveOrDead.Alive);
    }

    public CellAliveOrDead GetCellAliveOrDead(int x, int y)
    {
        return cells[x, y];
    }

    public void SetCellAliveOrDead(int x, int y, CellAliveOrDead state)
    {
        cells[x, y] = state;
    }

    public void Evolve()
    {
        if (isFirstGeneration)
        {
            isFirstGeneration = false;
            return;
        }
    CellAliveOrDead[,] newCells = new CellAliveOrDead[Width, Height];

    for (int x = 0; x < Width; x++)
    {
        for (int y = 0; y < Height; y++)
        {
            int livingNeighbors = CountLivingNeighbors(x, y);

            if (cells[x, y] == CellAliveOrDead.Alive)
            {
                if (livingNeighbors < 2 || livingNeighbors > 3)
                    newCells[x, y] = CellAliveOrDead.Dead;  
                else
                    newCells[x, y] = CellAliveOrDead.Alive;
            }
            else
            {
                if (livingNeighbors == 3)
                    newCells[x, y] = CellAliveOrDead.Alive;
                else
                    newCells[x, y] = CellAliveOrDead.Dead;
            }
        }
    }

    Debug.Log("Before Evolution: ");
    PrintPopulation();

    cells = newCells;

    Debug.Log("After Evolution:");
    PrintPopulation();
}

    void PrintPopulation()
    {
        for (int y = 0; y < Height; y++)
        {
            string row = "";
            for (int x = 0; x < Width; x++)
            {
                row += (cells[x, y] == CellAliveOrDead.Alive) ? "O" : ".";
            }
        }
    }

    private int CountLivingNeighbors(int x, int y)
    {
        int count = 0;

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                int neighborX = x + i;
                int neighborY = y + j;

                if (neighborX >= 0 && neighborX < Width && neighborY >= 0 && neighborY < Height)
                {
                    if (cells[neighborX, neighborY] == CellAliveOrDead.Alive)
                        count++;
                }
            }
        }

        if (cells[x, y] == CellAliveOrDead.Alive)
            count--;

        return count;
    }
}
