//referenced: https://hub.packtpub.com/simple-player-health/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float mSpeed = 10;
    public float tSpeed = 60;
    public Text currHLabel;
    public CapsuleCollider collider;
    public int maxH = 20;
    public int pHealth;

    private float deathCount;
    private float deathMax;

    private GameObject label;

    void Start()
    {
        pHealth = maxH;
        UpdateGUI();
        deathMax = 2f;
        deathCount = 0f;
        label = GameObject.FindGameObjectWithTag("death");
        label.SetActive(false);
    }


    public void Damage()
    {
        pHealth--;
        Debug.Log("Take Damage");
        UpdateGUI();
    }

    void Update()
    {
        if(this.gameObject.transform.position.y < -20)
        {
            label.SetActive(true);
            deathCount += Time.deltaTime;
            if (deathCount >= deathMax)
            {
                SceneManager.LoadScene(0);
                label.SetActive(false);
            }           
        }
        float horizontal = Input.GetAxis("Horizontal") * tSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Vertical") * mSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);

        print(pHealth);

        if (pHealth <= 0)
        {
            label.SetActive(true);
            deathCount += Time.deltaTime;
            if(deathCount >= deathMax)
            {
                SceneManager.LoadScene(0);
                label.SetActive(false);
            }
        }
    }

    void UpdateGUI()
    {
        currHLabel.text = pHealth.ToString();
    }

    public void AlterHealth(int amount)
    {
       pHealth += amount;
       pHealth = Mathf.Clamp(pHealth, 0, maxH);
       UpdateGUI();
     }
}

