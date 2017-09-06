using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle.Game {
	public class GameModel : MonoBehaviour {
		private static GameModel _instance;
		public static GameModel Instance()  
		{  
			if( !_instance )  
			{  
				_instance = GameObject.FindObjectOfType(typeof(GameModel)) as GameModel;   
			}  
			return _instance;  
		}

		private void Start () {
			Screen.SetResolution (Screen.width, Screen.width * 16 / 9, false);
			DontDestroyOnLoad (this);
		}
	}
}
