using System;
using System.IO;
using System.Linq;
 
namespace sudokuSolver
{
	class Program
	{
		static void Main(String[] args)
		{
			int[][] Puzzle = new int[][]
			{
					new int[9] { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
					new int[9] { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
					new int[9] { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
					new int[9] { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
					new int[9] { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
					new int[9] { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
					new int[9] { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
					new int[9] { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
					new int[9] { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
			};

			int[][] Puzzle2 = new int[][]
			{
					new int[9] {8,0,0,0,0,0,0,0,0 },
					new int[9] {0,0,3,6,0,0,0,0,0 },
					new int[9] {0,7,0,0,9,0,2,0,0 },
					new int[9] {0,5,0,0,0,7,0,0,0 },
					new int[9] {0,0,0,0,4,5,7,0,0 },
					new int[9] {0,0,0,1,0,0,0,3,0 },
					new int[9] {0,0,1,0,0,0,0,6,8 },
					new int[9] {0,0,8,5,0,0,0,1,0 },
					new int[9] {0,9,0,0,0,0,4,0,0 }
			};

			/*
			if (SolveSudoku(Puzzle))
			{
				PrintSolution(Puzzle);
			}
			*/

			int[][] megaPuzzle = Solve(Puzzle2);

			PrintSolution(megaPuzzle);
		}

		static public int[][] Solve(int[][] sudoku)		// The method in question
		{
			int[][] puzzle = sudoku;

			SolveSudoku(puzzle);
			return puzzle;
		}

		static bool SolveSudoku(int[][] board)
		{
			int row = -1;
			int col = -1;
			bool isEmpty = true;

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					if (board[i][j] == 0)
					{
						row = i;
						col = j;

						isEmpty = false;
						break;
					}

					if (!isEmpty)
						break;
				}
			}

			if (isEmpty) // no 0's left
				return true;

			for (int num = 1; num <= 9; num++)
			{
				if (IsSafe(board, row, col, num))
				{
					board[row][col] = num;

					if (SolveSudoku(board))
						return true;
					else
					board[row][col] = 0;
				}
			}

			return false;
		}

		static bool IsSafe(int[][] board, int row, int col, int num)
		{
			for (int i = 0; i < 9; i++)
				if (board[row][i] == num || board[i][col] == num)
					return false;

			int rStart = row - row % 3;
			int cStart = col - col % 3;

			for (int i = rStart; i < rStart + 3; i++)
				for (int j = cStart; j < cStart + 3; j++)
					if (board[i][j] == num)
						return false;

			return true;
		}
	 
	 
		static void PrintSolution(int[][] board)
		{
			for (int i = 0; i < 9; i++)
			{
				if (i % 3 == 0 && i != 0)
					Console.Write("\n");

				Console.Write('\t');

				for(int j = 0; j < 9; j++)
				{
					if (j % 3 == 0 && j != 0)
						Console.Write('\t');

					Console.Write($"{board[i][j]} ");
				}

				Console.WriteLine();
			}
		}
	}
}
