using FluentAssertions;
using NUnit.Framework;

/* TODO
	
*/

namespace LittleGameTest
{
	[TestFixture]
	public class PlayerShould
	{
		[Test]
		public void receive_damage()
		{
			var player = new Player("Player 1");

			player.ReceiveDamage(200);

			player.Health.Should().Be(800);
		}

		[Test]
		public void die_at_0_health_when_the_damage_received_exceed_his_current_health()
		{
			var player = new Player("Player 1");

			player.ReceiveDamage(1100);

			player.Health.Should().Be(0);
			player.IsDead().Should().BeTrue();
		}

		[Test]
		public void heal_himself()
		{
			var player = new Player("Player 1");

			player.ReceiveDamage(500);
			player.ReceiveHealing(300);

			player.Health.Should().Be(800);
		}
	}
}
