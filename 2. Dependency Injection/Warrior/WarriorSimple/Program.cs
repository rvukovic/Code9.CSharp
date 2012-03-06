using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace WarriorSimple
{
	class Program
	{
		static void Main(string[] args)
		{
			var container = new UnityContainer();
			container.RegisterType<IWeapon, Axe>();

			var warrior = container.Resolve<Barbarian>();

			warrior.Attack("Tree");
		}
	}

	public interface IWeapon
	{
		void Use(string target);
	}

	public class Axe : IWeapon
	{
		public int Strength { get; set; }
		
		public void Use(string target)
		{
			Console.WriteLine("{0} hit with Axe", target);
		}
	}
	
	public class Barbarian 
	{
		private readonly IWeapon _weapon;

		public Barbarian(IWeapon weapon)
		{
			_weapon = weapon;
		}

		public void Attack(string target)
		{
			_weapon.Use(target);
		}
	}
}
