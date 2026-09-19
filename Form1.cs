using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SudokuSolver
{
	public partial class SudokuForm : Form
	{
		//Puzzle m_Puzzle;
		public SudokuForm()
		{
			InitializeComponent();
			//SetupPuzzle();
			SetupGrid();

			//ValueChangedEvent += new ValueChangedHandler(Form1_ValueChangedEvent);
		}

		void Form1_ValueChangedEvent(object sender, EventArgs e)
		{

		}

		private void SetupGrid()
		{
			#region Grid Setup
			PuzzleGrid[0, 0] = t11;
			PuzzleGrid[0, 1] = t12;
			PuzzleGrid[0, 2] = t13;
			PuzzleGrid[0, 3] = t14;
			PuzzleGrid[0, 4] = t15;
			PuzzleGrid[0, 5] = t16;
			PuzzleGrid[0, 6] = t17;
			PuzzleGrid[0, 7] = t18;
			PuzzleGrid[0, 8] = t19;

			PuzzleGrid[1, 0] = t21;
			PuzzleGrid[1, 1] = t22;
			PuzzleGrid[1, 2] = t23;
			PuzzleGrid[1, 3] = t24;
			PuzzleGrid[1, 4] = t25;
			PuzzleGrid[1, 5] = t26;
			PuzzleGrid[1, 6] = t27;
			PuzzleGrid[1, 7] = t28;
			PuzzleGrid[1, 8] = t29;

			PuzzleGrid[2, 0] = t31;
			PuzzleGrid[2, 1] = t32;
			PuzzleGrid[2, 2] = t33;
			PuzzleGrid[2, 3] = t34;
			PuzzleGrid[2, 4] = t35;
			PuzzleGrid[2, 5] = t36;
			PuzzleGrid[2, 6] = t37;
			PuzzleGrid[2, 7] = t38;
			PuzzleGrid[2, 8] = t39;

			PuzzleGrid[3, 0] = t41;
			PuzzleGrid[3, 1] = t42;
			PuzzleGrid[3, 2] = t43;
			PuzzleGrid[3, 3] = t44;
			PuzzleGrid[3, 4] = t45;
			PuzzleGrid[3, 5] = t46;
			PuzzleGrid[3, 6] = t47;
			PuzzleGrid[3, 7] = t48;
			PuzzleGrid[3, 8] = t49;

			PuzzleGrid[4, 0] = t51;
			PuzzleGrid[4, 1] = t52;
			PuzzleGrid[4, 2] = t53;
			PuzzleGrid[4, 3] = t54;
			PuzzleGrid[4, 4] = t55;
			PuzzleGrid[4, 5] = t56;
			PuzzleGrid[4, 6] = t57;
			PuzzleGrid[4, 7] = t58;
			PuzzleGrid[4, 8] = t59;

			PuzzleGrid[5, 0] = t61;
			PuzzleGrid[5, 1] = t62;
			PuzzleGrid[5, 2] = t63;
			PuzzleGrid[5, 3] = t64;
			PuzzleGrid[5, 4] = t65;
			PuzzleGrid[5, 5] = t66;
			PuzzleGrid[5, 6] = t67;
			PuzzleGrid[5, 7] = t68;
			PuzzleGrid[5, 8] = t69;

			PuzzleGrid[6, 0] = t71;
			PuzzleGrid[6, 1] = t72;
			PuzzleGrid[6, 2] = t73;
			PuzzleGrid[6, 3] = t74;
			PuzzleGrid[6, 4] = t75;
			PuzzleGrid[6, 5] = t76;
			PuzzleGrid[6, 6] = t77;
			PuzzleGrid[6, 7] = t78;
			PuzzleGrid[6, 8] = t79;

			PuzzleGrid[7, 0] = t81;
			PuzzleGrid[7, 1] = t82;
			PuzzleGrid[7, 2] = t83;
			PuzzleGrid[7, 3] = t84;
			PuzzleGrid[7, 4] = t85;
			PuzzleGrid[7, 5] = t86;
			PuzzleGrid[7, 6] = t87;
			PuzzleGrid[7, 7] = t88;
			PuzzleGrid[7, 8] = t89;

			PuzzleGrid[8, 0] = t91;
			PuzzleGrid[8, 1] = t92;
			PuzzleGrid[8, 2] = t93;
			PuzzleGrid[8, 3] = t94;
			PuzzleGrid[8, 4] = t95;
			PuzzleGrid[8, 5] = t96;
			PuzzleGrid[8, 6] = t97;
			PuzzleGrid[8, 7] = t98;
			PuzzleGrid[8, 8] = t99;

			#endregion
		}

		TextBox[,] PuzzleGrid = new TextBox[9,9];

		private void SolveButton_Click(object sender, EventArgs e)
		{
			Puzzle m_Puzzle = new Puzzle();
			m_Puzzle.PzValueChangedEvent += new Puzzle.PzValueChangedHandler(m_Puzzle_PzValueChangedEvent);
			for (int row = 0; row < 9; row++)
			{
				for (int col = 0; col < 9; col++)
				{
					int val = 0;
					if (PuzzleGrid[row, col].Text.Length > 0)
					{
						try
						{
							val = Convert.ToInt32(PuzzleGrid[row, col].Text);
						}
						catch (Exception)
						{
						}
					}
					m_Puzzle.Rows[row][col].Value = val;
				}
			}
			DateTime start = DateTime.Now;
			//if (m_Puzzle.Solve(0, 0) == true)
			if (m_Puzzle.NewSolve() == true)
			{
				DateTime done = DateTime.Now;
				TimeSpan span = done - start;
				string res = string.Format("I did it in {0}", span);
				MessageBox.Show(res);
				for (int row = 0; row < 9; row++)
				{
					for (int col = 0; col < 9; col++)
					{
						PuzzleGrid[row, col].Text = m_Puzzle.Rows[row][col].ToString();
					}
				}

			}
			else
			{
				MessageBox.Show("I failed!!!");
			}
		}

		void m_Puzzle_PzValueChangedEvent(object sender, EventArgs e)
		{
			Square sq = (Square)sender;
			string text = sq.ToString();
			if (text.CompareTo("0") == 0)
			{
				text = "";
			}
			PuzzleGrid[sq.RowNum, sq.ColNum].Text = text;
			Application.DoEvents();
		}

		private void ClearButton_Click(object sender, EventArgs e)
		{
			for (int row = 0; row < 9; row++)
			{
				for (int col = 0; col < 9; col++)
				{
					PuzzleGrid[row, col].Text = "";
				}
			}
		}


	}
}