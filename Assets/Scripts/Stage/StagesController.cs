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

        public List<StageController> StageControllers;

        public int CurrentStage { get; set; }

        private void Start()
        {
            Init();
            CurrentStage = 0;
            View.Title.TakeUntilDestroy(this).Subscribe(x => x.text = string.Format("Stage {0}", GameModel.Stages[CurrentStage].Index) );
        }

        private void Init()
        {
            List<StageModel> stages = new List<StageModel>();
            for (int i = 0; i< StageControllers.Count; i++)
            {
                stages.Add(StageControllers[i].Stage);
            }

            GameModel.MaxStage = stages.Count;
            GameModel.Stages.AddRange(stages);
        }
    }
}
