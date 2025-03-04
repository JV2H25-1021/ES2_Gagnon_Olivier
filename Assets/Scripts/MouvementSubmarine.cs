using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;



public class MouvementSubmarine : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 directionInput;
    private Animator _animator;
   [SerializeField] private float _vitesseSubmarine;
    private bool sensInverse = false;
    private float speed = 1f;



    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
     


    }
    void OnMouvement(InputValue directionBase)
    {
        Vector2 directionAvecVitesse = directionBase.Get<Vector2>() * _vitesseSubmarine;
        directionInput = new Vector3(0f, directionAvecVitesse.y, directionAvecVitesse.x);
        if (directionInput.z < 0)
        {
            sensInverse = true;
        }
        else
        {
            sensInverse = false;
        }


    }

    void FixedUpdate()
    {
        Vector3 Mouvement = directionInput;

        _rb.AddForce(Mouvement, ForceMode.VelocityChange);
        Vector3 vitesseSurPlaneY = new Vector3(0f, _rb.velocity.y, _rb.velocity.x);
        _animator.SetFloat("DeplacementY", vitesseSurPlaneY.magnitude*speed);

        Vector3 vitesseSurPlaneZ = new Vector3(0f, _rb.velocity.x, _rb.velocity.z);
        _animator.SetFloat("DeplacementZ", vitesseSurPlaneZ.magnitude *speed);
       
      


        AnimationHeliceZ();
        AnimationHeliceY();
    }

    void AnimationHeliceZ()
    {
        if (sensInverse)
        {
            _animator.SetFloat("HeliceZ", -_vitesseSubmarine);

        }
        else
        {
            _animator.SetFloat("HeliceZ", _vitesseSubmarine);


        }
    }

    void AnimationHeliceY()
    {
        if (sensInverse)
        {
            _animator.SetFloat("HeliceY", -_vitesseSubmarine);

        }
        else
        {
            _animator.SetFloat("HeliceY", _vitesseSubmarine);


        }
    }
    void OnAccelerer(InputValue bouton)
    {
        if (bouton.isPressed)
        {
            _vitesseSubmarine = 2f;

        }
        else 
        {
            _vitesseSubmarine = 1f;

        }

    } 



    }


