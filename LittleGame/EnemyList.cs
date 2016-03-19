using System.Collections;
using System.Collections.Generic;


namespace LittleGame
{
	public class EnemyList : IEnumerable
	{
		private Dictionary<string, Player> Enemies { get; } = new Dictionary<string, Player>();
		public int Count => Enemies.Count;

		public void Add(Player player) => Enemies.Add(player.Name, player);

		public Player this[string name] => Enemies[name];

		public IEnumerator GetEnumerator() => Enemies.Values.GetEnumerator();

		public void Remove(string name) => Enemies.Remove(name);
	}
}