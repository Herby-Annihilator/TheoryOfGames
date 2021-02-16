using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryOfGames.JonsonProblems
{
	public class JonsonProblem2 : JonsonProblem
	{
		bool[] visited;
		public override Answer GetAnswer()
		{
			Answer answer = new Answer();
			int[] optimalSequence = GetOptimalSequence();
			int detail;
			double[] detailsWaitTime = new double[optimalSequence.Length];
			double[] bDowntimes = new double[optimalSequence.Length];
			double totalTimeA = 0;
			double totalTimeB = 0;
			double totalDowntime = 0;
			double currentDownTime;
			for (int i = 0; i < optimalSequence.Length; i++)
			{
				detail = optimalSequence[i];
				totalTimeA += processingTimes[detail][0];
				currentDownTime = totalTimeA - totalTimeB - totalDowntime;
				if (currentDownTime < 0)
				{
					detailsWaitTime[detail] = currentDownTime * (-1);
					currentDownTime = 0;
				}
				else
				{
					bDowntimes[detail] = currentDownTime;
				}
				totalDowntime += currentDownTime;
				totalTimeB += processingTimes[detail][1];
			}
			FillAnswer(answer, optimalSequence, bDowntimes, detailsWaitTime, totalTimeB);
			return answer;
		}
		protected virtual int[] GetOptimalSequence()
		{
			visited = new bool[processingTimes.GetLength(0)];
			int[] optimalSequence = new int[processingTimes.GetLength(0)];
			int head = 0;
			int tail = optimalSequence.Length - 1;
			int detail;
			for (int i = 0; i < processingTimes.GetLength(0); i++)
			{
				detail = FindDetailWithMinProcessTime();
				if (detail > -1)
				{
					visited[detail] = true;
					if (processingTimes[detail][0] <= processingTimes[detail][1])
					{
						optimalSequence[head] = detail;
						head++;
					}
					else
					{
						optimalSequence[tail] = detail;
						tail--;
					}
				}				
			}
			return optimalSequence;
		}
		private int FindDetailWithMinProcessTime()
		{
			int detail = FindFirstUnvisitedDetail();
			if (detail > -1)
			{
				for (int i = 0; i < processingTimes.GetLength(0); i++)
				{
					if (!visited[i])
					{
						if (Math.Min(processingTimes[i][0], processingTimes[i][1]) <
							Math.Min(processingTimes[detail][0], processingTimes[detail][1]))
						{
							detail = i;
						}
					}
				}
			}			
			return detail;
		}
		private int FindFirstUnvisitedDetail()
		{
			int detail = -1;
			for (int i = 0; i < visited.Length; i++)
			{
				if (visited[i] == false)
				{
					detail = i;
					break;
				}
			}
			return detail;
		}		
		protected virtual void FillAnswer(Answer answer, int[] sequence, double[] bDowntimes, double[] detailsWaitTime, double totalB)
		{
			answer.OptimalSequence = sequence;
			answer.BDowntimeForEachDetail = (double[])bDowntimes.Clone();
			answer.TotalBDowntimeForEachDetail = answer.BDowntimeForEachDetail.Sum();
			answer.WaitingTimeForDetailsBeforeProcessingOnB = (double[])detailsWaitTime.Clone();
			answer.TotalWaitingTimeForDetailsBeforeProcessingOnB = 
				answer.WaitingTimeForDetailsBeforeProcessingOnB.Sum();
			answer.TotalTimeOfAllProductProcess = totalB + answer.TotalBDowntimeForEachDetail;
		}
		internal JonsonProblem2(double[][] matrix) : base(matrix)
		{

		}
	}
}
