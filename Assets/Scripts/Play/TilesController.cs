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

        public List<TileView> Tiles { get { return _tiles; } }

        private GameModel GameModel { get { return GameModel.Instance; } }
        private List<TileView> _tiles = new List<TileView>();

        private void Start()
        {
            Init();
            _tiles.ForEach(x =>
            {
                x.Tile.OnClickAsObservable().TakeUntilDestroy(this)
                      .Subscribe(_ =>
                      {
                          if (x.Status == TileModel.STATUS.NORMAL)
                          {
                              x.Status = TileModel.STATUS.SELECTED;
                              x.Draw();
                              return;
                          }
                          x.Status = TileModel.STATUS.NORMAL;
                          x.NextType();
                          x.Draw();
                      });
            });
        }

        private void Init()
        {
            Vector2 grid = new Vector2(TilesModel.HERIZONTAL_NUM, TilesModel.VERTICAL_NUM);

            int maxTile = (int)grid.x * (int)grid.y;
            for (int i = 0; i < maxTile; i++)
            {
                GameObject tile = Instantiate(Tile.gameObject, this.transform) as GameObject;
                _tiles.Add(tile.GetComponent<TileView>());
            }

            _tiles.ForEach(x =>
            {
                x.Type = (TileModel.TYPE)Random.Range(0, 3);
                x.Draw();
            });

            Destroy(Tile.gameObject);
        }
    }
}