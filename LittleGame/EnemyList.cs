using System.Collections;
using System.Collections.Generic;


namespace LittleGame
{
	public class EnemyList : IEnumerable
	{
		private Dictionary<string, Player> enemies { get; } = new Dictionary<string, Player>();
		public int Count => enemies.Count;

		public void Add(Player player) => enemies.Add(player.Name, player);

		public Player this[string name] => enemies[name];

		public IEnumerator GetEnumerator() => enemies.Values.GetEnumerator();

		public void Remove(string name) => enemies.Remove(name);
	}
}