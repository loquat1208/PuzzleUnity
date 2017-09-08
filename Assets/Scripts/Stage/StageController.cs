using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Puzzle.Game;

using UniRx;

namespace Puzzle.Stage
{
    public class StageController : MonoBehaviour
    {
        private StageModel _stage = new StageModel();
   
        public StageModel Stage { get { return _stage; } }
        public int Index = 1;
		public List<LevelModel> Levels = new List<LevelModel>();

        private void Start()
        {
            _stage.Index = Index;
			_stage.MaxLevel = Levels.Count;
        }
    }
}
