using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle.Game
{
	public class GameModel : MonoBehaviour
	{
		private static GameModel _instance;
		public static GameModel Instance()
		{  
			if (!_instance)
			{  
				_instance = GameObject.FindObjectOfType(typeof(GameModel)) as GameModel;   
			}  
			return _instance;  
		}

		private const int HEIGHT_RATIO = 16;
		private const int WIDTH_RATIO = 9;

		private void Start() {
			Screen.SetResolution(Screen.width, Screen.width * HEIGHT_RATIO / WIDTH_RATIO, false);
			DontDestroyOnLoad(this);
		}
	}
}
