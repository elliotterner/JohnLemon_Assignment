using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Text;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    public string textValue;
    public Text textElement;

    void Start ()
    {
        textElement.text = "";
        m_Animator = GetComponent<Animator> ();
        m_Rigidbody = GetComponent<Rigidbody> ();
        m_AudioSource = GetComponent<AudioSource> ();
    }

    void FixedUpdate ()
    {
        Vector3 wrongWay = new Vector3(-1.0f,0.0f,0.0f);
        Vector3 playerPos = transform.position;
        Vector3 pos = new Vector3(playerPos.x + 9.8f, playerPos.y, playerPos.z + 3.2f);
        pos.Normalize();

        float angle = Mathf.Acos(Vector3.Dot(wrongWay, pos));
        Debug.Log(pos);
        Debug.Log(wrongWay);
        Debug.Log(angle);

        if(angle < 1 && angle > 0){
            textElement.text = "Wrong Way! Try a different Direction";
        } else{
            textElement.text = "";
        }
        

        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");
        


        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool ("IsWalking", isWalking);
        
        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop ();
        }

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);
    }

    void OnAnimatorMove ()
    {
        float alpha = UnityEngine.Random.Range(0,2);
        
        //max is 2 min is 0
        float lerpSpeedMultiplier = (1.0f - alpha) * 0.0f  + alpha * 2;
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude * lerpSpeedMultiplier);
        m_Rigidbody.MoveRotation (m_Rotation);
    }
}