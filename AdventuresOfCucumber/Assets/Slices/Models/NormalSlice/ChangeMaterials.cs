using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterials : MonoBehaviour {

    public Material[] materials;
    Renderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[0];
		//materials= 
	}

    public void SetMaterialOnObject(int index)
    {
        if(index>=0 && index<materials.Length)
        {
            rend.sharedMaterial = materials[index];
        }
    }
}
