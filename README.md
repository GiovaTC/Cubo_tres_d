# Cubo_tres_d

<img width="528" height="368" alt="image" src="https://github.com/user-attachments/assets/e4033efa-f940-4c1a-8859-db604b055ebf" />

using System;

class Program
{
    static void Main()
    {
        int size = 7;  // Tamaño del cubo

        // Coordenadas de los vértices del cubo 3D
        int[][] cube = new int[][]
        {
            new int[] { 0, 0, 0 },  // Vértice A (0,0,0)
            new int[] { size, 0, 0 },  // Vértice B (size, 0, 0)
            new int[] { size, size, 0 },  // Vértice C (size, size, 0)
            new int[] { 0, size, 0 },  // Vértice D (0, size, 0)
            new int[] { 0, 0, size },  // Vértice E (0, 0, size)
            new int[] { size, 0, size },  // Vértice F (size, 0, size)
            new int[] { size, size, size },  // Vértice G (size, size, size)
            new int[] { 0, size, size }  // Vértice H (0, size, size)
        };

        // Proyección isométrica
        double angle = Math.PI / 4;  // Ángulo para la rotación
        for (int i = 0; i < 8; i++)
        {
            int x = cube[i][0];
            int y = cube[i][1];
            int z = cube[i][2];

            // Rotación en 3D (proyección isométrica)
            int projectedX = (int)(x - y);
            int projectedY = (int)((x + y) / Math.Sqrt(2) - z / Math.Sqrt(2));

            // Colocar el punto en la consola (escala y desplazamiento)
            cube[i][0] = projectedX + size * 2;
            cube[i][1] = projectedY + size;

            // Dibujar el cubo
            Console.SetCursorPosition(cube[i][0], cube[i][1]);
            Console.Write("#");
        }

        // Conectar los vértices para formar el cubo
        DrawLine(cube[0][0], cube[0][1], cube[1][0], cube[1][1]);
        DrawLine(cube[1][0], cube[1][1], cube[2][0], cube[2][1]);
        DrawLine(cube[2][0], cube[2][1], cube[3][0], cube[3][1]);
        DrawLine(cube[3][0], cube[3][1], cube[0][0], cube[0][1]);

        DrawLine(cube[4][0], cube[4][1], cube[5][0], cube[5][1]);
        DrawLine(cube[5][0], cube[5][1], cube[6][0], cube[6][1]);
        DrawLine(cube[6][0], cube[6][1], cube[7][0], cube[7][1]);
        DrawLine(cube[7][0], cube[7][1], cube[4][0], cube[4][1]);

        DrawLine(cube[0][0], cube[0][1], cube[4][0], cube[4][1]);
        DrawLine(cube[1][0], cube[1][1], cube[5][0], cube[5][1]);
        DrawLine(cube[2][0], cube[2][1], cube[6][0], cube[6][1]);
        DrawLine(cube[3][0], cube[3][1], cube[7][0], cube[7][1]);

        Console.ReadLine();  // Para mantener la ventana abierta
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

Explicación del código:
Definición del Cubo: Se definen las coordenadas de los 8 vértices del cubo en 3D. Cada vértice tiene una coordenada (x, y, z).

Proyección Isométrica: El cubo se proyecta a 2D utilizando una transformación isométrica. Esto se realiza mediante un ángulo fijo (Math.PI / 4) y la proyección de las coordenadas 3D a 2D.

Rotación y Representación: La proyección de los vértices da la sensación de que el cubo tiene una rotación en el espacio 3D.

Dibujo de las Aristas: Usamos una función DrawLine que implementa el algoritmo de Bresenham para dibujar las líneas entre los vértices y formar las aristas del cubo.

Console.SetCursorPosition: Se usa para dibujar cada vértice en la posición adecuada de la consola.

Resultado esperado:
El cubo se verá como una proyección isométrica, donde las líneas representan las aristas del cubo 3D. No tendrá una animación real, pero da la impresión de un cubo girado.

Mejoras posibles:
Animación: Podrías animar el cubo haciendo que los vértices cambien de lugar con el tiempo, para que parezca que el cubo rota.

Escalado: Puedes modificar la proyección para que el cubo cambie de tamaño dependiendo de la distancia o el ángulo.

Interacción: Podrías agregar controles del usuario para que mueva el cubo o cambie el ángulo de visión.
