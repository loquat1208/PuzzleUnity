using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle.Stage
{
    public class StageModel
    {
        public StageModel(int index, int maxLevel)
        {
            Index = index;
            MaxLevel = maxLevel;
        }

        public StageModel()
        {

        }

        private List<LevelModel> _levels = new List<LevelModel>();

        public int Index { get; set; }
        public int MaxLevel { get; set; }

        public List<LevelModel> Levels
        {
            get
            {
                for (int i = 0; i < MaxLevel; i++)
                {
                    LevelModel level = new LevelModel();
                    level.Index = i + 1;
                    _levels.Add(level);
                }
                return _levels;
            }
        }
    }
}
