using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Puzzle.Play;
using Puzzle.Game;

namespace Puzzle.Stage
{
    public class StageModel
    {
        public List<LevelModel> Levels = new List<LevelModel>();

        public StageModel(List<LevelModel> levels)
        {
            Levels = levels;
        }
    }
}
