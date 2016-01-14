using UnityEngine;
using UnityEngine.UI;

public class AmmoUIController : MonoBehaviour {

    [SerializeField]
    private Text _ammoText;

    [SerializeField]
    private RangedProjectileWeapon _leftWeaponAmmo;
    [SerializeField]
    private RangedProjectileWeapon _rightWeaponAmmo;

    private float _totalAmmoLeft;
    private float _totalAmmoRight;

    private float _currentAmmoLeft;
    private float _currentAmmoRight;


	// Use this for initialization
	void Start () {
        _leftWeaponAmmo = GetComponent<RangedProjectileWeapon>();
        _rightWeaponAmmo = GetComponent <RangedProjectileWeapon>();

        _totalAmmoLeft = _leftWeaponAmmo.GetAmmoValue();
        _totalAmmoRight = _rightWeaponAmmo.GetAmmoValue();
        
        DisplayAmmo();
	}
	
	// Update is called once per frame
	void Update ()
    {
        _currentAmmoLeft = _leftWeaponAmmo.GetCurrentAmmoValue();
        _currentAmmoRight = _rightWeaponAmmo.GetCurrentAmmoValue();
	}

    void DisplayAmmo()
    {
        //ammoText.text = "Ammo: " + _totalAmmo.ToString() + " / " + _currentAmmo.ToString();

        _ammoText.text = "Gun Ammo: " + _totalAmmoRight.ToString() + " / " + _currentAmmoRight.ToString();
    }
}
