using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dooor : MonoBehaviour {

    public GameObject levelInfo;
    public GameObject body;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TryOpen();
	}

    void TryOpen()
    {
        if(levelInfo.GetComponent<LevelInfo>().numberOfEnemies==0)
        {
            Destroy(body);
        }
    }
}
