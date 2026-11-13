using UnityEngine;

public class Lantern : MonoBehaviour
{
    [Header("회전 및 부유 속도")]
    [SerializeField] private float rotateSpeed = 20f;  
    [SerializeField] private float floatSpeed = 1.5f;  
    [SerializeField] private float floatAmount = 0.15f; 

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

       
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatAmount;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}