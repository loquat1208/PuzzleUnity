using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Puzzle.Game;
using Puzzle.System;
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
			view.Draw(GameModel);

			view.TilesController.Tiles.ToObservable()
				.Subscribe(x => x.Value.OnTile.Subscribe(_ => UpdatePlay()))
				.AddTo (this);

            // TODO: 전 씬을 저장해서 전의 씬으로 넘어가게 수정
            Observable.EveryUpdate()
                //.Where(_ => Application.platform == RuntimePlatform.Android)
                .Where(_ => Input.GetKey(KeyCode.Escape))
                .First()
                .Subscribe(_ => GameSystem.Instance.Scene.LoadScene("Stage"));
        }

		private void UpdatePlay()
		{
			if (view.TilesController.isAllSameTile ())
				view.CreateResultDialog (true);

			StageModel stage = GameModel.StageData.Stages [GameModel.CurrentStage];
			LevelModel level = stage.Levels [GameModel.CurrentLevel];
			if (level.MaxChangeCount - view.TilesController.ChangeCount < 0) {
				view.CreateResultDialog (false);
			}

			view.Draw (GameModel);
		}
    }
}
