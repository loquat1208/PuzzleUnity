using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Puzzle.System;

using UniRx;

namespace Puzzle.Title {
	public class TitleController : MonoBehaviour {
		[SerializeField] private TitleView View;

		private GameSystem GameSystem { get { return GameSystem.Instance(); } }

		void Start ()
		{
			View.OnTap.Subscribe (_ => GameSystem.Scene.LoadScene ("MainMenu"));
		}
	}
}
