using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

using Puzzle.Game;

namespace Puzzle.Play
{
    public class TilesController : MonoBehaviour
    {
        [SerializeField] private TileView Tile;

        public Dictionary<int, TileView> Tiles { get { return _tiles; } }

        private const int NONE = -1;
        private GameModel GameModel { get { return GameModel.Instance; } }
        private Dictionary<int, TileView> _tiles = new Dictionary<int, TileView>();
        private int currentIndex = NONE;

        private void Start()
        {
            Init();
            _tiles.ToObservable().Subscribe(x =>
            {
                x.Value.Tile.OnClickAsObservable().TakeUntilDestroy(this)
                    .Subscribe(_ =>
                    {
                        if (x.Value.Status == TileModel.STATUS.NORMAL)
                        {
                            if (currentIndex == NONE)
                            {
                                x.Value.Status = TileModel.STATUS.SELECTED;
                                currentIndex = x.Key;
                                x.Value.Draw();
                            }
                            else
                            {
                                currentIndex = NONE;
                                AllNormal();
                            }
                            return;
                        }
                        x.Value.Status = TileModel.STATUS.NORMAL;
                        x.Value.NextType();
                        AllNormal();
                    });
            });
        }

        private void AllNormal()
        {
            _tiles.ToObservable().Subscribe(x =>
            {
                x.Value.Status = TileModel.STATUS.NORMAL;
                x.Value.Draw();
            });
        }

        private void Init()
        {
            Vector2 grid = new Vector2(TilesModel.HERIZONTAL_NUM, TilesModel.VERTICAL_NUM);

            int maxTile = (int)grid.x * (int)grid.y;
            for (int i = 0; i < maxTile; i++)
            {
                GameObject tile = Instantiate(Tile.gameObject, this.transform) as GameObject;
                _tiles.Add(i, tile.GetComponent<TileView>());
            }

            _tiles.ToObservable().Subscribe(x =>
            {
                x.Value.Type = (TileModel.TYPE)Random.Range(0, 3);
                x.Value.Draw();
            });

            Destroy(Tile.gameObject);
        }
    }
}