using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

		private void Start()
		{
            if (Instance != this)
            {
                Destroy(this);
                return;
            }

            Screen.SetResolution(Screen.width, Screen.width * HEIGHT_RATIO / WIDTH_RATIO, false);
			Init();
			DontDestroyOnLoad(this);
		}

		private void Init()
		{
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
