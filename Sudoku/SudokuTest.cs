using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuTest
{
    class SudokuPuzzleValidator
    {
        static void Main(string[] args)
        {
            int[][] goodSudoku1 = {
                new int[] {7,8,4,  1,5,9,  3,2,6},
                new int[] {5,3,9,  6,7,2,  8,4,1},
                new int[] {6,1,2,  4,3,8,  7,5,9},

                new int[] {9,2,8,  7,1,5,  4,6,3},
                new int[] {3,5,7,  8,4,6,  1,9,2},
                new int[] {4,6,1,  9,2,3,  5,8,7},

                new int[] {8,7,6,  3,9,4,  2,1,5},
                new int[] {2,4,3,  5,6,1,  9,7,8},
                new int[] {1,9,5,  2,8,7,  6,3,4}
            };


            int[][] goodSudoku2 = {
                new int[] {1,4, 2,3},
                new int[] {3,2, 4,1},

                new int[] {4,1, 3,2},
                new int[] {2,3, 1,4}
            };

            int[][] badSudoku1 =  {
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9}
            };

            int[][] badSudoku2 = {
                new int[] {1,2,3,4,5},
                new int[] {1,2,3,4},
                new int[] {1,2,3,4},  
                new int[] {1}
            };

            Debug.Assert(valid_board(goodSudoku1), "This is supposed to validate! It's a good sudoku!");
            Debug.Assert(valid_board(goodSudoku2), "This is supposed to validate! It's a good sudoku!");
            Debug.Assert(!valid_board(badSudoku1), "This isn't supposed to validate! It's a bad sudoku!");
            Debug.Assert(!valid_board(badSudoku2), "This isn't supposed to validate! It's a bad sudoku!");
        } 
        
	// Function to check if a given row is valid. It will return:
	// -1 if the row contains an invalid value
	// 0 if the row contains repeated values
	// 1 is the row is valid.
	public static int valid_row(int row, int[][] grid)
	{
	  SortedSet<int> s = new SortedSet<int>();
	  int size_col = grid.GetLength(1);
	  for (int i = 0; i < size_col; i++)
	  {
		// Checking for values outside 0 and 9; 
		// 0 is considered valid because it 
		// denotes an empty cell.
		// Removing zeros and the checking for values and
		// outside 1 and 9 is another way of doing 
		// the same thing.
		if (grid[row][i] < 0 || grid[row][i] > 9)
		{
		  Console.Write("Invalid value");
		  Console.Write("\n");
		  return -1;
		}
		else
		{ //Checking for repeated values.
		  if (grid[row][i] != 0)
		  {
			if (s.Add(grid[row][i]).second == false)
			{
			  return 0;
			}
		  }
		}
	  }
	  return 1;
	}
	// Function to check if a given column is valid. It will return:
	// -1 if the column contains an invalid value
	// 0 if the column contains repeated values
	// 1 is the column is valid.
	public static int valid_col(int col, int[][] grid)
	{
	  SortedSet<int> s = new SortedSet<int>();
	  int size_row = grid.GetLength(0);
	  for (int i = 0; i < size_row; i++)
	  {
		// Checking for values outside 0 and 9; 
		// 0 is considered valid because it 
		// denotes an empty cell.
		// Removing zeros and the checking for values and
		// outside 1 and 9 is another way of doing 
		// the same thing.
		if (grid[i][col] < 0 || grid[i][col] > 9)
		{
		  Console.Write("Invalid value");
		  Console.Write("\n");
		  return -1;
		}
		else
		{ // Checking for repeated values.
		  if (grid[i][col] != 0)
		  {
			if (s.Add(grid[i][col]).second == false)
			{
			  return 0;
			}
		  }
		}
	  }
	  return 1;
	}
	// Function to check if all the subsquares are valid. It will return:
	// -1 if a subsquare contains an invalid value
	// 0 if a subsquare contains repeated values
	// 1 if the subsquares are valid.
	public static int valid_subsquares(int[][] grid)
	{
		int size_0 = grid.GetLength(0);
		int size_1 = grid.GetLength(1);
		for (int row = 0; row < size_0; row = row + 3)
	  {
		for (int col = 0; col < size_1; col = col + 3)
		{
			SortedSet<int> s = new SortedSet<int>();
			for (int r = row; r < row + 3; r++)
			{
			  for (int c = col; c < col + 3; c++)
			  {
				// Checking for values outside 0 and 9; 
				// 0 is considered valid because it 
				// denotes an empty cell.
				// Removing zeros and the checking for values and
				// outside 1 and 9 is another way of doing 
				// the same thing.
				if (grid[r][c] < 0 || grid[r][c] > 9)
				{
				  Console.Write("Invalid value");
				  Console.Write("\n");
				  return -1;
				}
				else
				{
				  // Checking for repeated values
				  if (grid[r][c] != 0)
				  {
					if (s.Add(grid[r][c]).second == false)
					{
					  return 0;
					}
				  }
				}
			  }
			}
		}
	  }
	  return 1;
	}
	//Function to check if the board invalid.
	public static bool valid_board(int[][] grid)
	{
		int size_row = grid.GetLength(0);
		for (int i = 0; i < size_row; i++)
	  {
		int res1 = valid_row(i, grid);
		int res2 = valid_col(i, grid);
		// If a row or a column is invalid, then the board is invalid.
		if (res1 < 1 || res2 < 1)
		{
			return false;
		}
	  }
	  // if any one the subsquares is invalid, then the board is invalid.
	  int res3 = valid_subsquares(grid);
	  if (res3 < 1)
	  {
		  return false;
	  }
	  else
	  {
		  return true;
	  }
	}
    }
}