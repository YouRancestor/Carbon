using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public GameObject food;
    private int[,] dir;

    void Start()
    {
        dir = new int[8, 2] { { 1, 1 }, { 1, 0 }, { 1, -1 }, { 0, -1 }, { -1, -1 }, { -1, 0 }, { -1, 1 }, { 0, 1 } };
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Player player = coll.gameObject.GetComponent<Player>();
            if (player.Volume >= .5f)
            {
                 player.ReduceQuality(2);
                 for (int i = 0; i < 8; i++)
                 {
                     Vector2 pos = new Vector2(coll.gameObject.transform.position.x + dir[i,0], coll.gameObject.transform.position.y + dir[i,1]);
                     GameObject go = Instantiate(food, pos, Quaternion.identity) as GameObject;
                     go.GetComponent<Rigidbody2D>().velocity = new Vector2(dir[i,0], dir[i,1]);
                 }
            }
            else
            {
                Destroy(coll.gameObject);
                for (int i = 0; i < 8; i++)
                {
                    Vector2 pos = new Vector2(coll.gameObject.transform.position.x + dir[i, 0], coll.gameObject.transform.position.y + dir[i, 1]);
                    GameObject go = Instantiate(food, pos, Quaternion.identity) as GameObject;
                    go.GetComponent<Rigidbody2D>().velocity = new Vector2(dir[i, 0], dir[i, 1]);
                }
            }
        }
        Destroy(this.gameObject);
    }
}
