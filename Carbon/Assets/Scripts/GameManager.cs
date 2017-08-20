using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject food;
    private int foodMaxCount = 10;
    private int foodCount = 0;
//     public float createTime = 3;
//     private float timer = 0;
    // Use this for initialization
	void Start () {
        for (int i = 0; i < foodMaxCount; i++)
        {
            CreateFood();
        } 
	}
	
	// Update is called once per frame
	void Update () {
//         timer += Time.deltaTime;
//         if (timer > createTime && foodCount < foodMaxCount)
//         {
//             CreateFood();
//             timer = 0;
//         }
	}

    private void CreateFood(){
        float posY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, 0)).y,
            Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height)).y);
        float posX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x,
            Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        Vector2 pos = new Vector2(posX, posY);
        GameObject go = Instantiate(food, pos, Quaternion.identity) as GameObject;
        go.transform.SetParent(transform.Find("Foods"));
        foodCount++;
    }
}
