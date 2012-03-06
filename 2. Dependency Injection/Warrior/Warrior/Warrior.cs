using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warrior
{
	public interface IWarrior
	{
		void Attack(string target, int targetStrength);
	}

	public class Barbarian : IWarrior
	{
		private readonly IWeapon _weapon;

		public Barbarian(IWeapon weapon)
		{
			_weapon = weapon;
		}

		public void Attack(string target, int targetStrength)
		{
			_weapon.Use(target, targetStrength);
		}
	}

	public class Marine : IWarrior
	{
		private readonly IWeapon _weapon;
		public Marine(IWeapon weapon)
		{
			_weapon = weapon;
		}

		public void Attack(string target, int targetStrength)
		{
			_weapon.Use(target, targetStrength);
		}
	}
}
