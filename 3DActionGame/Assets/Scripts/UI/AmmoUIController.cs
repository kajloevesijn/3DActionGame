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

    private float _totalAmmoLeft;
    private float _totalAmmoRight;

    private float _currentAmmoLeft;
    private float _currentAmmoRight;


    // Use this for initialization
    void Start()
    {

        _totalAmmoRight = _rightWeaponAmmo.TotalAmmo;
        _currentAmmoRight = _rightWeaponAmmo.CurrentAmmo;


        DisplayAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        //_currentAmmoLeft = _leftWeaponAmmo.GetCurrentAmmoValue();
        //s_currentAmmoRight = _rightWeaponAmmo.GetCurrentAmmoValue();
        //_currentAmmoRight;
        //_currentAmmoRight = _rightWeaponAmmo.CurrentAmmo;

        DisplayAmmo();
    }

    //CURRENTAMMO IS NOT UPDATING ANGFSKGSKDJGSDLJKGFLSDKFJSDF RAGE
    //Get both values tho, total needs to be the same because thats max ammo and CurrentAmmo needs to get the set value xd which works correctly in RangedProjectileWeapon
    void DisplayAmmo()
    {
        _currentAmmoRight = _rightWeaponAmmo.CurrentAmmo;
        Debug.Log(_currentAmmoRight);
        _ammoText.text = "Gun Ammo: " + _totalAmmoRight.ToString() + " / " + _rightWeaponAmmo.CurrentAmmo.ToString();
    }
}
