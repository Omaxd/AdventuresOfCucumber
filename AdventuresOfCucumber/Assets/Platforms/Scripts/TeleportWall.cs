using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportWall : MonoBehaviour {

    public Vector3 newSpawnPlace;

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            CreateNewSpawnAndTeleport();
        }
    }

    void CreateNewSpawnAndTeleport()
    {
        GameObject.Find("LevelInfo").GetComponent<LevelInfo>().spawnPlace = newSpawnPlace;
        //Usunąłem funkcję spawn, bo jest używana do checkpointów.
        GameObject.Find("Hero").GetComponent<PlayerMovement>().transform.position = new Vector3(650, 80, -2);
    }

}
