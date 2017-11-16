using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSlice : MonoBehaviour {

    public Transform cursor;
    public GameObject innerHolo;
    public GameObject innerBody;
    public GameObject brightnerBalls;
    public GameObject darkerBalls;
    public GameObject outerHolo;

    float throwSpeed;
    float rotationSpeed;
    float movingSpeed;
   
    public bool isUsing; //Flaga dot. uzywania


    // Use this for initialization
    void Start () {
        isUsing = true;
        throwSpeed = 10;
        rotationSpeed = 10f;
        movingSpeed = 0.5f;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<BoxCollider>().enabled = false;
        cursor.gameObject.SetActive(true);
        GetComponent<Animator>().enabled = false;
        SetCursor("MOVE");
        
    }

    void Update()
    {      
        if (isUsing)
        {
            PrepareSliceToShow();
            TryMove();
            TryRotate();
            TryAction();
        }
        else PrepareSliceToBeSet();
    }

    //Ustawianie kursora przed plastrem
    public void SetCursor(string action)
    {
        switch (action)
        {
            case "MOVE":
                {
                    var slicePosition = transform.position;
                    var sliceRotation = transform.rotation;
                    cursor.position = slicePosition;
                    cursor.rotation = sliceRotation;
                    cursor.Translate(new Vector3(2.6f, 0, 0));
                    break;
                }
            case "DELETE":
                {
                    cursor.gameObject.SetActive(false);
                    break;
                }
            case "ACTIVE":
                {
                    cursor.gameObject.SetActive(true);
                    break;
                }
        }
    }

    void TryAction()
    {
        //Zostaw plasterek
        if (Input.GetButton("SetSlice")) 
        {            
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<BoxCollider>().enabled = true;
            SetSlice();
        }

        //Rzuc plasterkiem
        if (Input.GetButton("ThrowSlice")) 
        {            
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<BoxCollider>().enabled = true;
            ThrowSlice();
        }
    }
    public void SetSlice()
    {
        SetCursor("DELETE");
        GetComponent<Animator>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = true;
        isUsing = false;
    }
    void ThrowSlice()
    {
        SetCursor("DELETE");
        GameObject.Find("SoundInfo").GetComponent<SoundInfo>().throwSlice.Play();
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(100 * throwSpeed, 0, 0));
        isUsing = false;
    }

    void TryRotate()
    {
        //Obracaj zgodnie z wskazowkami zegara
        if (Input.GetKey(KeyCode.Keypad1)) RotateClockwise();

        //Obracaj niezgodnie z wskazowkami zegara
        if (Input.GetKey(KeyCode.Keypad2)) RotateCounterClockwise();
    }
    void RotateClockwise()
    {
        transform.Rotate(Vector3.back * rotationSpeed);
        SetCursor("MOVE");
    }
    void RotateCounterClockwise()
    {
        transform.Rotate(Vector3.forward * rotationSpeed);
        SetCursor("MOVE");
    }

    void TryMove()
    {    
        float actualRotation = transform.eulerAngles.z; //Pobieramy przesunięcie względem osi Y

        //Plasterek idzie do gory
        if (Input.GetKey(KeyCode.UpArrow)) SliceUp(actualRotation);

        //Plasterek idzie w dol
        if (Input.GetKey(KeyCode.DownArrow)) SliceDown(actualRotation);

        //Plasterek idzie w lewo
        if (Input.GetKey(KeyCode.LeftArrow)) SliceLeft(actualRotation);

        //Plasterek idzie w prawo
        if (Input.GetKey(KeyCode.RightArrow)) SliceRight(actualRotation);

    }
    void SliceUp(float actualRotation)
    {
        transform.Rotate(new Vector3(0, 0, -actualRotation));
        transform.Translate(new Vector3(0, movingSpeed, 0));
        transform.Rotate(new Vector3(0, 0, actualRotation));
        SetCursor("MOVE");
    }
    void SliceDown(float actualRotation)
    {
        transform.Rotate(new Vector3(0, 0, -actualRotation));
        transform.Translate(new Vector3(0, -movingSpeed, 0));
        transform.Rotate(new Vector3(0, 0, actualRotation));
        SetCursor("MOVE");
    }
    void SliceLeft(float actualRotation)
    {
        transform.Rotate(new Vector3(0, 0, -actualRotation));
        transform.Translate(new Vector3(-movingSpeed, 0, 0));
        transform.Rotate(new Vector3(0, 0, actualRotation));
        SetCursor("MOVE");
    }
    void SliceRight(float actualRotation)
    {
        transform.Rotate(new Vector3(0, 0, -actualRotation));
        transform.Translate(new Vector3(movingSpeed, 0, 0));
        transform.Rotate(new Vector3(0, 0, actualRotation));
        SetCursor("MOVE");
    }


    void PrepareSliceToShow()
    {
        innerBody.SetActive(false);    
    }
    void PrepareSliceToBeSet()
    {
        brightnerBalls.GetComponent<ChangeMaterials>().SetMaterialOnObject(1);
        darkerBalls.GetComponent<ChangeMaterials>().SetMaterialOnObject(1);
        outerHolo.GetComponent<ChangeMaterials>().SetMaterialOnObject(1);
        innerBody.SetActive(true);
        innerHolo.SetActive(false);
    }

}
