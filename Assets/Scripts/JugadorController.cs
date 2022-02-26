using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class JugadorController : MonoBehaviour
{

    //Declaro la variable de tipo RigidBody que luego asociaremos a nuestro jugador
    private Rigidbody rb;

    private int contador;
    public float velocidad;
    public Text textContador, textoGanar;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        contador = 0;
        setTextoContador();
        textoGanar.text = "";
    }
    //Para que se sincronice con los frames de fisica del motor
    void FixedUpdate()
    {
        //Estar variables nos capturan el movimiento en horizontal y vertical de nuestro teclado
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        //Un vector3 es un trio de posiciones en el espacio XYZ, en este caso el que corresponde al movimiento
        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);

        //Asigno ese movimiento o desplazamiento a mi RigidBody
        rb.AddForce(movimiento * velocidad);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collecionable"))
        {
            other.gameObject.SetActive(false);
            contador++;
            setTextoContador();
        }
        else if (other.gameObject.CompareTag("Death"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // Application.LoadLevel(Application.loadedLevel);
        }
    }

    void setTextoContador()
    {
        textContador.text = "Contador: " + contador.ToString();
        if (contador >= 12)
        {
            textoGanar.text = "!Ganaste!";
        }
    }
}
