using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryOfGames.JonsonProblems
{
	public class Answer
	{
		public int[] OptimalSequence { get; internal set; }
		public double[] WaitingTimeForDetailsBeforeProcessingOnB { get; internal set; }
		public double TotalWaitingTimeForDetailsBeforeProcessingOnB { get; internal set; }
		public double[] BDowntimeForEachDetail { get; internal set; }
		public double TotalBDowntimeForEachDetail { get; internal set; }
		public double TotalTimeOfAllProductProcess { get; internal set; }
		public double[] CDowntimeForEachDetail { get; internal set; }
		public double TotalCDowntimeForEachDetail { get; internal set; }
	}
}
