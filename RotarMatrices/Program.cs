int[,] matriz = { {1, 2, 3 },
                  {4, 5, 6 },
                  {7, 8, 8 } };

for(int i = 0; i <= 2; i++)
{
    for(int j = 0; j <= 2; j++)
    {
        for(int z = 2; z >= 0; z--)
        {
            matriz[i, j] = matriz[j, z];
        }
    }
}

for(int i = 0; i <= 2; i++)
{
    for(int j = 0; j <= 2; j++)
    {
        Console.Write("[" + matriz[i, j] + "]");
    }
    Console.WriteLine();
}