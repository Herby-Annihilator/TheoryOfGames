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
			
		}
		protected int[] GetOptimalSequence()
		{
			visited = new bool[processingTimes.GetLength(0)];
			int[] optimalSequence = new int[processingTimes.GetLength(0)];
			int head = 0;
			int tail = optimalSequence.Length - 1;
			int detail;
			for (int i = 0; i < processingTimes.GetLength(0); i++)
			{
				detail = FindDetailWithMinProcessTime();
				visited[detail] = true;
				if (processingTimes[detail][0] < processingTimes[detail][1])
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
		internal JonsonProblem2(double[][] matrix) : base(matrix)
		{

		}
	}
}
