using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlanetsColony
{
	public class ShowFPS : MonoBehaviour 
	{
		public static uint fps;

		void OnGUI()
		{
			fps = (uint)(1.0f / Time.deltaTime);
			GUILayout.Label("FPS: " + fps);
		}
	}
}