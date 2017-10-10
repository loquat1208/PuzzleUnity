using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle.Stage
{
    public class LevelModel
    {
        public int MaxChangeCount { get; set; }
        public int[] Tiles { get; set; }
        public Vector2 Grid { get; set; }

        public LevelModel(int maxChangeCount, int[] tiles, Vector2 grid)
        {
            MaxChangeCount = maxChangeCount;
            Tiles = tiles;
            Grid = grid;
        }

        public LevelModel()
        {

        }
    }
}
