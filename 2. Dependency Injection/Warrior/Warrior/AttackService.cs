using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warrior
{
	public interface IAttackService
	{
		bool CalculateProbability(int targetStreangth, int weaponStrength);
	}

	class AttackService : IAttackService
	{
		public bool CalculateProbability(int targetStreangth, int weaponStrength)
		{
			return targetStreangth < weaponStrength;
		}
	}
}
