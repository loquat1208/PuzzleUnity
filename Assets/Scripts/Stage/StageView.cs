using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Puzzle.Game;

namespace Puzzle.Stage
{
    public class StageView : MonoBehaviour
    {
        [SerializeField] private Button levelButton;

        public List<Button> LevelButton { get; private set; }

        public void Draw(GameModel gameModel)
        {
            LevelButton = new List<Button>();

            int levelCount = gameModel.StageData.Stages[gameModel.CurrentStage].Levels.Count;
            for (int i = 0; i < levelCount; i++)
            {
                GameObject _levelButton = Instantiate(levelButton.gameObject, this.transform) as GameObject;
                int levelNum = i + 1;
                _levelButton.GetComponentInChildren<Text>().text = levelNum.ToString();
                LevelButton.Add(_levelButton.GetComponent<Button>());
            }

            Destroy(levelButton.gameObject);
        }
    }
}
