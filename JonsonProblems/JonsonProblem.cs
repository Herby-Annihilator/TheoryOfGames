using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryOfGames.JonsonProblems
{
	public abstract class JonsonProblem
	{
		protected double[][] processingTimes;
		public abstract Answer GetAnswer();
		internal JonsonProblem(double[][] matrix)
		{
			processingTimes = CloneMatrix(matrix);
		}
		protected double[][] CloneMatrix(double[][] matr)
		{
			double[][] arr = new double[matr.GetLength(0)][];
			for (int i = 0; i < arr.GetLength(0); i++)
			{
				arr[i] = new double[matr[i].Length];
				for (int j = 0; j < arr[i].Length; j++)
				{
					arr[i][j] = matr[i][j];
				}
			}
			return arr;
		}
	}
}
