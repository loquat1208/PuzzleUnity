using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

namespace Puzzle.Stage
{
    public class StageView : MonoBehaviour
    {
        [SerializeField] private Text TitleText;

        public GameObject LevelRoot;
        public IObservable<Text> Title { get { return Observable.EveryUpdate().DistinctUntilChanged().Select(_ => TitleText); } }
    }
}
