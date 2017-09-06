using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Puzzle.Game;

using UniRx;

namespace Puzzle.Title {
	public class TitleController : MonoBehaviour {
		[SerializeField] private TitleView View;

		private GameModel GameModel { get { return GameModel.Instance(); } }

		void Start ()
		{
			View.OnTap.Subscribe (_ => GameModel.Scene.LoadScene ("MainMenu"));
		}
	}
}
