using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_2_stack
{
	public class Maze
	{
		public Point StartingPoint { get; set; }
		public int RowLength { get => CharMaze.Length; }
		public int ColumnLength { get => CharMaze[0].Length; }

		private char[][] CharMaze;
		private Stack<Point> path;

		public Maze(string filename)
		{
			string[] fileLines = File.ReadAllLines(filename);

			string[] dimensions = fileLines[0].Split(' ');
			int rows = int.Parse(dimensions[0]);
			int columns = int.Parse(dimensions[1]);

			string[] startPos = fileLines[1].Split(' ');
			int startRow = int.Parse(startPos[0]);
			int startColumn = int.Parse(startPos[1]);

			CharMaze = new char[rows][];

			for (int i = 0; i < rows; i++)
			{
				CharMaze[i] = fileLines[i + 2].ToCharArray();
			}

			StartingPoint = new Point(startRow, startColumn);

			path = new Stack<Point>();
		}

		public Maze(int startingRow, int startingColumn, char[][] existingMaze)
		{
			CharMaze = existingMaze;

			if (CharMaze[startingRow][startingColumn] == 'W' || 
				CharMaze[startingRow][startingColumn] == 'E')
					throw new ApplicationException();

			if (startingColumn >= ColumnLength || startingColumn < 0)
				throw new IndexOutOfRangeException();

			StartingPoint =  new Point(startingRow, startingColumn);

			path = new Stack<Point>();
		}

		public char[][] GetMaze() => CharMaze;

		public string PrintMaze()
		{
			string maze = "";
			for (int r = 0; r < RowLength; r++)
			{
				for (int c = 0; c < ColumnLength; c++)
					maze += CharMaze[r][c];

				if (r < RowLength - 1)
					maze += "\n";
			}
			return maze;
		}

		public string DepthFirstSearch()
		{
			throw new NotImplementedException();
		}

		public Stack<Point> GetPathToFollow()
		{
			throw new ApplicationException();
		}
	}
}
