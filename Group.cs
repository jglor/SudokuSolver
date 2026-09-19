using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SudokuSolver
{
	class Group
	{
		private int m_Number;
		private Square[] m_squares = new Square[9];
		private uint m_Contents = 0;
		private int m_EmptySquares = 9;

		public Group(int number)
		{
			m_Number = number;
		}

		public Square[] Squares
		{
			get 
			{ 
				return m_squares; 
			}
		}

		public Square this[int index]
		{
			get
			{
				return m_squares[index];
			}
			set
			{
				m_squares[index] = value;
			}
		}

		public int Number
		{
			get
			{
				return m_Number;
			}
			//set
			//{
			//    m_Number = value;
			//}
		}

		public uint Contents
		{
			get
			{
				return m_Contents;
			}
			set
			{
				m_Contents = value;
			}
		}

		public int EmptySquares
		{
			get
			{
				return m_EmptySquares;
			}
		}

		public bool Contains(int value)
		{
			return ((m_Contents & (1 << value)) != 0);
		}

		public void Add(int value)
		{
			m_Contents |= (uint)(1 << value);
			m_EmptySquares--;
		}

		public void Remove(int value)
		{
			m_Contents &= (uint)(~((1 << value)));
			m_EmptySquares++;
		}

	}
}
