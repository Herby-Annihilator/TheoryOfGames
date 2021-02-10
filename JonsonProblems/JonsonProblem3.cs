using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryOfGames.JonsonProblems
{
	public class JonsonProblem3 : JonsonProblem2
	{
		public override Answer GetAnswer()
		{
			throw new NotImplementedException();
		}
		protected override int[] GetOptimalSequence()
		{
			if (IsMatrixCorrect())
			{
				PrepareProcessingMatrix();
				return base.GetOptimalSequence();
			}
			else
			{
				throw new NotSupportedException("Матрица некорректна для данной задачи");
			}
		}
		private bool IsMatrixCorrect()
		{
			for (int i = 0; i < processingTimes.GetLength(0); i++)
			{
				if (processingTimes[i].Length != 3)
				{
					return false;
				}
			}
			return true;
		}
		private void PrepareProcessingMatrix()
		{
			double[] sums = new double[processingTimes.GetLength(0)];
			if (FindMinInsideCol(0) >= FindMaxInsideCol(1) || FindMinInsideCol(2) >= FindMaxInsideCol(1))
			{

			}
			else
			{
				throw new Exception("Решение не может быть найдено");
			}
		}
		private double FindMinInsideCol(int col)
		{
			double min = processingTimes[0][col];
			for (int i = 1; i < processingTimes.GetLength(0); i++)
			{
				if (processingTimes[i][col] < min)
				{
					min = processingTimes[i][col];
				}
			}
			return min;
		}
		private double FindMaxInsideCol(int col)
		{
			double max = processingTimes[0][col];
			for (int i = 1; i < processingTimes.GetLength(0); i++)
			{
				if (processingTimes[i][col] > max)
				{
					max = processingTimes[i][col];
				}
			}
			return max;
		}
		internal JonsonProblem3(double[][] matrix) : base(matrix)
		{

		}
	}
}
