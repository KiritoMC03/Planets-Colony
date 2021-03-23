using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    public class GameState : MonoBehaviour
    {
        static internal bool onPause = false;

        public void PausePlay()
        {
            onPause = !onPause;
        }
		
		private void Update()
		{
			if(onPause)
			{
				Time.timeScale = 0f;
			}
			else
			{
				Time.timeScale = 1f;
			}	
		}
    }
}