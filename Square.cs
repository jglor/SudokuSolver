using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{


	class Square
	{

		public event SqValueChangedHandler SqValueChangedEvent;
		public delegate void SqValueChangedHandler(object sender, EventArgs e);

		int m_value;

		public int Value
		{
			get
			{
				return m_value;
			}
			set
			{
				if (m_value != 0)
				{
					m_Row.Remove(m_value);
					m_Column.Remove(m_value);
					m_Box.Remove(m_value);
				}

				if (value != 0)
				{
					m_Row.Add(value);
					m_Column.Add(value);
					m_Box.Add(value);
				}
				m_value = value;
				OnValueChanged();
			}
		}

		private void OnValueChanged()
		{
			if (SqValueChangedEvent != null)
			{
				SqValueChangedEvent(this, new EventArgs());
			}
		}

		public int ColNum
		{
			get
			{
				return m_Column.Number;
			}
		}

		public int RowNum
		{
			get
			{
				return m_Row.Number;
			}
		}

		Group m_Row;
		Group m_Column;
		Group m_Box;

		public Group Row
		{
			get 
			{
				return m_Row; 
			}
			set
			{
				m_Row = value; 
			}
		}

		public Group Column
		{
			get
			{
				return m_Column; 
			}
			set
			{ 
				m_Column = value; 
			}
		}

		public Group Box
		{
			get
			{
				return m_Box;
			}
			set
			{
				m_Box = value;
			}
		}

		public Square()
		{
			m_value = 0;
		}

		public bool CanBe(int iVal)
		{
			//if (Array.IndexOf(m_Row.Squares, iVal) != -1)
			//{
			//    return false;
			//}
			//if (Array.IndexOf(m_Column.Squares, iVal) != -1)
			//{
			//    return false;
			//}
			//if (Array.IndexOf(m_Box.Squares, iVal) != -1)
			//{
			//    return false;
			//}
			if (m_Row.Contains(iVal))
			{
				return false;
			}
			if (m_Column.Contains(iVal))
			{
				return false;
			}
			if (m_Box.Contains(iVal))
			{
				return false;
			}

			return true;

		}

		public override bool Equals(object obj)
		{
			if (obj is Square)
			{
				return ((Square)obj).Value == m_value;
			}
			if (obj is int)
			{
				return (int)obj == m_value;
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return m_value;
		}

		public override string ToString()
		{
			return m_value.ToString();
		}

		

	}
}
