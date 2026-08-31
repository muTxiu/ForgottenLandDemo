using UnityEngine;

public class Test1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 将鼠标位置从屏幕坐标转换为世界坐标
        Vector3 mouseWorldPosition = 
            Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f; // 确保Z轴为0，保持2D平面

        // 计算物体指向鼠标的方向向量
        Vector3 direction = mouseWorldPosition - transform.position;

        // 计算角度（从正X轴顺时针旋转的角度）
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 应用旋转（Z轴旋转）
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
