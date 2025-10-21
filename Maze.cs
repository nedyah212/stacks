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
		private Stack<Point> Path;

		private string TestMessage = "No exit found in maze!\n\n";
		private bool ExitStatus = false;

		public Maze(string filename)
		{
			string[] fileLines = File.ReadAllLines(filename);

			string[] dimensions = fileLines[0].Split(' ');
			int rows = int.Parse(dimensions[0]);

			string[] startPosition = fileLines[1].Split(' ');
			int startRow = int.Parse(startPosition[0]);
			int startColumn = int.Parse(startPosition[1]);

			CharMaze = new char[rows][];

			for (int i = 0; i < RowLength; i++)
			{
				CharMaze[i] = fileLines[i + 2].ToCharArray();
			}

			StartingPoint = new Point(startRow, startColumn);
			Path = new Stack<Point>();
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
			Path = new Stack<Point>();
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
			Point currentPosition = StartingPoint;
			Path.Push(currentPosition);
			CharMaze[Path.Top().Row][Path.Top().Column] = 'V';
			Stack<Point> copyPath = new Stack<Point>();
			while (!Path.IsEmpty())
			{
				//Check down
				if (IsSpace(GetChar(1, 0)) || IsExit(GetChar(1, 0)))
					InspectLocation(1, 0);
				//Check right
				else if (IsSpace(GetChar(0, 1)) || IsExit(GetChar(0, 1)))
					InspectLocation(0, 1);
				//Check left
				else if (IsSpace(GetChar(0, -1)) || IsExit(GetChar(0, -1)))
					InspectLocation(0, -1);
				//Check up
				else if (IsSpace(GetChar(-1, 0)) || IsExit(GetChar(-1, 0)))
					InspectLocation(-1, 0);
				else
					Path.Pop();

				if (ExitStatus == true)
				{
					int pathSize = Path.Size;
					Point point;
					TestMessage = ($"Path to follow from Start {StartingPoint.ToString()} to Exit {Path.Top()} - 27 steps:\n");

					for (int i = 0; i < pathSize; i++)
					{
						point = Path.Pop();
						copyPath.Push(point);
						CharMaze[point.Row][point.Column] = '.';
					}

					for (int i = 0; i < pathSize; i++)
					{
						point = copyPath.Pop();
						TestMessage += $"{point.ToString()}\n";
					}
				}
			}

			Path = copyPath;

			return $"{TestMessage}{PrintMaze()}";
		}

		public Stack<Point> GetPathToFollow()
		{
			throw new ApplicationException();
		}

		private static bool IsSpace(char target) => target == ' ';
		private bool IsExit(char target) => ExitStatus = target == 'E';

		private char GetChar(int rowModifier, int columnModifier)
		{
			char character = '_';
			if (rowModifier != 0 && 1 == Math.Abs(rowModifier))
				 character = CharMaze[Path.Top().Row + rowModifier][Path.Top().Column];

			else if (columnModifier != 0 && 1 == Math.Abs(columnModifier))
				character = CharMaze[Path.Top().Row][Path.Top().Column + columnModifier];

			return character;
		}
		
		private void InspectLocation(int rowModifier, int columnModifier)
		{
			Path.Push(new Point(Path.Top().Row + (rowModifier), Path.Top().Column + (columnModifier)));
			CharMaze[Path.Top().Row][Path.Top().Column] = 'V';
		}
	}
}
