using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    void Update()
    {

    }
	public float speed;
	public TextMesh countText;
	public TextMesh winText;
	private int count;

	void Start()
	{
		count = 0;
		setCountText ();
		winText.text = "";
	}

	void setCountText()
	{
		countText.text = "Count: " + count.ToString();
		if (count >= 5) 
		{
			winText.text = "YOU WIN!!!";
		}
	}
    void FixedUpdate() //called right before physics checks etc.
    {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);

    }

	void OnTriggerEnter (Collider other) 
	{
		if(other.gameObject.tag == "Pickup")
		{
			other.gameObject.SetActive(false);
			count += 1;
			setCountText();
		}

	}



}
