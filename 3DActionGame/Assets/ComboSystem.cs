using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ComboSystem : MonoBehaviour {
	[SerializeField]private int currentCombo;
	[SerializeField]private float comboFallOffTime = 1;
	private float baseComboFallOff;
	private int highestCombo;
	private float TimeStamp;

	/*private int ArrayIndex = 0;
	//0 = pistol
	//1 = automatic pistol
	//2 = triple pistol
	//3 = assault rifle
	//4 = shotgun
	//5 = triple assault rifle


	//Weapon Modifiers
	[SerializeField]private List<float> baseWeaponAmmo;
	[SerializeField]private List<float> attackCooldownPeriod;
	[SerializeField]private List<float> bulletSpreadAmount;
	[SerializeField]private List<float> BulletSpacing;

	[SerializeField]private List<int> projectileAmount;

	[SerializeField]private List<bool> multipleProjectiles;
	[SerializeField]private List<bool> isShotgun;
	[SerializeField]protected List<bool> isAutomatic;*/

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
		//comboFallOffTime = baseComboFallOff + (currentCombo / 10 );
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
