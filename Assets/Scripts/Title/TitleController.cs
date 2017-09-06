using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// System안에 있는 함수를 사용하기 위해 선언
using Puzzle.System;

using UniRx;

namespace Puzzle.Title
{
	// Controller는 View, Model부터 데이터를 받아 수정, 전달
	public class TitleController : MonoBehaviour
	{
		[SerializeField] private TitleView View;

		private GameSystem GameSystem { get { return GameSystem.Instance; } }

		void Start()
		{
			View.OnTap.Subscribe(_ => GameSystem.Scene.LoadScene("MainMenu"));
		}
	}
}
