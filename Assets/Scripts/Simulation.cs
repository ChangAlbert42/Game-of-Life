using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour {
	public int sizeX;
	public int sizeY;
	public GameObject cellPrefab;

	Vector3 startPos;

	GameObject[,] cellBoard;

	GameObject celltile;


	// Use this for initialization
	void Start () {
		cellBoard = new GameObject[sizeX,sizeY];
		startPos = cellPrefab.transform.position;
		for (int y = 0; y < sizeY; y++)
			for (int x = 0; x < sizeX; x++) {
				celltile = Instantiate (cellPrefab, new Vector3 (x * 1F + startPos.x, startPos.y - y * 1F, 1), Quaternion.identity);
				cellBoard [x,y] = celltile;
				celltile.GetComponent<Cell> ().renderMat ();
			}
		cellBoard[0,0].GetComponent<Cell> ().setAlive ();
		cellBoard[0,0].GetComponent<Cell> ().renderMat ();
		cellBoard[1,0].GetComponent<Cell> ().setAlive ();
		cellBoard[1,0].GetComponent<Cell> ().renderMat ();
		Debug.Log (returnAliveCount (1, 1));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		for (int y = 0; y < sizeY; y++)
			for (int x = 0; x < sizeX; x++) {
				if (returnAliveCount (x, y) == 2 || returnAliveCount (x, y) == 3) {

					cellBoard [x, y].GetComponent<Cell> ().setNSAlive ();
				}
				else 
					cellBoard [x, y].GetComponent<Cell> ().setNSDead ();
			}

		for (int y = 0; y < sizeY; y++)
			for (int x = 0; x < sizeX; x++) {
				cellBoard [x, y].GetComponent<Cell> ().stateNS ();
				cellBoard [x, y].GetComponent<Cell> ().renderMat ();
			}
		
	}

	int returnAliveCount(int xcoord, int ycoord)
	{
		int aliveCounter = 0;
		List<int> coordList = new List<int>();
		for(int x = 0; x < 8; x++)
			coordList.Add(x);

		if (xcoord == 0) {
			coordList.Remove (0);
			coordList.Remove (3);
			coordList.Remove (5);
		}

		if (xcoord == (sizeX - 1)) {
			coordList.Remove (2);
			coordList.Remove (4);
			coordList.Remove (7);
		}

		if (ycoord == 0) {
			coordList.Remove (0);
			coordList.Remove (1);
			coordList.Remove (2);
		}
			
		if (ycoord == (sizeY - 1)) {
			coordList.Remove (5);
			coordList.Remove (6);
			coordList.Remove (7);
		}

		foreach (var coord in coordList) {
			switch (coord) 
			{
			case 0:
				if (cellBoard [xcoord - 1, ycoord - 1].GetComponent<Cell> ().returnState ())
					aliveCounter++;
					break;
			case 1:
				if (cellBoard [xcoord,ycoord - 1].GetComponent<Cell> ().returnState ())
					aliveCounter++;
				break;

			case 2:
				if (cellBoard [xcoord + 1,ycoord - 1].GetComponent<Cell> ().returnState ())
					aliveCounter++;
				break;

			case 3:
				if (cellBoard [xcoord - 1,ycoord].GetComponent<Cell> ().returnState ())
					aliveCounter++;
				break;

			case 4:
				if (cellBoard [xcoord + 1,ycoord].GetComponent<Cell> ().returnState ())
					aliveCounter++;
				break;

			case 5:
				if (cellBoard [xcoord - 1,ycoord + 1].GetComponent<Cell> ().returnState ())
					aliveCounter++;
				break;

			case 6:
				if (cellBoard [xcoord,ycoord + 1].GetComponent<Cell> ().returnState ())
					aliveCounter++;
				break;

			case 7:
				if (cellBoard [xcoord + 1,ycoord + 1].GetComponent<Cell> ().returnState ())
					aliveCounter++;
				break;
			}
		}
		return aliveCounter;
	}
}
