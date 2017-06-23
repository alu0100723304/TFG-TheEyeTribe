using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace SpaceInvaders {

    [Serializable]
    public class MedicData {
        protected List<float> eyeX { get; set; }
        protected List<float> eyeY { get; set; }

        #region "Initializes"

        public MedicData ()
        {
            eyeX = new List<float> ();
            eyeY = new List<float> ();
        }

        public MedicData (List<float> eyeX, List<float> eyeY)
        {
            this.eyeX = Copy (eyeX);
            this.eyeY = Copy (eyeY);
        }

        #endregion

        #region "getters and setter"

        public List<float> PointsEyeX ()
        {
            return Copy (eyeX);
        }

        public List<float> PointsEyeY()
        {
            return Copy (eyeY);
        }

        public void Add (Vector2 position)
        {
            eyeX.Add (position.x);
            eyeY.Add (position.y);
        }

        public void Add (float x, float y)
        {
            eyeX.Add (x);
            eyeY.Add (y);
        }


        public void Add (MedicData data)
        {
            for ( int i = 0; i < data.PointsEyeX ().Count; i++ )
            {
                Add (data.PointsEyeX () [i], data.PointsEyeY () [i]);
            }
        }

        #endregion


        /// <summary>
        /// Method to copy float list
        /// </summary>
        /// <param name="list">List to copy</param>
        /// <returns>List copied</returns>
        public List<float> Copy (List<float> list)
        {
            List<float> aux = new List<float> ();
            foreach ( float i in list ) aux.Add (i);
            return aux;
        }
    
    }
}


