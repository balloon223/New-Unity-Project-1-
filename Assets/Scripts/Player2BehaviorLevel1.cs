using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2BehaviorLevel1 : MonoBehaviour
{
    public Transform groundCheckTransform;
    public float groundCheckRadius = .5f;
    public bool isGrounded = false;
    public LayerMask groundLayerMask;
    private float _rotationSpeed = 20f;
    private Vector3 _horizontalMovement;
    public float rayLength = 0.5f;
    public float speed;
    public float jumpHeight;
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public GameObject door5;
    public GameObject door6;
    public GameObject door7;
    public GameObject obj1;

    public Sprite DeathAni;

    Rigidbody2D myBody;
    BoxCollider2D myCollider;

    float moveDir = 1;
    bool onFloor = true;

    // Start is called before the first frame update
    void Start()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();
        myCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D groundHit = Physics2D.Raycast(groundCheckTransform.position, Vector2.down, rayLength, groundLayerMask);
        if(groundHit.collider != null){isGrounded = true;} else{isGrounded = false;}



/*    _horizontalMovement = new Vector3(0f, 0f, -Input.GetAxis("Horizontal"));

    transform.Rotate(_horizontalMovement * _rotationSpeed * Time.deltaTime);

    if(Input.GetKey(KeyCode.Space))
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * 10f, Color.red);
        RayCastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.up), 10f);

        if(hit)
        {
            Debug.Log("Hit Something : " + hit.collider.name);
            hit.transform.GetComponent<SpriteRenderer>().color = Color.red;

        }
    }
*/

    }

    void OnDrawGizmos(){
            Gizmos.color = Color.red;
            Gizmos.DrawLine(groundCheckTransform.position, new Vector2(groundCheckTransform.position.x, groundCheckTransform.position.y - rayLength));
        }

    void OnTriggerEnter2D(Collider2D trig){
/*        if (trig.gameObject.tag == "Trigger"){
            Destroy(trig.gameObject);
            Destroy(door1);
        }

        if (trig.gameObject.tag == "Trigger1"){
            Destroy(trig.gameObject);
            Destroy(door2);
        }

        if (trig.gameObject.tag == "Trigger2"){
            Destroy(trig.gameObject);
            Destroy(door3);
        }

        if (trig.gameObject.tag == "Trigger3"){
            Destroy(trig.gameObject);
            Destroy(door4);
        }

        if (trig.gameObject.tag == "Trigger4"){
            Destroy(trig.gameObject);
            Destroy(door5);
        }

        if (trig.gameObject.tag == "Trigger5"){
            Destroy(trig.gameObject);
            Destroy(door6);
        }

        if (trig.gameObject.tag == "Trigger6"){
            Destroy(trig.gameObject);
            Destroy(door7);
        }

        if(trig.gameObject.tag == "laser"){
        SceneManager.LoadScene(0);
         }

        if(trig.gameObject.tag == "laser"){
        Destroy(this.gameObject);
         }

        if(trig.gameObject.tag == "laser2"){
        Destroy(this.gameObject);
         }*/

        if(trig.gameObject.tag == "Player"){
        SceneManager.LoadScene(2);
         }
    }



    void FixedUpdate()
    {
/*        if(onFloor && myBody.velocity.y > 0){
            onFloor = false;
        }
*/     
        CheckKeys();
        HandleMovement();
    }

    void CheckKeys(){
        if(Input.GetKey("right")){
            moveDir = 1;
        } else if(Input.GetKey("left")){
            moveDir = -1;
        } else{
            moveDir = 0;
        }
        if(Input.GetKey("up")){
            myBody.velocity = new Vector3(myBody.velocity.x, jumpHeight);
        }
    }

    void HandleMovement(){
        myBody.velocity = new Vector3(moveDir * speed, myBody.velocity.y);
    }

    /*void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Floor"){
            onFloor = true;
        }
    }
    */

}
