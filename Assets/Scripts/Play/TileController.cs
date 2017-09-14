using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

namespace Puzzle.Play
{
    public class TileController : MonoBehaviour
    {
        [SerializeField] private TileView view;

        void Start()
        {
            view.Draw();
            view.Tile.OnClickAsObservable().TakeUntilDestroy(this).Subscribe(_ =>
            {
                view.NextType();
                view.Draw();
            });
        }
    }
}