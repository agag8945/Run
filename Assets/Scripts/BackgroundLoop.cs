using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundLoop : MonoBehaviour
{
    private float width;  // 배경의 너비

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        // BoxCollider2D 컴포넌트의 Size 필드의 x값을 가로 너비로 사용
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        width = boxCollider.size.x;

    }

    // Update is called once per frame
    void Update()
    {
        // 현재 위치가 원점에서 왼쪽으로 width 이상 이동했을 때 위치를 리셋
        if (transform.position.x <= -width)
        {
            Reposition();
        }
    }
    
    private void Reposition()
    {
        // 현재 위치에서 오른쪽으로 가로너비 * 2만큼 이동
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
