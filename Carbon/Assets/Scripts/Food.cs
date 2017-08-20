using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CheckBoder();
	}

    private void CheckBoder()
    {
        Vector3 PlayerPosition;
        if (transform.position.y > Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height)).y)
        {
            PlayerPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, 0));
            PlayerPosition.x = transform.position.x;
            PlayerPosition.z = 0;
            transform.position = PlayerPosition;
        }
        if (transform.position.y < Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, 0)).y)
        {
            PlayerPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height));
            PlayerPosition.x = transform.position.x;
            PlayerPosition.z = 0;
            transform.position = PlayerPosition;
        }
        if (transform.position.x > Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 2)).x)
        {
            PlayerPosition = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height / 2));
            PlayerPosition.y = transform.position.y;
            PlayerPosition.z = 0;
            transform.position = PlayerPosition;
        }
        if (transform.position.x < Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height / 2)).x)
        {
            PlayerPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 2));
            PlayerPosition.y = transform.position.y;
            PlayerPosition.z = 0;
            transform.position = PlayerPosition;
        }
    }
}
