using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class SerchPath : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    [SerializeField] private List<Transform> _childPath;

    [SerializeField] private List<float> _dist; // список дистанции точек
    [SerializeField] private float _minStep;

    [SerializeField] private List<Transform> _pointsForMove;

    [SerializeField] private Transform _target;


    private void Start() => HeshPoint();
    private void FixedUpdate()
    {
        Transform Point = SearchDistance();
        Debug.Log(Point);
    }

    private Transform SearchDistance()
    {
        float distance;
        int i = 0;
        for (; i < _childPath.Count; i++)
        {
            distance = Vector3.Distance(_childPath[i].transform.position, transform.position);
            _dist.Add(distance);
            distance = _dist.Min();

            if (distance <= _minStep && _childPath[i].GetComponent<Point>().IsMovebl == true)
            {
                _childPath[i].GetComponent<Point>().SpriteRenderer.color = Color.green;
                _pointsForMove.Add(_childPath[i]);
                _dist.Clear();
                break;
            }
            else
            {
                for (int j = 0; j < _pointsForMove.Count; j++) 
                    _pointsForMove[j].GetComponent<Point>().SpriteRenderer.color = Color.white;

                _pointsForMove.Clear();
            }

        }
        return _childPath[i];
    }

    private void HeshPoint()
    {
        for (int i = 0; i < _path.childCount; i++) _childPath.Add(_path.GetChild(i));
    }
}
