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

        public Image Image;
        public Button Tile;

        public TileModel.TYPE Type { get; set; }
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
                    Image.sprite = ASprite;
                    break;
                case TileModel.TYPE.B:
                    Image.sprite = BSprite;
                    break;
                case TileModel.TYPE.C:
                    Image.sprite = CSprite;
                    break;
                case TileModel.TYPE.D:
                    Image.sprite = DSprite;
                    break;
            }
        }
    }
}