using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Variables
    private float _horizontal;
    private float _vertical;
    [SerializeField] private Vector2 levelMarginX;
    [SerializeField] private Vector2 levelMarginY;

    private float _horizontalMouse;
    private float _verticalMouse;
    private float _screenWidth;
    private float _screenHeight;

    private Vector3 _movement = Vector3.zero;
    private float _cameraSpeed = 15f;
    private float _marge = 30f;
    #endregion

    #region Properties
    #endregion

    #region Built in Methods
    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _horizontalMouse = Input.mousePosition.x;
        _verticalMouse=  Input.mousePosition.y;

        _screenWidth = Screen.width;
        _screenHeight = Screen.height;

        _movement = Vector3.zero;

        
        if (transform.position.x < levelMarginX.x){
            Vector3 newPos = new Vector3(levelMarginX.x, transform.position.y, transform.position.z);
            transform.position = newPos;
        }
        else if (transform.position.x > levelMarginX.y){
            Vector3 newPos = new Vector3(levelMarginX.y, transform.position.y, transform.position.z);
            transform.position = newPos;
        }
        if (transform.position.z < levelMarginY.x){
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, levelMarginY.x);
            transform.position = newPos;
        }
        else if (transform.position.z > levelMarginY.y){
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, levelMarginY.y);
            transform.position = newPos;
        }

        if (_horizontal != 0 || _vertical != 0){
            _movement.Set(_horizontal, 0, _vertical);
        }
        else{
            if (_horizontalMouse < _marge){
                _movement.Set(-1, 0, _movement.z);
            }
            else if (_horizontalMouse > _screenWidth - _marge){
                _movement.Set(1, 0, _movement.z);
            }
            if (_verticalMouse < _marge){
                _movement.Set(_movement.x, 0, -1);
            }
            else if(_verticalMouse > _screenHeight - _marge){
                _movement.Set(_movement.x, 0, 1);
            }


        }

        transform.Translate(_movement * Time.deltaTime * _cameraSpeed);
    }
    #endregion

    #region Custom Methods
    #endregion
}
