using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Puzzle.Game;

using UniRx;

namespace Puzzle.Stage
{
    public class StagesController : MonoBehaviour
    {
        [SerializeField] private StagesView View;

        private GameModel GameModel { get { return GameModel.Instance; } }

        public int CurrentStage { get; set; }

        private void Start()
        {
            Init();
            CurrentStage = 0;
            View.Title.TakeUntilDestroy(this).Subscribe(x => x.text = string.Format("Stage {0}", CurrentStage + 1) );
        }

        private void Init()
        {

        }
    }
}
