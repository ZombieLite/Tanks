using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, speedRotate;
    private static float horizontal, vertical;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (!Input.anyKey)
            return;

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 dirZ = new Vector3(0, 0, vertical);
        Vector3 dirX = new Vector3(0, horizontal, 0);

        if(vertical < 0)
            dirX = dirX * -1;

        dirZ = transform.TransformDirection(dirZ) * (speed * 5) * Time.fixedDeltaTime;

        Quaternion deltaRotation = Quaternion.Euler(dirX.normalized * speedRotate * Time.fixedDeltaTime);

        rb.velocity = dirZ;
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

}