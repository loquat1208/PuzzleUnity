using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Puzzle.System;

using UniRx;

namespace Puzzle.Play
{
	public class ResultDialogController : MonoBehaviour
	{
		[SerializeField] private ResultDialogView view;

		public void Draw()
		{
			gameObject.SetActive(true);
		}

		public void SetNextStageButton(bool isOn)
		{
			view.NextStageButton.enabled = isOn;
		}

		public void SetResultText(bool isClear)
		{
			view.ResultText.text = isClear ? "GAME CLEAR" : "GAME FAIL";
			view.NextStageButton.image.color = new Color32(125, 125, 125, 255);
		}

		void Start()
		{
			view.GoStageButton.OnClickAsObservable().First().Subscribe(_ => GameSystem.Instance.Scene.LoadScene("Stage"));
		}
	}
}
