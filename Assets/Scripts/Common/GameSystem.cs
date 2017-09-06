using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Puzzle.Game;

namespace Puzzle.System
{
	public class GameSystem : MonoBehaviour
	{
		// 싱글톤
		private static GameSystem _instance;
		public static GameSystem Instance()
		{  
			if (!_instance)
			{  
				_instance = GameObject.FindObjectOfType(typeof(GameSystem)) as GameSystem;   
			}  
			return _instance;  
		}

		private GameModel _gameModel;
		private GameObject _gameModelObject;
		private MessageService _messageService;
		private SceneController _scene_controller;

		public SceneController Scene { get { return _scene_controller; } }
		public MessageService Message { get { return _messageService; } }

		private void Start()
		{
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

			if (!_messageService)
			{
				_messageService = gameObject.AddComponent<MessageService>();
			}
				
			if (!_scene_controller)
			{
				_scene_controller = gameObject.AddComponent<SceneController>();
			}
		}
	}
}
