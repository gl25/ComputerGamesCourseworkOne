using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{

    public int SIndex;
    private GameObject player;
    private GameObject camera;
    private GameObject label;
    private GameObject death;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        label = GameObject.FindGameObjectWithTag("Label");
        death = GameObject.FindGameObjectWithTag("death");
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Hello");
            DontDestroyOnLoad(player);
            DontDestroyOnLoad(camera);
            DontDestroyOnLoad(label);
            DontDestroyOnLoad(death);
            SceneManager.LoadScene(SIndex);
        }
    }
}
