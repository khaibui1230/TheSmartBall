using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint; // khoi tao mot bien focalPoint bang game Object
    // the value of powerUp
    private float powerUpStrangth = 15;
    public float speed = 5f;
    public bool hasPowerup = false;
    public GameObject powerupIndicator;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // gan playerRB cho Rigibody -> giup co the tuong tac voi rigibody
        focalPoint = GameObject.Find("Focal Point"); // gan focal point cho scenes Focal Point
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical"); // di chuyen toi lui theo truc doc
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);// gan luc cho doi tuong duoc xac dinh huong luc theo focalPoint va
                                                                               // tuong tac theo truc forwardInput
        powerupIndicator.transform.position =  transform.position - new Vector3( 0, -0.32f, 0 );
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true); //active gia tri powerup Indicator
        }
    }

    // Dem nguoc thoi gian de huy bo hasPowerup
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        // dem nguoc 7s va thuc hien hanh dong tiep theo
        powerupIndicator.gameObject.SetActive(false) ; // ne
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            // creat a value use the Rigidbody to use
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrangth, ForceMode.Impulse);
            Debug.Log("Hi");
        }
    }
}
