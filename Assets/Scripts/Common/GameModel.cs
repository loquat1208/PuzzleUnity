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

		// TODO: 나중에 따로 저장하는 클래스, 서버 제작
        public List<StageModel> Stages { get; private set; }
		public int CurrentStage { get; set; }
		public int CurrentLevel { get; set; }
		public int MaxStage { get; set; }

        private void Start()
        {
            Init();
        }

        private void Init()
        {
			// Dummy Data
            if (Stages == null)
            {
                MaxStage = 1;
				CurrentStage = 0;
				CurrentLevel = 0;
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
