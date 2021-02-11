using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryOfGames.JonsonProblems
{
	public class JonsonProblem3 : JonsonProblem2
	{
		private double[][] passedMatrix;
		public override Answer GetAnswer()
		{
			int[] sequence = GetOptimalSequence();
			double[] machineCDowntimeForEachDetails = new double[sequence.Length];
			int detail;
			Answer answer = base.GetAnswer();
			double totalMachineBDowntime = 0;
			double totalMachineBProcessTime = 0;
			double totalMachineCDowntime = 0;
			double totalMachineCProcessTime = 0;
			for (int i = 0; i < sequence.Length; i++)
			{
				detail = sequence[i];
				totalMachineBDowntime += answer.BDowntimeForEachDetail[detail];
				totalMachineBProcessTime += processingTimes[detail][1];
				machineCDowntimeForEachDetails[detail] = totalMachineBDowntime + totalMachineBProcessTime -
					totalMachineCDowntime - totalMachineCProcessTime;
				if (machineCDowntimeForEachDetails[detail] < 0)
				{
					machineCDowntimeForEachDetails[detail] = 0;
				}
				totalMachineCDowntime += machineCDowntimeForEachDetails[detail];
				totalMachineCProcessTime += processingTimes[detail][2];
			}
			answer.OptimalSequence = sequence;
			answer.CDowntimeForEachDetail = (double[])machineCDowntimeForEachDetails.Clone();
			answer.TotalCDowntimeForEachDetail = totalMachineCDowntime;
			answer.TotalTimeOfAllProductProcess = totalMachineCDowntime + totalMachineCProcessTime;
			return answer;
		}
		protected override int[] GetOptimalSequence()
		{
			if (IsMatrixCorrect())
			{
				PrepareProcessingMatrix();
				int[] sequence = base.GetOptimalSequence();
				processingTimes = CloneMatrix(passedMatrix);
				return sequence;
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
			double[] sums;
			if (FindMinInsideCol(0) >= FindMaxInsideCol(1) || FindMinInsideCol(2) >= FindMaxInsideCol(1))
			{
				sums = GetColsSum(0, 1);
				CloneVectorIntoCol(sums, 0);
				sums = GetColsSum(1, 2);
				CloneVectorIntoCol(sums, 1);
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
		private double[] GetColsSum(int firstColIndex, int secondColIndex)
		{
			double[] sum = new double[processingTimes.GetLength(0)];
			for (int i = 0; i < sum.Length; i++)
			{
				sum[i] = processingTimes[i][firstColIndex] + processingTimes[i][secondColIndex];
			}
			return sum;
		}
		private void CloneVectorIntoCol(double[] vector, int col)
		{
			for (int i = 0; i < vector.Length; i++)
			{
				processingTimes[i][col] = vector[i];
			}
		}
		internal JonsonProblem3(double[][] matrix) : base(matrix)
		{
			passedMatrix = CloneMatrix(matrix);
		}
	}
}
