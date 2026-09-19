using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
	class ValueChangedEventArgs : EventArgs
	{
		public ValueChangedEventArgs(int iRow, int iCol)
		{
			rowNum = iRow;
			colNum = iCol;
		}
		private int rowNum;

		public int RowNum
		{
			get
			{
				return rowNum;
			}
		}
		private int colNum;

		public int ColNum
		{
			get
			{
				return colNum;
			}
		}
	}
}
