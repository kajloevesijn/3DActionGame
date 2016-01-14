using UnityEngine;
using UnityEngine.UI;

public class AmmoUIController : MonoBehaviour
{

    [SerializeField]
    private Text _ammoText;

    [SerializeField]
    private RangedProjectileWeapon _weapon;

	private int _totalAmmo;

	private int _currentAmmo;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		_totalAmmo = _weapon.TotalAmmo();

        _currentAmmo = _weapon.CurrentAmmo();

        DisplayAmmo();
    }

    //CURRENTAMMO IS NOT UPDATING ANGFSKGSKDJGSDLJKGFLSDKFJSDF RAGE
    //Get both values tho, total needs to be the same because thats max ammo and CurrentAmmo needs to get the set value xd which works correctly in RangedProjectileWeapon
    void DisplayAmmo()
    {
		if (_weapon.CurrentReloadState() == false) {
			_ammoText.text = "Gun Ammo: " + _totalAmmo.ToString () + " / " + _currentAmmo.ToString ();
		} else {
			_ammoText.text = "Reloading";
		}
    }
}
