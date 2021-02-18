using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControl : MonoBehaviour
{

    #region Singleton

    public static CameraControl instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    #endregion

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

    public bool jumpToOnce = true;
    private bool doOnce = true;

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
        if (SceneManager.GetActiveScene().buildIndex == 1 && doOnce)
        {
            posY = 3.25f;
            targetPosY = 3.25f;
            transform.position = new Vector3(0, 3.25f, 0);
            cam.transform.position = new Vector3(0, 3.25f, 0);
            doOnce = false;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        targetPosY += scroll * mouseScrollMult;
        targetPosY = Mathf.Clamp(targetPosY, -2, 3.25f);

        posY = AnimMath.Slide(posY, targetPosY, 0.01f);

        transform.position = new Vector3(0, posY, 0);

        cam.transform.position = AnimMath.Slide(cam.transform.position, transform.position, 0.01f);

        switch (GameManager.instance.currPlayerTurn)
        {
            case 1:
                if (jumpToOnce)
                {
                    targetPosY = p1.camOffset;
                    jumpToOnce = false;
                }
                if (p1.isMoving)
                {
                    targetPosY = p1.camOffset;
                    mouseScrollMult = 0;
                }
                else
                {
                    mouseScrollMult = 10;
                }
                break;
            case 2:
                if (jumpToOnce)
                {
                    targetPosY = p2.camOffset;
                    jumpToOnce = false;
                }
                if (p2.isMoving)
                {
                    targetPosY = p2.camOffset;
                    mouseScrollMult = 0;
                }
                else
                {
                    mouseScrollMult = 10;
                }
                break;
            case 3:
                if (p3.isMoving)
                {
                    targetPosY = p3.camOffset;
                    mouseScrollMult = 0;
                }
                else
                {
                    mouseScrollMult = 10;
                }
                break;
            case 4:
                if (p4.isMoving)
                {
                    targetPosY = p4.camOffset;
                    mouseScrollMult = 0;
                }
                else
                {
                    mouseScrollMult = 10;
                }
                break;
            case 5:
                if (p5.isMoving)
                {
                    targetPosY = p5.camOffset;
                    mouseScrollMult = 0;
                }
                else
                {
                    mouseScrollMult = 10;
                }
                break;
            case 6:
                if (p6.isMoving)
                {
                    targetPosY = p6.camOffset;
                    mouseScrollMult = 0;
                }
                else
                {
                    mouseScrollMult = 10;
                }
                break;
            default:
                break;
        }
    }
}
