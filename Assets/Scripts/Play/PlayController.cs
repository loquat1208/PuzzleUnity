using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            StageModel stage = GameModel.Stages[GameModel.CurrentStage];
            LevelModel level = stage.Levels[GameModel.CurrentLevel];
            int remainCount = level.MaxChangeCount - view.Tiles.ChangeCount;
            view.StageText.TakeUntilDestroy(this)
				.Subscribe( x => x.text = string.Format("Stage {0}", stage.Index));
			view.LevelText.TakeUntilDestroy(this)
				.Subscribe( x => x.text = string.Format("Level {0}", level.Index));
            view.RemainChangeCountText.TakeUntilDestroy(this)
                .Subscribe(x => x.text = string.Format("{0}", remainCount));
            view.GameClear.First()
                .Subscribe(_ => Debug.Log("GameClear"));
            Observable.EveryUpdate().Where(_ => remainCount < 0).First()
                .Subscribe(_ => Debug.Log("GameFail"));
        }
    }
}
