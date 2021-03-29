using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{

    public Transform followTransform;
    public BoxCollider2D worldBounds;
    

    float xmin;
    float xmax;
    float ymin;
    float ymax;

    float camx;
    float camy;

    float camRatio;
    float camSize;

    Camera mainCam;

    Vector3 smoothPos;

    public float smoothRate = 1;


    // Start is called before the first frame update
    void Start()
    {
        xmin = worldBounds.bounds.min.x;
        xmax = worldBounds.bounds.max.x;
        ymin = worldBounds.bounds.min.y;
        ymax = worldBounds.bounds.max.y;

        mainCam = gameObject.GetComponent<Camera>();

        camSize = mainCam.orthographicSize;
        camRatio = (xmax + camSize) / 8.0f;
    }

    // Update is called once per frame
    void Update()
    {
        camy = Mathf.Clamp(followTransform.position.y, ymin + camSize, ymax - camSize);
        camx = Mathf.Clamp(followTransform.position.x, xmin + camRatio, xmax - camRatio);

            smoothPos = Vector3.Lerp(this.transform.position, new Vector3(camx, camy, gameObject.transform.position.z), 0.3f);
    
        gameObject.transform.position = smoothPos;
    
    //Restart
    if(Input.GetKey(KeyCode.R)){
        SceneManager.LoadScene(0);
    }
    }


}
