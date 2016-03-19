using FluentAssertions;
using LittleGame;
using NUnit.Framework;


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
			player.HealSelf(300);

			player.Health.Should().Be(800);
		}

		[Test]
		public void not_be_able_to_heal_himself_over_1000()
		{
			var player = new Player("Player 1");

			player.HealSelf(100);

			player.Health.Should().Be(1000);
		}

		[Test]
		public void consume_60_mana_per_heal()
		{
			var player = new Player("Player 1");

			player.HealSelf(100);

			player.Mana.Should().Be(140);
		}

		[Test]
		public void not_be_able_to_heal_himself_if_he_has_not_enough_mana()
		{
			var player = new Player("Player 1");

			player.ReceiveDamage(800);
			player.HealSelf(200);
			player.HealSelf(200);
			player.HealSelf(200);
			player.HealSelf(200);

			player.Mana.Should().Be(20);
			player.Health.Should().Be(800);
		}

		[Test]
		public void attack_his_enemies_by_name()
		{
			var player = new Player("Player 1");
			var enemyPlayerName = "Any";

			player.Enemies.Add(new Player(enemyPlayerName));
			player.Attack(player.Enemy(enemyPlayerName), 200);

			player.Enemy(enemyPlayerName).Health.Should().Be(800);
		}
	}
}
