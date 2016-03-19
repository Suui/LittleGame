using System;


namespace LittleGame
{
	public class Player
	{
		private const int MaximumHealth = 1000;
		private const int MaximumMana = 200;
		private const int HealManaCost = 60;

		public string Name { get; }
		public decimal Health { get; set; }
		public decimal Mana { get; set; }
		public decimal AttackDamage { get; set; }
		public EnemyList Enemies { get; set; }

		public Player(string name)
		{
			Name = name;
			Health = MaximumHealth;
			Mana = MaximumMana;
			AttackDamage = 210;
			Enemies = new EnemyList();
		}

		public void Attack(Player player, decimal damage)
		{
			if (IsDead()) return;
			player.ReceiveDamage(damage);
			if (player.IsDead()) Enemies.Remove(player.Name);
		}

		public void ReceiveDamage(decimal amount) => Health = Math.Max(Health - amount, 0);

		public Player Enemy(string name) => Enemies[name];

		public bool IsDead() => Health == 0;

		public void HealSelf(int amount)
		{
			if (Mana < HealManaCost) return;

			Mana -= HealManaCost;
			Health = Math.Min(Health + amount, MaximumHealth);
		}

		public override string ToString()
		{
			return Name + ": Health = " + Health + ", Mana = " + Mana;
		}
	}
}