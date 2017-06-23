using UnityEngine;
using System.Collections;
using System;

namespace BreakOut {
	
	[Serializable]
	public class PlayerPoints : IComparable {
		protected string playerName;
		protected int points;

		public PlayerPoints (){}

		public PlayerPoints (string name, int point) {
			this.playerName = name;
			this.points = point;
		}

		public string getPlayerName () {
			return this.playerName;
		}

		public int getPoints () {
			return this.points;
		}

		public void setPlayerName(string name){
			this.playerName = name;
		}

		public void setPoints(int point){
			this.points = point;
		}

		public int CompareTo(object obj) {
			if (obj == null)
			{
				return 1;
			}

			PlayerPoints other = obj as PlayerPoints;
			if (other != null)
			{
				return this.points.CompareTo(other.points);
			}
			else
			{
				throw new ArgumentException("Object is not a PlayerPoint");
			}
		}


	}
}
