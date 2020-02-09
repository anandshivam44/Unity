using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class player_controller : MonoBehaviour
{
    private Rigidbody rb;
    public float speed=5;
    public TextMeshProUGUI tmptext;

    int count;
     void Start() {
        rb=GetComponent<Rigidbody>();
        tmptext=FindObjectOfType<TextMeshProUGUI>();
        count=0;
        settmptext();
    }
    void FixedUpdate() {
        float moveHorizontal=Input.GetAxis("Horizontal");
        float moveVertical=Input.GetAxis("Vertical");
        Vector3 movement=new Vector3(moveVertical,0.0f,-1*moveHorizontal);
        rb.AddForce(movement*speed);
    }
    void OnTriggerEnter(Collider other) {
        Debug.Log("Inside trigger function");
        if(other.gameObject.CompareTag("pick-up")){
            Debug.Log("Trigger Active");
            other.gameObject.SetActive(false);
            count++;
            settmptext();
        }
    }
    public void settmptext(){
        tmptext.text=count.ToString();
        Debug.Log("Entered TMP");
    }
    public void ChangingScene(){
        SceneManager.LoadScene(0);
    }
}
//Destroy(other.gameObject)