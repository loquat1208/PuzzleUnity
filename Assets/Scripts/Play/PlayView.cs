using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Puzzle.Game;
using Puzzle.Stage;

using UniRx;

namespace Puzzle.Play
{
    public class PlayView : MonoBehaviour
    {
        public TilesController TilesController;
		public ResultDialogController ResultDialog;

		[SerializeField] private Text stageText;
		[SerializeField] private Text levelText;
		[SerializeField] private Text remainChangeCountText;

		public void Draw(GameModel gameModel)
		{
			stageText.text = string.Format("Stage {0}", gameModel.CurrentStage + 1);
			levelText.text = string.Format("Level {0}", gameModel.CurrentLevel + 1);

			StageModel stage = gameModel.StageData.Stages[gameModel.CurrentStage];
			LevelModel level = stage.Levels[gameModel.CurrentLevel];

			remainChangeCountText.text = string.Format("{0}", level.MaxChangeCount - TilesController.ChangeCount);
		}

		public void CreateResultDialog(bool isClear)
		{
			ResultDialog.Draw();
			ResultDialog.SetResultText(isClear);
			ResultDialog.SetNextStageButton(isClear);
		}
    }
}
