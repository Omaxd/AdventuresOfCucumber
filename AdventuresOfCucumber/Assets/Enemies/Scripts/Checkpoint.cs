using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public GameObject checkpointFlag;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().checkpointPosition = transform.position;
            Debug.Log("Checkpoint accomplished");

            checkpointFlag.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}