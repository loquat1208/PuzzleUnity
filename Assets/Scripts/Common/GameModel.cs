using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Puzzle.Stage;

namespace Puzzle.Game
{
	public class GameModel : MonoBehaviour
	{
        private static GameModel _instance;
        public static GameModel Instance
        {
            get
            {
                if (!_instance)
                {
                    _instance = GameObject.FindObjectOfType(typeof(GameModel)) as GameModel;   
                }
                return _instance; 
            }
        }

        public List<StageModel> Stages { get; private set; }
        public int MaxStage = 0;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            if (Stages == null)
            {
                MaxStage = 1;
                Stages = new List<StageModel>();
                for (int i = 0; i < MaxStage; i++)
                {
                    StageModel stage = new StageModel();
                    stage.MaxLevel = 1;
                    stage.Index = i + 1;
                    Stages.Add(stage);
                }
            }
        }
    }
}
