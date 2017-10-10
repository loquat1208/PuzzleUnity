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
        public StageData Stages { get; private set; }
		public int CurrentStage { get; set; }
		public int CurrentLevel { get; set; }

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            Stages = new StageData();
            CurrentStage = 0;
            CurrentLevel = 1;
        }
    }
}
