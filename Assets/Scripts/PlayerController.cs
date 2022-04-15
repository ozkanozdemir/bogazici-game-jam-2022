using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpAmount = 10f;

    private Rigidbody2D _rigidbody;

    private Vector3 _velocity;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += _velocity * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && Mathf.Approximately(_rigidbody.velocity.y, 0))
        {
            _rigidbody.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);   
        }
    }
}
