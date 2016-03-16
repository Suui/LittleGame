using System;
using LittleGame;


namespace GameApplication
{
	public class Game
	{
		public Player Player { get; set; }
		public int CurrentTurn { get; set; }

		public void Start()
		{
			CurrentTurn = 0;

			Player = new Player("Player 1");
			Player.Enemies.Add(new Player("Miguel"));
			Player.Enemies.Add(new Player("Dani"));

			MainLoop();
		}

		private void MainLoop()
		{
			DisplayStats();
			while (GameIsNotOver())
			{
				ParseInput();
				foreach (Player enemy in Player.Enemies)
				{
					if (enemy.NextTurn == CurrentTurn) enemy.Attack(Player, enemy.AttackDamage);
				}
				DisplayStats();
			}
		}

		private void ParseInput()
		{
			var playerInput = Console.ReadLine();
			if (playerInput.Contains("heal"))
			{
				Player.HealSelf(150);
			}
			else if (playerInput.Contains("attack"))
			{
				playerInput.Split(' ');
				Player.Attack(Player.Enemy(playerInput.Split(' ')[1]), 510);
			}

			Console.WriteLine();
		}

		private void DisplayStats()
		{
			Console.Clear();

			if (GameIsOver())
			{
				if (Player.IsDead()) Console.WriteLine("YOU LOSE, SO BAD\n");
				else Console.WriteLine("You win, kinda good\n");
				return;
			}

			Console.WriteLine(Player.ToString() + "\n");
			Console.WriteLine("Enemies: ");
			foreach (var enemy in Player.Enemies)
				Console.WriteLine(enemy.ToString());
			
			Console.Write("\nType action: ");
		}

		private bool GameIsNotOver() => !GameIsOver();

		private bool GameIsOver() => Player.IsDead() || Player.Enemies.Count == 0;
	}
}