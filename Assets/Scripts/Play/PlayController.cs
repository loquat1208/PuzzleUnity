using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Puzzle.Game;

using UniRx;

namespace Puzzle.Play
{
    public class PlayController : MonoBehaviour
    {
        [SerializeField] private PlayView view;

        private GameModel GameModel { get { return GameModel.Instance; } }

        void Start()
        {
            view.StageText.TakeUntilDestroy(this).Subscribe( x => x.text = string.Format("Stage {0}", GameModel.Stages[0].Index));
            view.LevelText.TakeUntilDestroy(this).Subscribe( x => x.text = string.Format("Level {0}", GameModel.Stages[0].Levels[0].Index));
        }
    }
}
