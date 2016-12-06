using UnityEngine;
using System.Collections;

public class BirdMotions : MonoBehaviour {

	public float _gravity = 4;
	public float _jumpPower = 2.5f;
	public float _horizantalSpeed = 1.5f;
	public float _verticalSpeed = 0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		_verticalSpeed -= _gravity * Time.deltaTime;
		if (Input.GetButton("Jump")) {
			_verticalSpeed = _jumpPower;
		}
		float _slope = 90 * _verticalSpeed / _horizantalSpeed;

		if (_slope <= -50) {
			_slope = -50;
		}
		else if (_slope > 50) {
			_slope = 50;
		}
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, _slope);
		transform.Translate (new Vector3 (0f, _verticalSpeed, 0f)*Time.deltaTime,Space.World);
		transform.parent.Translate( _horizantalSpeed * Time.deltaTime, 0, 0 );
	}

	void OnTriggerEnter2D(Collider2D _col){
		//Application.LoadLevel (0);
		Debug.Log("U'r Dead");

		Destroy (this);
	}
}
