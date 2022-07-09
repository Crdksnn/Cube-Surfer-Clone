using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
using Dreamteck.Splines;

public class CollectManager : MonoBehaviour
{
    public static CollectManager instance;

    [SerializeField] private List<GameObject> cubeList = new List<GameObject>();

    [Header("Canvas Objects")]
    public GameObject canvas;
    public GameObject diamondIconPrefab;
    private UIController uiController;

    [Header("Finish Settings")]
    public SplineFollower splineFollower;
    public PlayerMovement playerMovement;
    public Animator animator;
    public GameObject greatText;
    public GameObject[] particleEffects;

    [Header("Cube Stack Settings")]
    public GameObject model;
    public GameObject cubePrefab;
    public Transform stack;
    public GameObject addCubeTextPrefab;
    public TrailRenderer trailRenderer;
    Camera cam;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        cam = Camera.main;
        uiController = UIController.instance;

        

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            splineFollower.followSpeed = 15;
            playerMovement.enabled = true;
            uiController.DisableArrowHand();
        }

        GameOver();
    }

    public void AddCube()
    {
        
        model.transform.position += new Vector3(0f, 1f, 0f); 
        GameObject cube = Instantiate(cubePrefab, cubeList.Last().transform.position + new Vector3(0, 1f, 0), cubeList.Last().transform.rotation);
        cubeList.Add(cube);
        cube.transform.SetParent(stack);

        //Add cube text
        Vector2 screenXY;
        screenXY = cam.WorldToScreenPoint(cubeList.Last().transform.position + new Vector3(-1f, 0, 0).normalized);

        GameObject addCubeText = Instantiate(addCubeTextPrefab);
        addCubeText.transform.SetParent(canvas.transform);
        addCubeText.GetComponent<RectTransform>().position = screenXY;
        
        Destroy(addCubeText, .5f);
        CameraBack();
    }

    public void RemoveCube(GameObject cube)
    {
        cube.transform.SetParent(null);
        cubeList.Remove(cube);
        Destroy(cube, 1f);
        CameraForward();
    }

    public void RemoveCubeFinish(GameObject cube)
    {
        cube.transform.SetParent(null);
        cubeList.Remove(cube);
        Destroy(cube, 1f);
        CameraUp();
    }

    public int CubeListCount() { return cubeList.Count; }

    public void DiamondIconCreate(Transform collide)
    {
        Vector2 screenXY = Camera.main.WorldToScreenPoint(collide.gameObject.transform.position);
        GameObject diamondIcon = Instantiate(diamondIconPrefab) as GameObject;
        diamondIcon.transform.SetParent(canvas.transform);
        diamondIcon.transform.position = screenXY;
    }

    //Game Over Settings
    void GameOver()
    {
        if(cubeList.Count <= 0)
        {
            splineFollower.followSpeed = 0;
            playerMovement.enabled = false;
            trailRenderer.enabled = false;
            this.enabled = false;
        }
    }

    //Finish Settings
    public void FinishCamPos()
    {
        Vector3 camForward = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y + CubeListCount() / 10, cam.transform.localPosition.z);
        cam.transform.DOLocalMove(camForward, .2f);
        splineFollower.followSpeed = 25;
    }

    public void FinishSettings()
    {
        splineFollower.followSpeed = 0;
        playerMovement.enabled = false;
        animator.SetBool("isDancing", true);
        greatText.SetActive(true);
        
        foreach (GameObject particleEffect in particleEffects)
        {
            particleEffect.GetComponent<ParticleSystem>().Play();
        }

        this.enabled = false;
    }

    //Camera Settings
    void CameraBack()
    {
        //Vector3 camBack = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, cam.transform.localPosition.z - .2f);
        Vector3 camBack = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, cam.transform.localPosition.z - new Vector3(0f, 0f, .35f).magnitude);
        cam.transform.DOLocalMove(camBack, .2f);
    }

    void CameraForward()
    {
        //Vector3 camForward = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, cam.transform.localPosition.z + .35f);
        Vector3 camForward = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, cam.transform.localPosition.z + new Vector3(0f, 0f, 0.35f).magnitude);
        cam.transform.DOLocalMove(camForward, .2f);
    }

    void CameraUp()
    {
        Vector3 camForward = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y + new Vector3(0f, 1f, 0).magnitude, cam.transform.localPosition.z);
        cam.transform.DOLocalMove(camForward, .2f);
    }

}
