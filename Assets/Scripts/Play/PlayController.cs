using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Puzzle.Game;
using Puzzle.Stage;

using UniRx;

namespace Puzzle.Play
{
    public class PlayController : MonoBehaviour
    {
        [SerializeField] private PlayView view;

        private GameModel GameModel { get { return GameModel.Instance; } }

        void Start()
        {
			StageModel stage = GameModel.StageData.Stages[GameModel.CurrentStage];
            LevelModel level = stage.Levels[GameModel.CurrentLevel];

            view.StageText.TakeUntilDestroy(this)
				.Subscribe( x => x.text = string.Format("Stage {0}", GameModel.CurrentStage + 1));
			view.LevelText.TakeUntilDestroy(this)
				.Subscribe( x => x.text = string.Format("Level {0}", GameModel.CurrentLevel + 1));
			view.RemainChangeCountText.TakeUntilDestroy(this)
				.Subscribe(x => x.text = string.Format("{0}", level.MaxChangeCount - view.Tiles.ChangeCount));

			Observable.EveryUpdate().Where(_ => view.Tiles.isAllSameTile()).First()
				.Subscribe(_ =>
					{
						view.ResultDialog.Draw();
						view.ResultDialog.SetResultText(true);
					});
			Observable.EveryUpdate().Where(_ => level.MaxChangeCount - view.Tiles.ChangeCount <= 0).First()
				.Subscribe(_ =>
					{
						view.ResultDialog.Draw();
						view.ResultDialog.SetResultText(false);
						view.ResultDialog.SetNextStageButton(false);
					});
        }
    }
}
