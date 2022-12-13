using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    // Create public variables for player speed, and for the Text UI game objects
    public float speed;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI KeysText;
    public GameObject winTextObject;

    private float movementX;
    private float movementY;

    private Rigidbody rb;
    private int count;
    private int keys;

    // At the start of the game..
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();

        // Set the count to zero 
        count = 0;
        keys = 0;

        //SetCountText();

        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);
    }

    void FixedUpdate()
    {
        // Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        // ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            // Add one to the score variable 'count'
            count = count + 1;

            // Run the 'SetCountText()' function (see below)
            //SetCountText();

        }
        /*if (count > 1)
        {
            Destroy(GameObject.FindWithTag("Wall_front"));

        }*/

        if (other.gameObject.CompareTag("key_front"))
        {
            keys = keys + 1;
            //SetCountText();
            Destroy(GameObject.FindWithTag("key_front"));
            Destroy(GameObject.FindWithTag("Wall_left"));
        }
        if (other.gameObject.CompareTag("Treasure"))
        {
            SetCountText();
        }
        /*if (other.gameObject.CompareTag("key_left"))
        {
            keys = keys + 1;
            SetCountText();
            Destroy(GameObject.FindWithTag("key_left"));
            Destroy(GameObject.FindWithTag("Wall_right"));
        }
        if (other.gameObject.CompareTag("key_right"))
        {
            keys = keys + 1;
            SetCountText();
            Destroy(GameObject.FindWithTag("key_right"));
            Destroy(GameObject.FindWithTag("Wall_back"));
        }
        if (other.gameObject.CompareTag("key_back"))
        {
            keys = keys + 1;
            Destroy(GameObject.FindWithTag("key_back"));
            SetCountText();
        }*/

    }


    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;
    }

    void SetCountText()
    {
        /*countText.text = "Score: " + count.ToString();
        KeysText.text = "Keys: " + keys.ToString();
        if (keys == 4)
        {
            // Set the text value of your 'winText'*/
            winTextObject.SetActive(true);

        //}
    }
}
