using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PointHolder : HieuMonoBehaviour
{
    [SerializeField] protected List<Point> points;
    public List<Point> Points => points;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }
    protected virtual void LoadPoints()
    {
        if (this.points.Count > 0) return;
        this.points = transform.GetComponentsInChildren<Point>().ToList();
    }
}
