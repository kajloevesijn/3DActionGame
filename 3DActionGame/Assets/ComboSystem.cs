using UnityEngine;
using System.Collections;

public class ComboSystem : MonoBehaviour {
	[SerializeField]private int currentCombo;
	[SerializeField]private float comboFallOffTime = 1;

	private float baseComboFallOff;

	private int highestCombo;
	private float TimeStamp;
	
	void Start () {
		baseComboFallOff = comboFallOffTime;
	}
	void Update () {
		if (Time.time >= TimeStamp && currentCombo > 0) {
			DecreaseCombo ();
		}
	}

	//Private functions
	private void DecreaseCombo(){
		currentCombo--;
		modifyFallOff();
		UpdateComboTime ();
	}
	private void UpdateComboTime(){
		TimeStamp = Time.time + comboFallOffTime;
	}

	private void modifyFallOff(){
		comboFallOffTime = baseComboFallOff + (currentCombo);
	}

	//Public Functions
	public int getCombo(){
		return currentCombo;
	}
	
	public void IncreaseCombo(){
		currentCombo++;
		modifyFallOff ();
		if (currentCombo > highestCombo) {
			highestCombo = currentCombo;
		}
		UpdateComboTime ();
	}


}
