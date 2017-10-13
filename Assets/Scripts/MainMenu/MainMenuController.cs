using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Puzzle.System;

using UniRx;

namespace Puzzle.MainMenu
{
	public class MainMenuController : MonoBehaviour
	{
		// 사실은 버튼은 View를 만들어 관리하는게 좋음
		[SerializeField] private Button StageButton;
		[SerializeField] private Button ShopButton;
        [SerializeField] private Button OptionButton;
        [SerializeField] private Button HomeButton;

		private GameSystem GameSystem { get { return GameSystem.Instance; } }

		void Start() {
			StageButton.OnClickAsObservable().TakeUntilDestroy(this).Subscribe(_ => OnStage());
			ShopButton.OnClickAsObservable().TakeUntilDestroy(this).Subscribe(_ => OnShop());
            OptionButton.OnClickAsObservable().TakeUntilDestroy(this).Subscribe(_ => OnOption());
            HomeButton.OnClickAsObservable().TakeUntilDestroy(this).Subscribe(_ => OnHome());
		}
	
		private void OnStage()
		{
			GameSystem.Scene.LoadScene("Stage");
		}

		private void OnShop()
		{
			GameSystem.Message.CreateMessage("Dont Created");
		}

        private void OnOption()
        {
            GameSystem.Message.CreateMessage("Dont Created");
        }
        
        private void OnHome()
        {
            GameSystem.Scene.LoadScene("Title");
        }
	}
}
