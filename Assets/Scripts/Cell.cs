using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
	public Material AliveCell;
	public Material DeadCell;
	bool state;
	bool nextstate;

	public Cell()
	{
		state = false;
		nextstate = false;
		//GetComponent<MeshRenderer> ().material = AliveCell;
	}

	public void changeState()
	{
		state = !state;
	}

	public void setAlive()
	{
		state = true;
	}

	public void setDead()
	{
		state = false;
	}

	public void setNSAlive()
	{
		nextstate = true;
	}

	public void setNSDead()
	{
		nextstate = false;
	}

	public void stateNS()
	{
		state = nextstate;
	}

	public void renderMat()
	{
		if (state)
			GetComponent<MeshRenderer> ().material = AliveCell;
		else
			GetComponent<MeshRenderer> ().material = DeadCell;
	}

	public bool returnState()
	{
		return state;
	}


}
