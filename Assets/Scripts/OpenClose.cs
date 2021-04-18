using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour
{
    public void OpenOrClose(GameObject gameobject)
	{
		if(gameobject.activeInHierarchy)
		{
			gameobject.SetActive(false);
		}
		else
		{
			gameobject.SetActive(true);
		}	
	}
}
