using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer_New : MonoBehaviour
{
    private SteamVR_TrackedObject trackedObj;

    public GameObject laserPrefab;
    private GameObject laser;
    private Transform laserTransform;
    private Vector3 hitPoint;

    public GameObject disableLaserPrefab;
    private GameObject disableLaser;
    private Transform disableLaserTransform;
    public LayerMask teleportDisable;

    public Transform cameraRigTransform;
    public GameObject teleportReticlePrefab;
    private GameObject reticle;
    private Transform teleportReticleTeansform;
    public Transform headTransform;
    public Vector3 teleportRericleOffset;
    public LayerMask teleportEnable;
    private bool shouldTeleport;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true);
        laserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, 0.5f);
        laserTransform.LookAt(hitPoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y, hit.distance);
    }

    private void ShowDisableLaser(RaycastHit hit)
    {
        disableLaser.SetActive(true);

        disableLaserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, .5f);
        disableLaserTransform.LookAt(hitPoint);

        disableLaserTransform.localScale = new Vector3(disableLaserTransform.localScale.x,
            disableLaserTransform.localScale.y, hit.distance);

        laser.SetActive(false);
    }

    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
        disableLaser = Instantiate(disableLaserPrefab);
        disableLaserTransform = disableLaser.transform;

        reticle = Instantiate(teleportReticlePrefab);
        teleportReticleTeansform = reticle.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameManager.GetInstance().CheckGameStatePause())
        //    return;

        if(Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            RaycastHit hit;

            if(Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 10, teleportEnable))
            {
                hitPoint = hit.point;
                ShowLaser(hit);
                reticle.SetActive(true);
                teleportReticleTeansform.position = hitPoint + teleportRericleOffset;
                shouldTeleport = true;
            }

           else if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 10, teleportDisable))
            {
                hitPoint = hit.point;
                ShowDisableLaser(hit);
                shouldTeleport = false;
            }
        }
        else
        {
            disableLaser.SetActive(false);
            laser.SetActive(false);
            reticle.SetActive(false);
        }

        if(Controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad) && shouldTeleport)
        {
            StartCoroutine(Fade_Teleport());
        }
    }

    IEnumerator Fade_Teleport()
    {
        SteamVR_Fade.Start(Color.black, 0.3f);
        yield return new WaitForSeconds(0.3f);
        Teleport();
        SteamVR_Fade.Start(Color.clear, 0.3f);
        yield break;
    }

    private void Teleport()
    {
        shouldTeleport = false;
        reticle.SetActive(false);
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        difference.y = 0;
        cameraRigTransform.position = hitPoint + difference;
    }

}
