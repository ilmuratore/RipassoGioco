using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

[RequireComponent(typeof(Rigidbody2D))] // attributi di unity
[RequireComponent(typeof(Animator))] //GameObject che non ha rigidBody unity lo aggiunge da solo.
public class PlayerMovement : MonoBehaviour
{

    [Header("Movimento")] // i campi che visualizzo nell'ispector di unity 
    [SerializeField] private float velocita = 1f; //campo modificabile 

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 inputMovimento;
    private Vector2 ultimaDirezione = new Vector2(0, -1);

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMove(InputValue value)
    {
        inputMovimento = value.Get<Vector2>();
    }


    //Aggiorna 50 volte al secondo
    private void FixedUpdate()
    {
        rb.linearVelocity = inputMovimento * velocita;
        AggiornaAnimazioni();
    }

    private void AggiornaAnimazioni()
    {
        if(inputMovimento != Vector2.zero)
        {
            ultimaDirezione = inputMovimento;
        }

        Vector2 direzioneAnimazione = Vector2.zero;
        if(inputMovimento != Vector2.zero)
        {
            if(Mathf.Abs(inputMovimento.x) >= MathF.Abs(inputMovimento.y))
            {
                direzioneAnimazione = new Vector2(inputMovimento.x, 0);
            } else
            {
                direzioneAnimazione = new Vector2(0, inputMovimento.y);
            }
        }

        animator.SetFloat("MoveX", inputMovimento.x);
        animator.SetFloat("MoveY", inputMovimento.y);
        animator.SetFloat("LastMoveX", ultimaDirezione.x);
        animator.SetFloat("LastMoveY", ultimaDirezione.y);
        animator.SetBool("IsMoving", inputMovimento != Vector2.zero);
    }
}
