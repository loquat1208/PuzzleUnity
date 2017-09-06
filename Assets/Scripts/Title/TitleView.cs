using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UniRx를 사용하기 위한 선언
using UniRx;

// namespace로 Title을 캡슐화
namespace Puzzle.Title
{
	// MCV, MPC를 검색, View는 표시, 입력관련
	public class TitleView : MonoBehaviour
	{
		// UniRx로 화면을 터치 했을 때를 확인
		public IObservable<long> OnTap { get { return Observable.EveryUpdate().Where(_ => Input.GetMouseButton(0)); } }
	}
}