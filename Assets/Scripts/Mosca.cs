using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mosca : MonoBehaviour
{
    Vector3 initialPosition;
    public bool hasKey;
    public int livesCount = 3;
    public TextMeshProUGUI txtlives;
    public int ScorePoint = 0;
    public TextMeshProUGUI txtscore;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        txtlives.text = livesCount.ToString();
        txtscore.text = ScorePoint.ToString();
    }

    private void Update()
    {
        if (hasKey)
        {
            Debug.Log("Tiene la llave");
        }
    }


    //Destruir la mosca si colisiona con el ventilador
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            LoseALife();
        } else if (collision.gameObject.CompareTag( "Moneda"))
        {

            PickACoin();
            Destroy(collision.gameObject);
        } 
    }
    void PickACoin()
    {
        ScorePoint++;
        txtscore.text = ScorePoint.ToString();
        if (ScorePoint == 3)
        {
            Debug.Log("Felicidades, Ganaste");
            Destroy(gameObject);
        }
    }
    void LoseALife()
    {
        transform.position = initialPosition;
        livesCount--;
        txtlives.text = livesCount.ToString();
        if (livesCount == 0)
        {
            PlayerDeath();
        }
    }
    void PlayerDeath()
    {
            Destroy(gameObject);
        //reproducir un sonido
        //ejecutar una animacion
        //etc
    }
}
