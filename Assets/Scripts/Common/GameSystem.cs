using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Puzzle.Game;

namespace Puzzle.System
{
	public class GameSystem : MonoBehaviour
	{
		private static GameSystem _instance;
		public static GameSystem Instance
		{
            get
            {
                if (!_instance)
                {  
                    _instance = GameObject.FindObjectOfType(typeof(GameSystem)) as GameSystem;   
                }  
                return _instance;
            }
		}
            
        private const int HEIGHT_RATIO = 16;
        private const int WIDTH_RATIO = 9;

        public SceneController Scene { get; private set; }
        public MessageService Message { get; private set; }

        private GameModel _gameModel;
        private GameObject _gameModelObject;

		private void Start()
		{
            Screen.SetResolution(Screen.width, Screen.width * HEIGHT_RATIO / WIDTH_RATIO, false);
			DontDestroyOnLoad(this);
			Init();
		}

		private void Init()
		{
            if (!_gameModel)
			{
				_gameModelObject = new GameObject();
                _gameModelObject.name = "GameModel";
                _gameModel = _gameModelObject.AddComponent<GameModel>();
			}

            if (!Message)
			{
                Message = gameObject.AddComponent<MessageService>();
			}
				
            if (!Scene)
			{
                Scene = gameObject.AddComponent<SceneController>();
			}
		}
	}
}
