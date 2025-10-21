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
			SetChar('V');
			bool exit = false;

			while (!Path.IsEmpty() || exit == false)
			{	
	
				//Check left
				if (IsSpace(InspectLocation(0, -1)))
				{
					Path.Push(new Point(Path.Top().Row, Path.Top().Column - 1));
					SetChar('V');
				}

				//Check right
				else if (IsSpace(InspectLocation(0, 1)))
				{
					Path.Push(new Point(Path.Top().Row, Path.Top().Column + 1));
					SetChar('V');
				}

				//Check down
				else if (IsSpace(InspectLocation(1, 0)))
				{
					Path.Push(new Point(Path.Top().Row + 1, Path.Top().Column));
					SetChar('V');
				}

				//Check up
				else if (IsSpace(InspectLocation(-1, 0)))
				{
					Path.Push(new Point(Path.Top().Row - 1, Path.Top().Column));
					SetChar('V');
				}

				else 
					Path.Pop();
			}
			
			return PrintMaze();
		}

		public Stack<Point> GetPathToFollow()
		{
			throw new ApplicationException();
		}

		private char InspectLocation(int rowModifier, int columnModifier)
		{	
			if (rowModifier != 0 && 1 == Math.Abs(rowModifier))
			{
				return CharMaze[Path.Top().Row + rowModifier][Path.Top().Column];
			}

			if (columnModifier != 0 && 1 == Math.Abs(columnModifier))
			{
				return CharMaze[Path.Top().Row][Path.Top().Column + columnModifier];
			}

			else
				throw new ApplicationException();
		}

		//Returns true if param is a ' '
		private static bool IsSpace(char target) => target == ' ';

		//Sets the char at a given position to a specific char
		private void SetChar(char character)
		{
			CharMaze[Path.Top().Row][Path.Top().Column] = character;
		}
	}
}
