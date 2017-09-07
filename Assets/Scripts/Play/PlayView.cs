using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

namespace Puzzle.Play
{
    public class PlayView : MonoBehaviour
    {
        [SerializeField] private Text stageText;
        [SerializeField] private Text levelText;

        public IObservable<Text> StageText { get { return Observable.EveryUpdate().DistinctUntilChanged().Select(_ => stageText); } }
        public IObservable<Text> LevelText { get { return Observable.EveryUpdate().DistinctUntilChanged().Select(_ => levelText); } }
    }
}
