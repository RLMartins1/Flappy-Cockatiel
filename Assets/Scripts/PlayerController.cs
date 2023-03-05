using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody thisRigidibody;
    public float jumpPower = 10;
    public float jumpInterval= 0.5f;
    private float jumpCooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidibody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       //Update cooldown
       jumpCooldown -= Time.deltaTime;
       bool isGameActive = GameManager.Instance.IsGameActive();
       bool canJump = jumpCooldown <= 0 && isGameActive;

       //Jump!
       if (canJump){
        bool jumpInput = Input.GetKey(KeyCode.Space);
        if (jumpInput){
            Jump();
        }
        //Rotation
        transform.eulerAngles = new Vector3(0,0, thisRigidibody.velocity.y * 3f);
       }

       //Toggle gravity
       thisRigidibody.useGravity = isGameActive; 
    }

    void OnCollisionEnter(Collision other) {
        OnCustomCollisionEnter(other.gameObject);
    }

    void OnTriggerEnter(Collider other) {
        OnCustomCollisionEnter(other.gameObject);
    }

    private void OnCustomCollisionEnter(GameObject other) {
        bool isSensor = other.CompareTag("Sensor");
        if(isSensor) {
            //Score!
            ScoreManager.Instance.AddPoint();
            if (ScoreManager.Instance.score == 10){
                GameManager.Instance.obstacleSpeed +=1;
                GameManager.Instance.obstacleInterval -=1;
            }
            if (ScoreManager.Instance.score == 30){
                GameManager.Instance.obstacleSpeed +=1;
            }
        } else {
            //Game Over!
            GameManager.Instance.EndGame();
        }
    }
    private void Jump(){
        //Reset cooldown
        jumpCooldown = jumpInterval;

        //Apply force
        thisRigidibody.velocity = Vector3.zero;
        thisRigidibody.AddForce(new Vector3(0, jumpPower,0), ForceMode.Impulse);
    }
}
