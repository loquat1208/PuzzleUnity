using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

namespace Puzzle.Title {
	public class TitleView : MonoBehaviour {
		public IObservable<long> OnTap { get { return Observable.EveryUpdate ().Where (_ => Input.GetMouseButton (0)); } }
	}
}
