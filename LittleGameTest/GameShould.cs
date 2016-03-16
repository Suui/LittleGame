using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

/* TODO
	- Player has a list of enemies
	- Enemies have health and name
	- Enemies attack player every 2 turns
	- Player can attack an enemy every turn
	- Player may heal himself instead of attacking every turn
	- Player has 200 mana each heal costs 60 mana
	- Player has name, health, mana
	- Console display of everything

	- Game ends when there are no more enemies alive (win condition)
	- Or ends when the player dies (lose condition)
	- Game is managed on a per-turn basis
	- At game start, there are two enemies, turns loop starts
*/

namespace LittleGameTest
{
	[TestFixture]
	public class GameShould
	{
		[Test]
		public void start_with_a_player_and_two_enemies()
		{
			var game = new Game();

			game.Start();

			game.CurrentTurn.Should().Be(0);
			game.Player.Enemies.Count.Should().Be(2);
		}
	}

	public class Game
	{
		public Player Player { get; set; }
		public int CurrentTurn { get; set; }

		public void Start()
		{
			CurrentTurn = 0;

			Player = new Player("Any Player");
			Player.Enemies.Add(new Player("Any Enemy"));
			Player.Enemies.Add(new Player("Any Enemy"));
		}
	}

	public class Player
	{
		private string Name { get; }
		public EnemyList Enemies { get; set; } = new EnemyList();
		public decimal Health { get; set; }

		public Player(string name)
		{
			Name = name;
			Health = 1000;
		}

		public void ReceiveDamage(int amount) => Health = Math.Max(Health - amount, 0);

		public bool IsDead() => Health == 0;

		public void ReceiveHealing(int amount)
		{
			Health += amount;
		}
	}

	public class EnemyList
	{
		private List<Player> enemies { get; } = new List<Player>();
		public int Count => enemies.Count;

		public void Add(Player player) => enemies.Add(player);
	}
}
