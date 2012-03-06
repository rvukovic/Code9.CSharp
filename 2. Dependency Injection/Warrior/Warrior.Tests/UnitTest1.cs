using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Warrior.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void Warrior_can_use_weapon()
		{
			var mock = new Mock<IWeapon>();
			var warrior = new Barbarian(mock.Object);
			
			warrior.Attack("Tree",10);

			mock.Verify(w=>w.Use("Tree", 10), Times.Once());
		}

		[TestMethod]
		public void If_weapon_is_stronger_then_taget_attack_happens()
		{
			var mock = new Mock<IAttackService>();
			var mockWritter = new Mock<IWriter>();
			var warrior = new Axe(mockWritter.Object, mock.Object);

			mock.Setup(w => w.CalculateProbability(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

			warrior.Use("Tree",10);

			mockWritter.Verify(o=>o.Write("Tree hit with Axe"),Times.Once());
		}

		[TestMethod]
		public void If_weapon_is_weaker_then_taget_attack_does_not_happen()
		{
			var mock = new Mock<IAttackService>();
			var mockWritter = new Mock<IWriter>();
			var warrior = new Axe(mockWritter.Object, mock.Object);

			mock.Setup(w => w.CalculateProbability(It.IsAny<int>(), It.IsAny<int>())).Returns(false);

			warrior.Use("Tree", 10);

			mockWritter.Verify(o => o.Write("Tree hit with Axe"),Times.Never());
		}
	}
}
