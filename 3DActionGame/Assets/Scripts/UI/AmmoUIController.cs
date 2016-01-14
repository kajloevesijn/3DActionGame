using UnityEngine;
using UnityEngine.UI;

public class AmmoUIController : MonoBehaviour
{

    [SerializeField]
    private Text _ammoText;

    [SerializeField]
    private RangedProjectileWeapon _leftWeaponAmmo;
    [SerializeField]
    private RangedProjectileWeapon _rightWeaponAmmo;

    private int _totalAmmoLeft;
    private int _totalAmmoRight;

    private int _currentAmmoLeft;
    private int _currentAmmoRight;


    // Use this for initialization
    void Start()
    {

        _totalAmmoRight = _rightWeaponAmmo.TotalAmmo;//works doesn't need to be changed

        //_currentAmmoRight = _rightWeaponAmmo.CurrentAmmo;


        DisplayAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayAmmo();
    }

    //CURRENTAMMO IS NOT UPDATING ANGFSKGSKDJGSDLJKGFLSDKFJSDF RAGE
    //Get both values tho, total needs to be the same because thats max ammo and CurrentAmmo needs to get the set value xd which works correctly in RangedProjectileWeapon
    void DisplayAmmo()
    {
        _currentAmmoRight = _rightWeaponAmmo.CurrentAmmo;
        Debug.Log(_currentAmmoRight);
        _ammoText.text = "Gun Ammo: " + _totalAmmoRight.ToString() + " / " + _currentAmmoRight.ToString();
    }
}
