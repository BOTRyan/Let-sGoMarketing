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

    private float posY = 3.25f;
    private float targetPosY = 3.25f;
    private float mouseScrollMult = 10;

    // Start is called before the first frame update
    void Start()
    {

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

        if (GameManager.instance.currPlayerTurn == 1)
        {
            targetPosY = player1.transform.position.y;
        }
        else if (GameManager.instance.currPlayerTurn == 2)
        {
            targetPosY = player2.transform.position.y;
        }
        else if (GameManager.instance.currPlayerTurn == 3)
        {
            targetPosY = player3.transform.position.y;
        }
        else if (GameManager.instance.currPlayerTurn == 4)
        {
            targetPosY = player4.transform.position.y;
        }
        else if (GameManager.instance.currPlayerTurn == 5)
        {
            targetPosY = player5.transform.position.y;
        }
        else if (GameManager.instance.currPlayerTurn == 6)
        {
            targetPosY = player6.transform.position.y;
        }
    }
}
