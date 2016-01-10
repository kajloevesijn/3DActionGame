using UnityEngine;
using System.Collections;

public class ComboSystem : MonoBehaviour {
	[SerializeField]private int currentCombo;
	[SerializeField]private float comboFalloffTime = 1;

	private int highestCombo;
	private float TimeStamp;
	
	void Start () {
	
	}
	void Update () {
		if (Time.time >= TimeStamp && currentCombo > 0) {
			DecreaseCombo();
		}
	}

	//Private functions
	private void DecreaseCombo(){
		currentCombo--;
		UpdateComboTime ();
	}
	private void UpdateComboTime(){
		TimeStamp = Time.time + comboFalloffTime;
	}

	//Public Functions
	public int getCombo(){
		return currentCombo;
	}
	
	public void IncreaseCombo(){
		currentCombo++;
		if (currentCombo > highestCombo) {
			highestCombo = currentCombo;
		}
		UpdateComboTime ();
	}
}
