using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
	class Puzzle
	{

		public event PzValueChangedHandler PzValueChangedEvent;
		public delegate void PzValueChangedHandler(object sender, EventArgs e);

		Group[] m_Cols = new Group[9];

		public Group[] Cols
		{
			get { return m_Cols; }
			set { m_Cols = value; }
		}
		Group[] m_Rows = new Group[9];

		public Group[] Rows
		{
			get { return m_Rows; }
			set { m_Rows = value; }
		}
		Group[] m_Boxes = new Group[9];

		public Group[] Boxes
		{
			get { return m_Boxes; }
			set { m_Boxes = value; }
		}
		
		public Puzzle()
		{
			for (int i = 0; i < 9; i++)
			{
				m_Cols[i] = new Group(i);
				m_Rows[i] = new Group(i);
				m_Boxes[i] = new Group(i);
			}
			for (int iRow = 0; iRow < 9; iRow++)
			{
				Group row = m_Rows[iRow];
				for (int iCol = 0; iCol < 9; iCol++)
				{
					Square sq = new Square();
					sq.SqValueChangedEvent += new Square.SqValueChangedHandler(sq_ValueChangedEvent); 
					sq.Row = row;
					sq.Column = m_Cols[iCol];

					row[iCol] = sq;
					m_Cols[iCol][iRow] = sq;

					int iBox = ((iRow / 3) *3) + (iCol / 3);
					int iBoxIdx = (iRow % 3) * 3 + (iCol % 3);
					m_Boxes[iBox][iBoxIdx] = sq;
					sq.Box = m_Boxes[iBox];
				}
			}
		}

		void sq_ValueChangedEvent(object sender, EventArgs e)
		{
			OnValueChanged((Square)sender);
		}

		private void OnValueChanged(Square square)
		{
			if (PzValueChangedEvent != null)
			{
				PzValueChangedEvent(square, new EventArgs());
			}
		}

		public bool Solve(int iRow, int iCol)
		{
			//System.Diagnostics.Trace.WriteLine(string.Format("{0}, {1}", iRow, iCol));
			//PrintGrid();
			Square sq = Rows[iRow][iCol];
			// First check if it has a valueRows
			if (sq.Value != 0)
			{
				if ((iRow == 8) && (iCol == 8))
				{
					// Last item. Solved it!
					return true;
				}
				int tempCol = iCol;
				int tempRow = iRow;
				tempCol++;
				if (tempCol == 9)
				{
					tempCol = 0;
					tempRow++;
				}
				if (Solve(tempRow, tempCol))
				{
					return true;
				}

			}
			else
			{
				for (int i = 0; i < 9; i++)
				{
					if (sq.CanBe(i+1))
					{
						if ((iRow == 8) && (iCol == 8))
						{
							// Last item. Solved it!
							sq.Value = i + 1;
							return true;							
						}
						else
						{
							sq.Value = i+1;
							int tempCol = iCol;
							int tempRow = iRow;
							tempCol++;
							if (tempCol == 9)
							{
								tempCol = 0;
								tempRow++;
							}
							if (Solve(tempRow, tempCol))
							{
								return true;
							}
							
						}

					}
					sq.Value = 0;
				}
			}

			return false;


		}

		public bool NewSolve()
		{
			// Find the next group to solve for
			Group solveGroup = GetNextGroup();
			if (solveGroup == null)
			{
				// We couldn't find a group with any empty squares. We have solved it.
				return true;
			}
			Square solveSquare = null;
			// Find the first empty square in the group
			foreach (Square sq in solveGroup.Squares)
			{
				if (sq.Value == 0)
				{
					solveSquare = sq;
					break;
				}
			}

			if (solveSquare == null)
			{
				// Shouldn't be here, so stop trying and pretend like success
				return true;
			}
			// Now test the numbers for this square
			for (int i = 1; i <= 9; i++)
			{
				if (solveSquare.CanBe(i))
				{
					solveSquare.Value = i;
					bool result = NewSolve();
					if (result)
					{
						return true;
					}
				}
			}
			// If we got here, then we didn't solve it. Bump your way back up
			solveSquare.Value = 0;
			return false;
		}

		private Group GetNextGroup()
		{
			Group nextGroup = null;
			nextGroup = SearchGroup(nextGroup, m_Cols);
			if (nextGroup == null || nextGroup.EmptySquares != 1)
			{
				nextGroup = SearchGroup(nextGroup, m_Rows);
			}
			if (nextGroup == null || nextGroup.EmptySquares != 1)
			{
				nextGroup = SearchGroup(nextGroup, m_Boxes);
			}
			return nextGroup;
		}

		private static Group SearchGroup(Group nextGroup, Group[] searchGroup)
		{
			foreach (Group g in searchGroup)
			{
				if (g.EmptySquares == 0)
				{
					continue;
				}
				if (g.EmptySquares == 1)
				{
					nextGroup = g;
					break;
				}
				if (nextGroup == null || g.EmptySquares < nextGroup.EmptySquares)
				{
					nextGroup = g;
				}
			}
			return nextGroup;
		}

		private void PrintGrid()
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					sb.Append(Rows[i][j].Value.ToString() + " ");
				}
				sb.Append("\r\n");
			}
			sb.Append("--------------\r\n");
			System.Diagnostics.Trace.Write(sb);
		}

	}
}
