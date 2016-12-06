using UnityEngine;
using System.Collections;

public class Barriers : MonoBehaviour {

	public GameObject _topBarrier;
	public GameObject _bottomBarrier;
	public GameObject _skorCollider;

	public float _blank = 0.8f;
	public float _distance = 2f;

	int _barrierPiece;

	Vector2 _cameraSize;
	Vector2 _barrierSize;

	Transform[] _topBarriers;
	Transform[] _bottomBarriers;
	int _firstBarrier = 0;

	Camera _camera;

	Transform _Parent;
	// Use this for initialization
	void Start () {
		_Parent = new GameObject ().GetComponent<Transform> ();
		_Parent.name = "Barriers";
		_camera = Camera.main;
		 
		_barrierSize = new  Vector2( ( _topBarrier.GetComponent<Renderer>() as SpriteRenderer ).sprite.rect.width, ( _topBarrier.GetComponent<Renderer>() as SpriteRenderer ).sprite.rect.height ) / 100;
		_cameraSize = new  Vector2( _camera.orthographicSize * _camera.aspect, _camera.orthographicSize );

		_barrierPiece = Mathf.CeilToInt( ( _camera.orthographicSize * 2 * _camera.aspect ) / ( _barrierSize.x + _distance ) ) + 1;

		_topBarriers = new Transform[ _barrierPiece ];
		_bottomBarriers = new Transform[ _barrierPiece ];

		for( var i = 0; i < _barrierPiece; i++ )
		{
			float x = transform.position.x + _cameraSize.x + i * ( _barrierSize.x + _distance );
			float y = Random.Range( -_cameraSize.y + _blank + 0.6f, _cameraSize.y - 0.6f );

			GameObject _temp;
			_temp = Instantiate( _topBarrier, new Vector3( x, y, -1f ), Quaternion.identity ) as GameObject;
			_topBarriers [i] = _temp.transform;
			_topBarriers [i].parent = _Parent;
			_temp = Instantiate( _bottomBarrier, new Vector3( x, y - _blank, -1f ), Quaternion.identity )as GameObject;
			_bottomBarriers [i] = _temp.transform;
			_bottomBarriers [i].parent = _Parent;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x - _cameraSize.x >= _topBarriers[_firstBarrier].position.x + _barrierSize.x) {

			float y = Random.Range (-_cameraSize.y + _blank+ 0.2f, _cameraSize.y - 0.2f);

			_topBarriers [_firstBarrier].transform.Translate ((transform.localPosition.x + _barrierPiece * (_barrierSize.x + _distance)), y, 0f);
			_bottomBarriers [_firstBarrier].transform.Translate ((transform.localPosition.x + _barrierPiece * (_barrierSize.x + _distance)), y - _blank, 0f);

			_firstBarrier++;
		}
		//Debug.Log ("_cameraSize.x " + _cameraSize.x);
		//Debug.Log ("_cameraSize.y " + _cameraSize.y);

		if (_firstBarrier == _topBarriers.Length) {
			_firstBarrier = 0;
		}
	}
}
