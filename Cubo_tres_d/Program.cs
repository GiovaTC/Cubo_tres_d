using System;

class program
{
    static void Main()
    {
        int size = 7; // tamaño del cubo

        // Coordenadas de los vértices del cubo 3D
        int[][] cube = new int[][]
        {
            new int[] { 0, 0, 0}, // Vertice A (0,0,0)
            new int[] {size, 0, 0 }, // Vertice B (size, 0, 0)
            new int[] {size, size, 0 }, // Vertice C (size, size, 0)
            new int[] {0, size, 0}, // Vertice D (0, size, 0)
            new int[] {0, 0, size}, // Vertice E (0, 0, size)
            new int[] {size, 0, size}, // vertice f (size, 0, size)
            new int[] {size, size, size}, // vertice g (size, size, size)
            new int[] {0, size, size} // vertice b (0, size, size)
        };

        // proyeccion isometrica
        double angle = Math.PI / 4; // Angulo para la rotacion
        for (int i = 0; i < 8; i++)
        {
            int x = cube[i][0];
            int y = cube[i][1];
            int z = cube[i][2];

            //Rotacion en 3D (proyeccion isometrica)
            int projectedX = (int)(x - y);
            int projectedY = (int)((x + y) / Math.Sqrt(2) - z / Math.Sqrt(2));

            // Colocar el punto en la consola (escala y desplazamiento)
            cube[i][0] = projectedX + size * 2;
            cube[i][1] = projectedY + size;

            // Dibujar el cubo
            Console.SetCursorPosition(cube[i][0], cube[i][1]);
            Console.Write("#");
        }

        // Conectar los vertices para formar el cubo
        DrawLine(cube[0][0], cube[0][1], cube[1][0], cube[1][1]);
        DrawLine(cube[1][0], cube[1][1], cube[2][0], cube[2][1]);
        DrawLine(cube[2][0], cube[2][1], cube[3][0], cube[3][1]);
        DrawLine(cube[3][0], cube[3][1], cube[4][0], cube[4][1]);

        DrawLine(cube[4][0], cube[4][1], cube[5][0], cube[5][1]);
        DrawLine(cube[5][0], cube[5][1], cube[6][0], cube[6][1]);
        DrawLine(cube[6][0], cube[6][1], cube[7][0], cube[7][1]);
        DrawLine(cube[7][0], cube[7][1], cube[4][0], cube[4][1]);

        DrawLine(cube[0][0], cube[0][1], cube[4][0], cube[4][1]);
        DrawLine(cube[1][0], cube[1][1], cube[5][0], cube[5][1]);
        DrawLine(cube[2][0], cube[2][1], cube[6][0], cube[6][1]);
        DrawLine(cube[3][0], cube[3][1], cube[7][0], cube[7][1]);

        Console.ReadLine(); // Para mantener la ventana abierta
    }

    static void DrawLine(int x1, int y1, int x2, int y2)
    {
        int dx = Math.Abs(x2 - x1);
        int dy = Math.Abs(y2 - y1);
        int sx = x1 < x2 ? 1 : -1;
        int sy = y1 < y2 ? 1 : -1;
        int err = dx - dy;

        while (true)
        {
            Console.SetCursorPosition(x1, y1);
            Console.Write("#");

            if (x1 == x2 && y1 == y2)
                break;

            int e2 = err * 2;
            if (e2 > -dy)
            {
                err -= dy;
                x1 += sx;
            }
            if (e2 < dx)
            {
                err += dx;
                y1 += sy;
            }
        }
    }
}
