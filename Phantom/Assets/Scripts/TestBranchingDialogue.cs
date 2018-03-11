using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBranchingDialogue : MonoBehaviour {
	public GameObject[] panels;
	int active = 0;

	public void ShowPanel(int index){
		panels [active].SetActive (false);
		if (index != -1) {
			panels [index].SetActive (true);
		}
		active = index;
	}

	public void Choice(int choiceIndex, char decision){
		PersistentDataManager.SetData (choiceIndex, decision);
	}

	public void Choice1A(){
		Choice (0, '1');
	}
	public void Choice1B(){
		Choice (0, '2');
	}

	public void Choice21A(){
		Choice (1, '1');
	}
	public void Choice21B(){
		Choice (1, '2');
	}

	public void Choice22A(){
		Choice (2, '1');
	}
	public void Choice22B(){
		Choice (2, '1');
	}


	void Start(){
		PersistentDataManager.LoadData ();
	}
}
