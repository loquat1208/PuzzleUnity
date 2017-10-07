using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

namespace Puzzle.Stage
{
    public class StagesView : MonoBehaviour
    {
        [SerializeField] private Text TitleText;

        public IObservable<Text> Title { get { return Observable.EveryUpdate().DistinctUntilChanged().Select(_ => TitleText); } }
    }
}
