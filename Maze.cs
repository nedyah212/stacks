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
		public int RowLength { get; }
		public int ColumnLength { get; }

		private char[][] CharMaze;
		private Stack<Point> path;

		public Maze(string filename)
		{
			throw new NotImplementedException();
		}

		public Maze(int startingRow, int startingColumn, char[][] existingMaze)
		{
			CharMaze = existingMaze;
			StartingPoint =  new Point(startingRow, startingColumn);
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
			throw new NotImplementedException();
		}
	}
}
