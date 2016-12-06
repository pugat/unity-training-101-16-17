using UnityEngine;
using System.Collections;

public class BirdAnimation : MonoBehaviour {

	public int _framePerSecond = 10;
	public Sprite[] _animations;

	float _afterAnimationTime;
	bool _animationDirection = true;
	int _activeAnimation = 0;


	// Use this for initialization
	void Start () {
		if (_animations.Length < 2) {
			Destroy (this);
		}
		_afterAnimationTime = Time.time + 1f / _framePerSecond;
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time >= _afterAnimationTime) {
			if (_animationDirection) {
				if (_activeAnimation == _animations.Length - 1) {
					_activeAnimation--;
					_animationDirection = false;
				} else {
					_activeAnimation++;
				}
			} else {
				if (_activeAnimation == 0) {
					_activeAnimation++;
					_animationDirection = true;
				} else {
					_activeAnimation--;
				}
			}
				
			GetComponent<SpriteRenderer>().sprite = _animations[_activeAnimation];
			_afterAnimationTime = Time.time + 1f / _framePerSecond;

		}
	}
}
