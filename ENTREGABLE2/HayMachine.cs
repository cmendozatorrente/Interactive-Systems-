using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public float movementSpeed;
    public float horizontalBoundary = 22;

    public GameObject hayBalePrefab; // Referencia al prefabricado de pacas de heno.
    public Transform haySpawnpoint; // El punto desde el que se disparará el heno.
    public float shootInterval; // El intervalo más pequeño entre disparos
    private float shootTimer; // Un temporizador para mantener el control de si la máquina puede disparar o no

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateShooting();
    }

    void UpdateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        
        if(horizontalInput < 0) // <-
        {
            transform.Translate(transform.right * (-1)* Time.deltaTime * movementSpeed);
        }
        else if(horizontalInput > 0) // ->
        {
            transform.Translate(transform.right * Time.deltaTime * movementSpeed);
        }
    }

    private void UpdateShooting() 
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space)) 
        {
            shootTimer = shootInterval;
            ShootHay(); 
        }
    }

    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
    }
}
