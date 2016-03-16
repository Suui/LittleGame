using FluentAssertions;
using GameApplication;
using LittleGame;
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
}
