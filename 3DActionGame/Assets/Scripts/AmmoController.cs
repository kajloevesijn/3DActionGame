using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AmmoController : MonoBehaviour {// script for keeping track of ammo
    [SerializeField]private int basePlayerAmmo = 1000;
    public int playerAmmo { get; set; }

    void Start()
    {
        playerAmmo = basePlayerAmmo;
    }
}
