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
        _animator.SetFloat("DeplacementZ", directionInput.magnitude);
     

    }

    void FixedUpdate()
    {
        Vector3 Mouvement = directionInput;

        _rb.AddForce(Mouvement, ForceMode.VelocityChange);
        Vector3 vitesseSurPlane = new Vector3(0f, _rb.velocity.y, _rb.velocity.x);
        _animator.SetFloat("DeplacementY", vitesseSurPlane.magnitude);

        AnimationHelice();
    }
    void OnAccelerer(InputValue bouton)
    {
        if (bouton.isPressed)
        {
            _vitesseSubmarine = 2f;
            _animator.SetFloat("Helice", 2f);


        }
        else
        {
            _vitesseSubmarine = 1f;
            _animator.SetFloat("Helice", 1f);

        }


    }
    void AnimationHelice()
    {
        if (directionInput.z < 0)
        {
            sensInverse = true;
        }
        else
        {
            sensInverse = false;
        }
        if (sensInverse)
        {
            _animator.SetFloat("Helice", -1f);
        }
        else
        {
            _animator.SetFloat("Helice", 1f);

        }
    }
    }
