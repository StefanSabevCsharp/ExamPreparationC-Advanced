int[] ints = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

char[,] matrix = new char[ints[0], ints[1]];
int myRow = 0;
int myCol = 0;
int moves = 0;
int touchedOpponents = 0;
for (int rows = 0; rows < matrix.GetLength(0); rows++)
{
    char[] line = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

    for (int cols = 0; cols < matrix.GetLength(1); cols++)
    {
        //fill our matrix
        matrix[rows, cols] = line[cols];
        if (line[cols] == 'B')
        {
            myRow = rows;
            myCol = cols;
        }

    }
}
string command = string.Empty;

while ((command = Console.ReadLine()) != "Finish")
{
    if (command == "up")
    {
        if (isValidPosition(myRow - 1, myCol, matrix))
        {
            if (matrix[myRow - 1, myCol] == 'P')
            {
                touchedOpponents++;

            }

            matrix[myRow - 1, myCol] = 'B';
            matrix[myRow, myCol] = '-';
            myRow--;
                moves++;

        }
    }
    else if (command == "down")
    {
        if (isValidPosition(myRow + 1, myCol, matrix))
        {
            if (matrix[myRow + 1, myCol] == 'P')
            {
                touchedOpponents++;

            }

            matrix[myRow + 1, myCol] = 'B';
            matrix[myRow, myCol] = '-';
            myRow++;
                moves++;
        }
    }
    else if (command == "left")
    {
        if (isValidPosition(myRow, myCol - 1, matrix))
        {
            if (matrix[myRow, myCol - 1] == 'P')
            {
                touchedOpponents++;

            }

            matrix[myRow, myCol - 1] = 'B';
            matrix[myRow, myCol] = '-';
            myCol--;
                moves++;
        }
    }
    else if (command == "right")
    {
        if (isValidPosition(myRow, myCol + 1, matrix))
        {
            if (isValidPosition(myRow, myCol + 1, matrix))
            {
                if (matrix[myRow, myCol + 1] == 'P')
                {
                    touchedOpponents++;

                }

                matrix[myRow, myCol + 1] = 'B';
                matrix[myRow, myCol] = '-';
                myCol++;
                    moves++;
            }
        }
    }
    if (touchedOpponents == 3)
    {
        break;
    }
}
Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {moves}");

bool isValidPosition(int row, int col, char[,] matrix)
{
    return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1) && matrix[row, col] != 'O';
}