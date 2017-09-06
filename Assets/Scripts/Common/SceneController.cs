﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Puzzle.Game {
	public class SceneController : MonoBehaviour {
		
		public void LoadScene( string sceneName )
		{
			SceneManager.LoadScene (sceneName);
		}
	}
}
