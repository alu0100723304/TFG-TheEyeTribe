using System.Collections;
using System;

namespace SpaceInvaders
{
    [Serializable]
    public class PlayerPoint : IComparable
    {
        protected string namePlayer { get; set; }
        protected int points { get; set; }

        public PlayerPoint ()
        {

        }

        public PlayerPoint (string name, int point)
        {
            namePlayer = name;
            points = point;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            PlayerPoint other = obj as PlayerPoint;
            if (other != null)
            {
                return this.points.CompareTo(other.points);
            }
            else
            {
                throw new ArgumentException("Object is not a PlayerPoint");
            }
        }

        #region "getters and setters"
        public string getNamePlayer ()
        {
            return this.namePlayer;
        }

        public int getPoints ()
        {
            return this.points;
        }

        #endregion
    }
}

