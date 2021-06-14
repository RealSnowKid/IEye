using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingFunction8 : MonoBehaviour
{
    [SerializeField]
    private Transform EyeTermNinth;
    private Vector2 intialPosition;
    private float deltaX, deltaY;
    public static bool locked;

    // Start is called before the first frame update
    void Start()
    {
        intialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch(touch.phase)
            {
                case TouchPhase.Began:
                    if(GetComponent<Collider2D>()==Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }
                    break;

                case TouchPhase.Moved:
                    if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    }
                    break;
                case TouchPhase.Ended:
                    if(Mathf.Abs(transform.position.x-EyeTermNinth.position.x)<=0.5f &&
                        Mathf.Abs(transform.position.y - EyeTermNinth.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(EyeTermNinth.position.x, EyeTermNinth.position.y);
                        locked = true;
                    }
                    else
                    {
                        transform.position = new Vector2(intialPosition.x, intialPosition.y);
                    }
                    break;
            }

        }
    }
}
