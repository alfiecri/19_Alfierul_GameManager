using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterScript : MonoBehaviour
{
    float speed = 10;
    int energyCount = 25;

    public GameObject energyDisplay;
    public Rigidbody PlayerRgb;
    public Animator PlayerAnim;

    public GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        this.enabled = true;
        energyDisplay.GetComponent<Text>().text = "Energy: " + energyCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (energyCount < 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
        if (energyCount >= 50)
        {
            SceneManager.LoadScene("WinScene");
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            PlayerAnim.SetBool("isWalk", true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            PlayerAnim.SetBool("isWalk", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 270, 0);
            PlayerAnim.SetBool("isWalk", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            PlayerAnim.SetBool("isWalk", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            PlayerAnim.SetBool("isWalk", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            PlayerAnim.SetBool("isWalk", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            PlayerAnim.SetBool("isWalk", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            PlayerAnim.SetBool("isWalk", false);
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("AddEnergyPrefab"))
        {
            Destroy(other.gameObject);
            energyCount += 5;
            energyDisplay.GetComponent<Text>().text = "Energy: " + energyCount;

            FindObjectOfType<GameManager>().addTime();


        }
        if (other.collider.CompareTag("MinusEnergyPrefab"))
        {
            Destroy(other.gameObject);
            energyCount -= 25;
            energyDisplay.GetComponent<Text>().text = "Energy: " + energyCount;
        }
    }
}
