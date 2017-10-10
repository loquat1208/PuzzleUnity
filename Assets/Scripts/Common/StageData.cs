using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Puzzle.Stage;

public class StageData
{
    public List<StageModel> Stages;

    public StageData()
    {
        List<LevelModel> Levels = new List<LevelModel>()
        {
            new LevelModel
            (
                10,
                new int[]
                {
                    1,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,
                },
                new Vector2(7, 9)
            ),
            new LevelModel
            (
                9,
                new int[]
                {
                    1,1,0,0,0,0,0,
                    0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,
                },
                new Vector2(7, 9)
            )
        };

        Stages = new List<StageModel>()
        {
            new StageModel(Levels),
            new StageModel(Levels),
        };
    }
}
