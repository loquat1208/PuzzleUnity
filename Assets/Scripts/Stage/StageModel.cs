using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Puzzle.Play;

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

        // TODO : 스테이지, 레벨에 대한 데이터 관리 시스템 확립이 필요
        public List<LevelModel> Levels
        {
            get
            {
                for (int i = 0; i < MaxLevel; i++)
                {
                    LevelModel level = new LevelModel();
                    level.Index = i + 1;
                    level.MaxChangeCount = 10;
                    _levels.Add(level);
                }
                return _levels;
            }
        }
    }
}
