using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Puzzle.Game;

public class TilesController : MonoBehaviour {
	[SerializeField] private Button Tile;

	public List<Button> Tiles { get { return _tiles; } }

	private GameModel GameModel { get { return GameModel.Instance; } }
	private List<Button> _tiles = new List<Button> ();

	private void Start()
	{
		Init ();
	}

	private void Init()
	{
		Vector2 grid = new Vector2(6, 8);
		int maxTile = (int)grid.x * (int)grid.y;
		for (int i = 0; i < maxTile; i++) {
			GameObject tile = Instantiate (Tile.gameObject, this.transform) as GameObject;
			_tiles.Add (tile.GetComponent<Button>());
		}
		Destroy (Tile.gameObject);
	}
}