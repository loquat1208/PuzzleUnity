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
                6,
                new int[]
                {
                    1,1,1,1,1,1,1,
                    0,0,0,0,0,0,0,
                    3,3,3,3,3,3,3,
                    0,0,0,0,0,0,0,
                    2,2,2,2,2,2,2,
                    1,1,1,1,1,1,1,
                    3,3,3,3,3,3,3,
                    0,0,0,0,0,0,0,
                    1,1,1,1,1,1,1,
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
