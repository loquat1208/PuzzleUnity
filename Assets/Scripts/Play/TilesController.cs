using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

using Puzzle.Game;
using Puzzle.Stage;

namespace Puzzle.Play
{
    public class TilesController : MonoBehaviour
    {
        [SerializeField] private TileView Tile;

        public Dictionary<int, TileView> Tiles { get { return _tiles; } }
        public int ChangeCount { get; private set; }

        private const int NONE = -1;
        private GameModel GameModel { get { return GameModel.Instance; } }
        private Dictionary<int, TileView> _tiles = new Dictionary<int, TileView>();
        private int currentIndex = NONE;

        private void Start()
        {
            Init();
            _tiles.ToObservable().TakeUntilDestroy(this).Subscribe(x =>
            {
                x.Value.Tile.OnClickAsObservable().TakeUntilDestroy(this)
                    .Subscribe(_ =>
                    {
						// TODO: 코드 리펙토링
                        if (currentIndex == NONE)
                        {
							currentIndex = x.Key;
							GroupSelect(currentIndex);
							return;
						} 
						else if (x.Value.Status != TileModel.STATUS.SELECTED)
						{
							AllNormal();
							currentIndex = x.Key;
							GroupSelect(currentIndex);
							return;
						}

						if (x.Value.Status == TileModel.STATUS.SELECTED)
                        {
                            ChangeCount++;
                            AllNextType();
                        }

                        currentIndex = NONE;
                        AllNormal();
                    });
            });
        }

        private void Init()
        {
            LevelModel level = GameModel.StageData.Stages[GameModel.CurrentStage].Levels[GameModel.CurrentLevel];
            Vector2 grid = level.Grid;
            ChangeCount = 0;

            int maxTile = (int)grid.x * (int)grid.y;
            for (int i = 0; i < maxTile; i++)
            {
                GameObject tile = Instantiate(Tile.gameObject, this.transform) as GameObject;
                _tiles.Add(i, tile.GetComponent<TileView>());
            }
				
            _tiles.ToObservable().TakeUntilDestroy(this).Subscribe(x =>
            {
                x.Value.Type = (TileModel.TYPE)level.Tiles[x.Key];
                x.Value.Draw();
            });

            Destroy(Tile.gameObject);
        }

        private void AllNormal()
        {
            _tiles.ToObservable().TakeUntilDestroy(this).Subscribe(x =>
            {
                x.Value.Status = TileModel.STATUS.NORMAL;
                x.Value.Draw();
            });
        }

        private void AllNextType()
        {
            _tiles.ToObservable().TakeUntilDestroy(this)
                .Where(x => x.Value.Status == TileModel.STATUS.SELECTED)
                .Subscribe(x =>
                {
                    x.Value.NextType();
                });
        }

        private void GroupSelect(int idx)
        {
			_tiles[idx].Status = TileModel.STATUS.SELECTED;
			_tiles[idx].Draw();
            for (int i = 0; i < TilesModel.HERIZONTAL_NUM + TilesModel.VERTICAL_NUM; i++)
            {
                _tiles.ToObservable().TakeUntilDestroy(this)
                    .Where(x => x.Value.Type == _tiles[idx].Type)
					.Where(x => CheckClossTile(x.Key))
                    .Subscribe(x =>
                    {
                        x.Value.Status = TileModel.STATUS.SELECTED;
                        x.Value.Draw();
                    });
            }
        }

        private bool CheckClossTile(int idx)
        {
			// TODO: 코드 리펙토링
            if(idx % TilesModel.HERIZONTAL_NUM != TilesModel.HERIZONTAL_NUM - 1)
            {
                if(_tiles[idx + 1].Status == TileModel.STATUS.SELECTED)
                    return true;
            }

            if (idx % TilesModel.HERIZONTAL_NUM != 0)
            {
                if (_tiles[idx - 1].Status == TileModel.STATUS.SELECTED)
                    return true;
            }

            if (idx >= TilesModel.HERIZONTAL_NUM)
            {
                if (_tiles[idx - TilesModel.HERIZONTAL_NUM].Status == TileModel.STATUS.SELECTED)
                    return true;
            }

            if (idx < TilesModel.MAX_NUM - TilesModel.HERIZONTAL_NUM)
            {
                if (_tiles[idx + TilesModel.HERIZONTAL_NUM].Status == TileModel.STATUS.SELECTED)
                    return true;
            }
            return false;
        }

        public bool isAllSameTile()
        {
            bool result = true;
            _tiles.ToObservable()
                .Where(x => x.Value.Type != _tiles[0].Type)
                .Subscribe(_ => result = false);
            return result;
        }
    }
}