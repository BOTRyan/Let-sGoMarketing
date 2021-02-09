using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Camera cam;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject player5;
    public GameObject player6;

    private PlayerMovement p1;
    private PlayerMovement p2;
    private PlayerMovement p3;
    private PlayerMovement p4;
    private PlayerMovement p5;
    private PlayerMovement p6;

    private float posY = 3.25f;
    private float targetPosY = 3.25f;
    private float mouseScrollMult = 10;

    // Start is called before the first frame update
    void Start()
    {
        p1 = player1.GetComponent<PlayerMovement>();
        p2 = player2.GetComponent<PlayerMovement>();
        p3 = player3.GetComponent<PlayerMovement>();
        p4 = player4.GetComponent<PlayerMovement>();
        p5 = player5.GetComponent<PlayerMovement>();
        p6 = player6.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        targetPosY += scroll * mouseScrollMult;
        targetPosY = Mathf.Clamp(targetPosY, -2, 3.25f);

        posY = AnimMath.Slide(posY, targetPosY, 0.01f);

        transform.position = new Vector3(0, posY, 0);

        cam.transform.position = AnimMath.Slide(cam.transform.position, transform.position, 0.01f);

        if (GameManager.instance.currPlayerTurn == 1 && p1.isMoving)
        {
            targetPosY = player1.transform.position.y;
            mouseScrollMult = 0;
        }
        else if (GameManager.instance.currPlayerTurn == 2 && p2.isMoving)
        {
            targetPosY = player2.transform.position.y;
            mouseScrollMult = 0;
        }
        else if (GameManager.instance.currPlayerTurn == 3 && p3.isMoving)
        {
            targetPosY = player3.transform.position.y;
            mouseScrollMult = 0;
        }
        else if (GameManager.instance.currPlayerTurn == 4 && p4.isMoving)
        {
            targetPosY = player4.transform.position.y;
            mouseScrollMult = 0;
        }
        else if (GameManager.instance.currPlayerTurn == 5 && p5.isMoving)
        {
            targetPosY = player5.transform.position.y;
            mouseScrollMult = 0;
        }
        else if (GameManager.instance.currPlayerTurn == 6 && p6.isMoving)
        {
            targetPosY = player6.transform.position.y;
            mouseScrollMult = 0;
        }
        else
        {
            mouseScrollMult = 10;
        }
    }
}
