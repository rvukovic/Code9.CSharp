using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace Warrior
{
	class Program
	{
		static void Main(string[] args)
		{
			var unity = new UnityContainer();
			unity.RegisterType<IWriter, Writer>();
			unity.RegisterType<IAttackService, AttackService>();
			unity.RegisterType<IWeapon, Axe>("ColdWeapon", new InjectionProperty("Strength", 40));
			unity.RegisterType<IWeapon, Gun>(new InjectionProperty("Strength", 50));
			unity.RegisterType<IWarrior, Barbarian>( new InjectionConstructor(new ResolvedParameter<IWeapon>("ColdWeapon")));
			unity.RegisterType<IWarrior, Marine>("Modern");

			var old = unity.Resolve<IWarrior>();
			var strong = unity.Resolve<IWarrior>("Modern");

			old.Attack("Troll", 40);
			strong.Attack("Troll", 40);
		}
	}

	public interface IWriter
	{
		void Write(string output);
	}

	public class Writer : IWriter
	{
		public void Write(string output)
		{
			Console.WriteLine("***" + output);
		}
	}
}
