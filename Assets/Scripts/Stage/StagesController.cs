using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Puzzle.Game;
using Puzzle.System;

using UniRx;

namespace Puzzle.Stage
{
    public class StagesController : MonoBehaviour
    {
        [SerializeField] private StagesView View;

        private GameModel GameModel { get { return GameModel.Instance; } }

        private void Start()
        {
            Init();
            View.Title.TakeUntilDestroy(this).Subscribe(x => x.text = string.Format("Stage {0}", GameModel.CurrentStage + 1) );
        }

        private void Init()
        {
            // TODO: 전 씬을 저장해서 전의 씬으로 넘어가게 수정
            Observable.EveryUpdate()
                //.Where(_ => Application.platform == RuntimePlatform.Android)
                .Where(_ => Input.GetKey(KeyCode.Escape))
                .First()
                .Subscribe(_ => GameSystem.Instance.Scene.LoadScene("MainMenu"));
        }
    }
}
