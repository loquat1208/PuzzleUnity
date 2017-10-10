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
                15,
                new int[]
                {
                    0,1,2,3,0,1,2,
                    1,2,3,0,1,2,3,
                    2,3,0,1,2,3,0,
                    3,0,1,2,3,0,1,
                    0,1,2,3,0,1,2,
                    1,2,3,0,1,2,3,
                    2,3,0,1,2,3,0,
                    3,0,1,2,3,0,1,
                    0,1,2,3,0,1,2,
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
