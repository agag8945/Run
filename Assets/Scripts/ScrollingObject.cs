using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f; // 이동 속도

    // Update is called once per frame
    void Update()
    {
        // 게임 오버가 아니라면
        if (!GameManager.instance.isGameOver)
        {
             transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
