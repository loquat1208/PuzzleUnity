using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        public int Stage { get; set; }
        public int Level { get; set; }

        private void Start()
        {
            Init();
            DontDestroyOnLoad(this);
        }

        private void Init()
        {
            Stage = 2;
        }
	}
}
