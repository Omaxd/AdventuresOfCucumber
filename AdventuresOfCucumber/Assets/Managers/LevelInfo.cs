using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour {

    public int numberOfEnemies;
    public bool isFreeze;
    public bool spicesIsActive;
    public bool gateIsClose;
    public Vector3 spawnPlace;

	void Start () {
        numberOfEnemies = 1;
        isFreeze = false;
        spicesIsActive = false;
        gateIsClose = false;
        spawnPlace = new Vector3(-20, 17, -2);
	}
}
