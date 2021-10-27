using System;

namespace WWW
{
    public class Sudoku
    {
        public int[,] grid;

        /// <summary>
        /// Initialize the grid with the given
        /// Here is an example of a grid: "...26.7.168..7..9.19...45..82.1...4...46.29...5...3.28..93...74.4..5..367.3.18..."
        /// </summary>
        /// <param name="str"> Represents the grid</param>
        public Sudoku(string str)
        {
            grid = new int[9, 9];
            int cpt = 0;
            int i = 0;
            int j = -1;
            foreach (char letter in str)
            {
                if (cpt%9 == 0)
                {
                    j++;
                    i = 0;
                }

                if (letter == '.')
                {
                    grid[j, i] = 0;
                    i++;
                    cpt++;
                }
                else if (letter != '.' && letter < 0 && letter > 9)throw new ArgumentException();
                else
                {
                    grid[j, i] = letter%48;
                    i++;
                    cpt++;
                }
            }
        }

        /// <summary>
        /// Prints the grid on the console
        /// </summary>
        public void print()
        {
            for (int i = 0; i < 9; i++)
            {
                if (i%3 == 0)
                {
                    for (int l = 0; l < 31; l++)
                    {
                        Console.Write('-');
                    }
                    Console.WriteLine();
                }
                for (int j = 0; j < 9; j++)
                {
                    if (j%3 == 0)
                    {
                        Console.Write("|");
                        Console.Write(" ");
                    }

                    if (grid[i,j] != 0) Console.Write(grid[i,j]);
                    else Console.Write(" ");
                    if ((j+1)%3 == 0)
                    {
                        Console.Write(" ");
                    }
                    else
                        Console.Write("  ");
                }
                Console.Write("|");
                Console.WriteLine();
            }
            for (int k = 0; k < 31; k++)
            {
                Console.Write('-');
            }
        }

        /// <summary>
        /// Returns true if the given column is solved
        /// </summary>
        /// <param name="x"> index of the column</param>
        public bool is_column_solved(int x)
        {
            int[] arr = new int[9];
            for (int i = 0; i < 9; i++)
            {
                if (grid[i,x] == 0) return false;
                for (int j = 0; j < i; j++)
                {
                    if (grid[i, x] == arr[j]) return false;
                }
                arr[i] = grid[i, x];
            }
            return true;
        }
        
        /// <summary>
        /// Returns true if the given line is solved
        /// </summary>
        /// <param name="y"> index of the line</param>
        public bool is_line_solved(int y)
        {
            int[] arr = new int[9];
            for (int i = 0; i < 9; i++)
            {
                if (grid[y,i] == 0) return false;
                for (int j = 0; j < i; j++)
                {
                    if (grid[y, i] == arr[j]) return false;
                }
                arr[i] = grid[y, i];
            }
            return true;
        }

        /// <summary>
        /// Returns true if the 3x3 square containing the given coords is solved
        /// </summary>
        /// <param name="x"> index of the column</param>
        /// <param name="y"> index of the line</param>
        public bool is_square_solved(int x, int y)
        {
            int[] arr = new int[9];
            int tmp = x / 3;
            int tmp2 = y / 3;
            x = tmp * 3;
            y = tmp2 * 3;
            int cpt = 0;
            for (int i = x; i < x+3; i++)
            {
                for (int j = y; j < y+3; j++)
                {
                    if (grid[i, j] == 0) return false;
                    for (int k = 0; k < 9; k++)
                    {
                        if (grid[i, j] == arr[k]) return false;
                    }
                    arr[cpt] = grid[i, j];
                    cpt++;
                }
            }
            return true;
        }

        /// <summary>
        /// Returns true the grid is solved
        /// Here is a exemple of a solved grid : 435269781682571493197834562826195347374682915951743628519326874248957136763418259
        /// </summary>
        public bool is_solved()
        {
            for (int i = 0; i < 9; i++)
            {
                if (is_line_solved(i) && is_column_solved(i) == false) return false;
            }

            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (is_square_solved(j*3, k*3) == false) return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Returns true if the given column already contains the given value
        /// </summary>
        /// <param name="x"> index of the column</param>
        /// <param name="val"> value that must be checked</param>
        public bool already_in_column(int x, int val)
        {
            for (int i = 0; i < 9; i++)
            {
                if (grid[i, x] == val) return true;
            }
            return false;
        }
        
        /// <summary>
        /// Returns true if the given line already contains the given value
        /// </summary>
        /// <param name="y"> index of the line</param>
        /// <param name="val"> value that must be checked</param>
        public bool already_in_line(int y, int val)
        {
            for (int i = 0; i < 9; i++)
            {
                if (grid[y, i] == val) return true;
            }

            return false;
        }
        
        /// <summary>
        /// Returns true if the 3x3 square containing the given already contains the given value
        /// </summary>
        /// <param name="x"> index of the column</param>
        /// <param name="y"> index of the line</param>
        /// <param name="val"> value that must be checked</param>
        public bool already_in_square(int x, int y, int val)
        {
            int tmp = x / 3;
            int tmp2 = y / 3;
            x = tmp * 3;
            y = tmp2 * 3;
            for (int i = x; i < x+3; i++)
            {
                for (int j = y; j < y+3; j++)
                {
                    if (grid[i, j] == val) return true;
                    
                }
            }
            return false;
        }
        
        public bool solve_rec(int x, int y)
        {
            if (x == 9 && y == 8) return true; 
            if (x == 9)
            {
                x = 0;
                y += 1;
            }
            if (grid[x, y] != 0) solve_rec(x + 1, y);
            for (int number = 1; number < 10; number++)
            {
                if (already_in_column(x,number) == false && already_in_line(y,number) == false && already_in_square(x,y,number) == false)
                {
                    grid[x, y] = number;
                    solve_rec(x + 1, y);
                }
            }

            throw new NotImplementedException();

        }

        /// <summary>
        /// Solves the grid
        /// </summary>
        public void solve()
        {
            solve_rec(0, 0);
        }
    }
}