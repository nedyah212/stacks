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
			
		}

		public Maze(int startingRow, int startingColumn, char[][] existingMaze)
		{
			CharMaze = existingMaze;

			if (CharMaze[startingRow][startingColumn] == 'W' || CharMaze[startingRow][startingColumn] == 'E')
				throw new ApplicationException();
			
			StartingPoint =  new Point(startingRow, startingColumn);

			if (startingColumn >= ColumnLength || startingColumn < 0)
				throw new IndexOutOfRangeException();

			path = new Stack<Point>();
		}

		public char[][] GetMaze() => CharMaze;

		public string PrintMaze()
		{
			throw new NotImplementedException();
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
