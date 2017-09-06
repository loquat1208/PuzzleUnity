using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Puzzle.System;

using UniRx;

namespace Puzzle.MainMenu
{
	public class MainMenuController : MonoBehaviour {
		[SerializeField] private Button StageButton;
		[SerializeField] private Button ShopButton;
		[SerializeField] private Button CreateButton;
		[SerializeField] private Button OptionButton;

		private GameSystem GameSystem { get { return GameSystem.Instance (); } }

		void Start() {
			StageButton.OnClickAsObservable ().TakeUntilDestroy (this).Subscribe (_ => OnStage());
			ShopButton.OnClickAsObservable ().TakeUntilDestroy (this).Subscribe (_ => OnShop());
			CreateButton.OnClickAsObservable ().TakeUntilDestroy (this).Subscribe (_ => OnCreate());
			OptionButton.OnClickAsObservable ().TakeUntilDestroy (this).Subscribe (_ => OnOption());
		}
	
		void OnStage()
		{
			GameSystem.Scene.LoadScene ("Stage");
		}

		void OnShop()
		{
			GameSystem.Message.CreateMessage ("Dont Created");
		}

		void OnCreate()
		{
			GameSystem.Message.CreateMessage ("Dont Created");
		}

		void OnOption()
		{
			GameSystem.Message.CreateMessage ("Dont Created");
		}
	}
}
