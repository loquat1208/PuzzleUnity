using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

namespace Puzzle.Play
{
    public class PlayView : MonoBehaviour
    {
        public TilesController Tiles;

        [SerializeField] private Text stageText;
        [SerializeField] private Text levelText;
        [SerializeField] private Text remainChangeCountText;

        public IObservable<Text> StageText { get { return Observable.EveryUpdate().DistinctUntilChanged().Select(_ => stageText); } }
        public IObservable<Text> LevelText { get { return Observable.EveryUpdate().DistinctUntilChanged().Select(_ => levelText); } }
        public IObservable<Text> RemainChangeCountText { get { return Observable.EveryUpdate().DistinctUntilChanged().Select(_ => remainChangeCountText); } }
        public IObservable<long> GameClear { get { return Observable.EveryUpdate().DistinctUntilChanged().Where(_ => Tiles.isAllSameTile()); } }
    }
}
