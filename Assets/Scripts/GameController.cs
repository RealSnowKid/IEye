using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject winScore;
    // Start is called before the first frame update
    void Start()
    {
        winScore.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckingFunction.locked)
        {
            winScore.SetActive(true);
        }
    }
}
