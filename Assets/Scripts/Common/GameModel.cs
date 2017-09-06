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

		public SceneController Scene { get { return _scene_controller; } }

		private SceneController _scene_controller;

		private void Start () {
			Screen.SetResolution (Screen.width, Screen.width * 16 / 9, false);
			DontDestroyOnLoad (this);

			if (!_scene_controller)
				_scene_controller = gameObject.AddComponent<SceneController> ();
		}
	}
}
