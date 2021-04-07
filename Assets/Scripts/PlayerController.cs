using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CameraController cameraController;
    [SerializeField] GameController gameController;

    private Rigidbody rb;
    private bool canMove = true;
    private float playerPos = 0;
    private float startPlayerPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameController.endGameEvent += Die;
        startPlayerPos = transform.position.z;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            gameController.endGameEvent.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            gameController.coin++;
            Destroy(other.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Move();
            gameController.score = transform.position.z - startPlayerPos;
        }
    }

    void Move()
    {
        rb.velocity = Vector3.forward * 10f;

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            playerPos = transform.position.x;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 10f));
            rb.MovePosition(new Vector3(Mathf.Lerp(rb.position.x, Mathf.Clamp(mousePos.x, -4f, 4f), 5f * Time.deltaTime), rb.position.y, rb.position.z));
        }
#endif
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 10f));

            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    playerPos = transform.position.x;
                    break;
                case TouchPhase.Moved:
                    rb.MovePosition(new Vector3(Mathf.Lerp(rb.position.x, Mathf.Clamp(mousePos.x, -4f, 4f), 5f * Time.deltaTime), rb.position.y, rb.position.z));
                    break;
                case TouchPhase.Stationary:
                    rb.MovePosition(new Vector3(Mathf.Lerp(rb.position.x, Mathf.Clamp(mousePos.x, -4f, 4f), 5f * Time.deltaTime), rb.position.y, rb.position.z));
                    break;
            }
        }
#endif
    }

    void Die()
    {
        rb.velocity = Vector3.zero;
        canMove = false;
        cameraController.followCam = false;
    }
}
