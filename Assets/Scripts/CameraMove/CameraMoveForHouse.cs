using System;
using UnityEngine;

public class CameraMoveForHouse : MonoBehaviour
{
    [SerializeField] private CatMove _catMove;
    private Camera _cam;
    private Vector3 _touch;
    private void Start() => _cam = Camera.main;
    void Update()
    {
        //if (BowlUse.UseBowl == true) return;
        if(_catMove.IsTake == false) CamMove();
        else CatCamMove();
    }

    private void CamMove()
    {
        if (Input.GetMouseButtonDown(0)) _touch = _cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = _touch - _cam.ScreenToWorldPoint(Input.mousePosition);
            _cam.transform.position = new Vector3(Math.Clamp(_cam.transform.position.x + direction.x, -17.8f, 17.8f),
                 Math.Clamp(_cam.transform.position.y + direction.y, 0, 0), -10);
        }
    }

    private void CatCamMove()
    {
        _touch = _cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = _touch - _cam.ScreenToWorldPoint(Input.mousePosition);
        _cam.transform.position = new Vector3(Math.Clamp(_cam.transform.position.x + direction.x, -17.8f, 17.8f),
             Math.Clamp(_cam.transform.position.y + direction.y, 0, 0), -10);

    }
}
