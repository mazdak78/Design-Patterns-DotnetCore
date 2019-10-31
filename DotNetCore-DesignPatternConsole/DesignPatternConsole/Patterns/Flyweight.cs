using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternConsole.Flyweight
{
    public enum ShapeType
    {
        Rectangle,
        Circle
    }

    public interface IShape
    {
        ShapeType ShapeType { get; } //Intrinsic
        void DrawShape(); //Extrinsic, can accept parameters to draw the shape
    }

    public class Circle : IShape
    {
        public ShapeType ShapeType
        {
            get { return ShapeType.Circle; }
        }

        public void DrawShape() 
        {
            
            Console.WriteLine("Drawing Circle");
        }
    }

    public class Rectangle : IShape
    {
        public ShapeType ShapeType
        {
            get { return ShapeType.Rectangle; }
        }

        public void DrawShape()
        {

            Console.WriteLine("Drawing Rectangle");
        }
    }

    public class ShapeFactory
    {
        public int ObjectsCount = 0;
        private Dictionary<ShapeType, IShape> _shapeObjects;

        public IShape GetShapeToDisplay(ShapeType _type) 
        {
            if (_shapeObjects == null)
                _shapeObjects = new Dictionary<ShapeType, IShape>();
            if (_shapeObjects.ContainsKey(_type))
                return _shapeObjects[_type];
            switch (_type)
            {
                case ShapeType.Circle:
                    _shapeObjects.Add(_type, new Circle());
                    ObjectsCount++;
                    break;
                case ShapeType.Rectangle:
                    _shapeObjects.Add(_type, new Rectangle());
                    ObjectsCount++;
                    break;
                default:
                    break;
            }
            return _shapeObjects[_type];
        }
    }
}
