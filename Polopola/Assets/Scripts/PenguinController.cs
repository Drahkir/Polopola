using System;
using UnityEditor;
using UnityEngine;
using System.Collections;

public class PenguinController : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 moveDirection;
    private Polarity polo;
    private Polarity pola;
    private float cameraHeight;
    private float cameraWidth;

    public enum Polarity
    {
        Red,
        Black,
    }

    // Use this for initialization
    void Start()
    {
        polo = Polarity.Red;
        pola = Polarity.Black;
        cameraHeight = Camera.main.pixelHeight;
        cameraWidth = Camera.main.pixelWidth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;

        if (Input.GetButton("Fire1"))
        {
            if (Input.mousePosition.x > cameraWidth / 2)
            {
                polo = polo == Polarity.Black ? Polarity.Red : Polarity.Black;
            }
            else
            {
                pola = pola == Polarity.Black ? Polarity.Red : Polarity.Black;
            }

            Vector3 moveToward;
            if (polo == pola)
            {
//                moveToward = new Vector3((Camera.main.aspect * Camera.main.orthographicSize) / 2, 0, 0);
                moveToward = new Vector3(-2000, 0, 0);

            }
            else
            {
                moveToward = new Vector3(-2000, 0, 0);
//                moveToward = new Vector3((Camera.main.aspect * Camera.main.orthographicSize) / 2, 0, 0);
            }
            moveDirection = moveToward - new Vector3(currentPosition.x, 0, 0);
            moveDirection.z = 0;
            moveDirection.Normalize();
            Vector3 target = moveDirection * moveSpeed + currentPosition;
            transform.position = Vector3.Lerp(currentPosition, target, Time.deltaTime);
//            var polaObject = GameObject.Find("Pola");
//            polaObject.transform.position = Vector3.Lerp(currentPosition, target, Time.deltaTime);
        }
    }
}
