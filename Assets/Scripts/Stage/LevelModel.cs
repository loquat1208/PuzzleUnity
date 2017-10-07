using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle.Stage
{
    public class LevelModel
    {
        public int Index { get; set; }
        public int MaxChangeCount { get; set; }
        public Vector2 Grid { get; set; }
    }
}
