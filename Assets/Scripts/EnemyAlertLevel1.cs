using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlertLevel1 : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 0.01f;
    private Rigidbody2D rb;
    private Vector2 movement;

    public GameObject previousbody;
    public GameObject player2obj;
    public bool p2Spawned = false;

    public Transform playerCheckTransform;
    public float playerCheckRadius = 3;
    public LayerMask playerLayerMask;
    public bool playerDiscovered = false;
    public float rayLength = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D playerCheckHit = Physics2D.Raycast(playerCheckTransform.position, Vector2.down, rayLength, playerLayerMask);
        if(playerCheckHit.collider != null)
        {
            playerDiscovered = true;
            
            if(p2Spawned == false){
            Instantiate(player2obj, new Vector3(-9f, 8.75f, 0), Quaternion.identity);
//            player2obj.AddComponent<Rigidbody2D>();
//            player2obj.AddComponent<BoxCollider2D>();
            p2Spawned = true;
            }

        }
        Vector3 direction = player.position-transform.position;
        movement=direction;
    }
    
    void moveObject(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(playerCheckTransform.position, new Vector2(playerCheckTransform.position.x, playerCheckTransform.position.y - rayLength));
    }

    void FixedUpdate()
    {
        if(playerDiscovered == true)
        {moveObject(movement);}
    }
}

