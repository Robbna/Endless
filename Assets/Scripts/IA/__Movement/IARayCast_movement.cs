using UnityEngine;

public class IARayCast_movement : MonoBehaviour
{
    [SerializeField] private float speed;
    private IARayCast rayCastIA;

    private void Start() {
        rayCastIA = GetComponent<IARayCast>();
    }
    void Update()
    {
        if (rayCastIA.isLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (rayCastIA.isRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
