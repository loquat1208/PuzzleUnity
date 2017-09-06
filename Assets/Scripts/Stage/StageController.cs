using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Puzzle.System;
using Puzzle.Game;

using UniRx;

namespace Puzzle.Stage
{
    public class StageController : MonoBehaviour
    {
        [SerializeField] private StageView View;

        private GameModel GameModel { get { return GameModel.Instance; } }

        private void Start()
        {
            View.Title.TakeUntilDestroy(this).Subscribe(x => x.text = string.Format("Stage {0}", GameModel.Stage) );
        }
    }
}
