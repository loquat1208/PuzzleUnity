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
        public TilesController Tiles;
		public ResultDialogController ResultDialog;

        [SerializeField] private Text stageText;
        [SerializeField] private Text levelText;
		[SerializeField] private Text remainChangeCountText;

        public IObservable<Text> StageText { get { return Observable.EveryUpdate().Select(_ => stageText); } }
        public IObservable<Text> LevelText { get { return Observable.EveryUpdate().Select(_ => levelText); } }
        public IObservable<Text> RemainChangeCountText { get { return Observable.EveryUpdate().Select(_ => remainChangeCountText); } }
    }
}
