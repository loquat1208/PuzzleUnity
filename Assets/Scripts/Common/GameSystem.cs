using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Puzzle.Game;

namespace Puzzle.System {
	public class GameSystem : MonoBehaviour {
		private static GameSystem _instance;
		public static GameSystem Instance()  
		{  
			if( !_instance )  
			{  
				_instance = GameObject.FindObjectOfType(typeof(GameSystem)) as GameSystem;   
			}  
			return _instance;  
		}

		private GameModel _gameModel;
		private GameObject _gameModelObject;
		private MessageService _messageService;

		public MessageService Message { get { return _messageService; } }

		private void Start()
		{
			DontDestroyOnLoad (this);
			Init ();
		}

		private void Init()
		{
			if (!_gameModel) {
				_gameModelObject = new GameObject ();
				_gameModelObject.name = "GameModel";
				_gameModel = _gameModelObject.AddComponent<GameModel> ();
			}

			if (!_messageService) {
				_messageService = gameObject.AddComponent<MessageService> ();
			}
		}
	}
}
