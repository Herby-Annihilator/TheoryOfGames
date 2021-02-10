using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryOfGames.JonsonProblems
{
	public class JPCreator
	{
		public JonsonProblem CreateJohnsonProblem(double[][] matrix, JPType type)
		{
			switch(type)
			{
				case JPType.Type2:
					return new JonsonProblem2(matrix);
				case JPType.Type3:
					return new JonsonProblem3(matrix);
				default:
					return new JonsonProblem2(matrix);
			}
		}
	}

	public enum JPType
	{
		Type2,
		Type3
	}
}
