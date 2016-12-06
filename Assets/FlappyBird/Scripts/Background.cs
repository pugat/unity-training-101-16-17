using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public GameObject _sky;
	public GameObject _land;

	public int _backgroundPiece;

	public Vector2 _cameraSize;
	public Vector2 _skySize;
	public Vector2 _landSize;

	Transform[] _skyObjects;
	Transform[] _landObjects;
	int _firstSky = 0;
	int _firstLand = 0;

	Transform _Parent;

	// Use this for initialization
	void Start () {

		Camera _cam = Camera.main;

		_skySize = new Vector2 (2.88f, 4.14f);
		_landSize = new Vector2 (2.88f, 0.32f);

		_cam.orthographicSize = ( _skySize.y + _landSize.y ) / 2;
		_backgroundPiece = Mathf.CeilToInt( ( _cam.orthographicSize * 2 * _cam.aspect ) / _skySize.x ) + 1;

		_cameraSize = new Vector2( _cam.orthographicSize * _cam.aspect, _cam.orthographicSize );

		_skyObjects = new Transform[_backgroundPiece];
		_landObjects = new Transform[_backgroundPiece];

		_Parent = new GameObject ().GetComponent<Transform> ();
		_Parent.name = "Background";

		for( int i = 0; i < _backgroundPiece; i++ )
		{
			float x  = transform.position.x - _cameraSize.x + i * _skySize.x;
			GameObject _temp;
			_temp = Instantiate (_sky, new Vector3 (x, _cameraSize.y, 0f), Quaternion.identity)as GameObject;
			_skyObjects [i] = _temp.transform;
			_skyObjects [i].parent = _Parent;

			_temp = Instantiate (_land, new Vector3 (x, _cameraSize.y- _skySize.y, 0f), Quaternion.identity)as GameObject;
			_landObjects [i] = _temp.transform;
			_landObjects [i].parent = _Parent;
		}

	}

	void Update () {
		
		if( transform.position.x - _cameraSize.x >= _skyObjects[_firstSky].position.x + _skySize.x )
		{
			_skyObjects [_firstSky].transform.Translate (transform.localPosition.x + _backgroundPiece * _skySize.x, 0f, 0f);
			_firstSky++;

			if( _firstSky == _skyObjects.Length )
				_firstSky = 0;
		}

		if( transform.position.x - _cameraSize.x >= _landObjects[_firstLand].position.x + _landSize.x )
		{
			_landObjects [_firstLand].transform.Translate (transform.localPosition.x + _backgroundPiece * _landSize.x, 0f, 0f);
			_firstLand++;

			if( _firstLand == _landObjects.Length )
				_firstLand = 0;
		}
			
		//_Parent.transform.Translate (transform.position.x + 1f * Time.deltaTime, 0f, 0f);
	}
}
