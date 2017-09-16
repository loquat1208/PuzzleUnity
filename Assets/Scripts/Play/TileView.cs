using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

namespace Puzzle.Play
{
    public class TileView : MonoBehaviour {
        [SerializeField] private Sprite ASprite;
        [SerializeField] private Sprite BSprite;
        [SerializeField] private Sprite CSprite;
        [SerializeField] private Sprite DSprite;

        public Button Tile;

        public TileModel.TYPE Type { get; set; }
        public TileModel.STATUS Status { get; set; }

        public void NextType()
        {
            Type++;
            if (Type >= TileModel.TYPE.TYPE_MAX)
            {
                Type = 0;
            }
        }

        public void Draw()
        {
            switch(Type)
            {
                case TileModel.TYPE.A:
                    Tile.image.sprite = ASprite;
                    break;
                case TileModel.TYPE.B:
                    Tile.image.sprite = BSprite;
                    break;
                case TileModel.TYPE.C:
                    Tile.image.sprite = CSprite;
                    break;
                case TileModel.TYPE.D:
                    Tile.image.sprite = DSprite;
                    break;
            }

            switch (Status)
            {
                case TileModel.STATUS.NORMAL:
                    Tile.transform.localScale = Vector3.one;
                    break;
                case TileModel.STATUS.SELECTED:
                    Tile.transform.localScale = Vector3.one * 1.2f;
                    break;
            }
        }
    }
}