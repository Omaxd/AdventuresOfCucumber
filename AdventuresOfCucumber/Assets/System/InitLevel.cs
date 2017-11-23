using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitLevel : MonoBehaviour
{

    public GameObject Panel;

	void Start () {
        GameObject.Find("BramaW").SetActive(false);
        GameObject.Find("SliceOrginal").gameObject.SetActive(false);
        Panel.SetActive(false);
    }
}
