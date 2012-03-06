using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warrior
{
	public interface IWeapon
	{
		void Use(string target, int targetStrength);
	}

	public class Axe : IWeapon
	{
		private readonly IWriter _outputWriter;
		private readonly IAttackService _attackService;

		public int Strength { get; set; }

		public Axe(IWriter outputWriter, IAttackService attackService)
		{
			_outputWriter = outputWriter;
			_attackService = attackService;
		}

		public void Use(string target, int targetStrength)
		{
			if ( _attackService.CalculateProbability(targetStrength, Strength) )
			{
				_outputWriter.Write(string.Format("{0} hit with Axe", target));
			}
		}
	}

	
	public class Gun : IWeapon
	{
		private readonly IWriter _outputWriter;
		private readonly IAttackService _attackService;

		public int Strength { get; set; }

		public Gun(IWriter outputWriter, IAttackService attackService)
		{
			_outputWriter = outputWriter;
			_attackService = attackService;
		}
	
		public void Use(string target, int targetStrength)
		{
			if(_attackService.CalculateProbability(targetStrength, Strength))
			{
				_outputWriter.Write(string.Format("{0} hit with Gun", target));
			}
		}
	}
}
