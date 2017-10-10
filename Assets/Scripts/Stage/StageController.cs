using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Puzzle.Game;
using Puzzle.System;

using UniRx;

namespace Puzzle.Stage
{
    public class StageController : MonoBehaviour
    {
        [SerializeField] private StageView view;

        private GameModel GameModel { get { return GameModel.Instance; } }

        private void Start()
        {
            view.Draw(GameModel);

            for( int i = 0; i < view.LevelButton.Count; i++)
            {
                int num = i;
                view.LevelButton[i].OnClickAsObservable().Subscribe(_ =>
                {
                    GameModel.CurrentLevel = num;
                    GameSystem.Instance.Scene.LoadScene("Play");
                });
            }
        }
    }
}
