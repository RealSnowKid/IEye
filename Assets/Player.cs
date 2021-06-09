using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public int health;
    public bool isAlive;

    public Sprite[] healthImg;
    public GameObject healthHolder;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth();
        PlayerDie();           
    }

    public void DoDamage(int damage)
    {
        health -= damage;
    }


    public void PlayerDie()
    {
        if(health <= 0)
        {
            isAlive = false;
        }
    }

    private void CurrentHealth()
    {
        healthHolder.GetComponent<Image>().sprite = healthImg[health];    
    }

}
