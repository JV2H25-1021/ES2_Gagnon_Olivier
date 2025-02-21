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
   [SerializeField] private float _modifierAnimTranslation;
   [SerializeField] private float _vitesseSubmarine;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        
    }
    void OnMouvement(InputValue direction)
    {
        Vector2 directionAvecVitesse = direction.Get<Vector2>() * _vitesseSubmarine;
        directionInput = new Vector3(0f, directionAvecVitesse.y, directionAvecVitesse.x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Vector3 mouvement = directionInput;

        _rb.AddForce(mouvement, ForceMode.VelocityChange);
        Vector3 vitesseSurPlane = new Vector3(0f, _rb.velocity.y, _rb.velocity.x);

        _animator.SetFloat("Vitesse", vitesseSurPlane.magnitude * _modifierAnimTranslation);
        _animator.SetFloat("Deplacement", vitesseSurPlane.magnitude);


    }
}
