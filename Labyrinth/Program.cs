using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
	class Program
	{
		static List<List<int>> Paths = new List<List<int>>();

		static char[,] lab =
		{
			{'S', ' ', ' ', '*', ' ', ' ', ' '},
			{'*', '*', ' ', '*', ' ', '*', ' '},
			{' ', ' ', ' ', ' ', ' ', ' ', ' '},
			{' ', '*', '*', '*', '*', '*', ' '},
			{' ', ' ', ' ', ' ', ' ', ' ', 'e'},
		};

		static void Main(string[] args)
		{
			var path = new List<string>();
			FindPath(0, 0);
		}

		static void FindPath(int row, int col)
		{

			//End condition;
			if (lab[row, col] == 'e')
			{
				Console.WriteLine("Path Found");
				return;
			}
				
			
			List<int[]> nextPossibleLocations = GetNextPossibleLocations(row,col);

			//Return if No further route possible.
			if (nextPossibleLocations == null || nextPossibleLocations.Count == 0)
				return;

			// Mark Visited.
			lab[row, col] = 'V';
			foreach (var nextLocation in nextPossibleLocations)
			{
				FindPath(nextLocation[0], nextLocation[1]);
			}

			// Mark Unvisited for next route search.
			lab[row, col] = ' ';
		}

		private static List<int[]> GetNextPossibleLocations(int row, int col)
		{
			List<int[]> returnList = new List<int[]>();
			if (MoveUpPossible(row, col)) returnList.Add(new int[] { row - 1, col });
			if (MoveDownPossible(row, col)) returnList.Add(new int[] { row + 1, col });
			if (MoveLeftPossible(row, col)) returnList.Add(new int[] { row, col - 1 });
			if (MoveRightPossible(row, col)) returnList.Add(new int[] { row, col + 1 });
			return returnList;
		}

		private static bool MoveUpPossible(int row, int col)
		{
			row = row - 1;
			return !(IsCellInvalid(row, col) || IsImpeccableCell(row, col));
		}
		private static bool MoveDownPossible(int row, int col)
		{
			row = row + 1;
			return !(IsCellInvalid(row, col) || IsImpeccableCell(row, col));
		}
		private static bool MoveLeftPossible(int row, int col)
		{
			col = col - 1;
			return !(IsCellInvalid(row, col) || IsImpeccableCell(row, col));
		}
		private static bool MoveRightPossible(int row, int col)
		{
			col = col + 1;
			return !(IsCellInvalid(row, col) || IsImpeccableCell(row, col));
		}

		private static bool IsCellInvalid(int row, int col)
		{
			return (row < 0 || row >= lab.GetLength(0) ||
					col < 0 || col >= lab.GetLength(1));
		}
		private static bool IsImpeccableCell(int row, int col)
		{
			return (lab[row, col] == '*' || lab[row, col] == 'V') ;
		}
	}
}
