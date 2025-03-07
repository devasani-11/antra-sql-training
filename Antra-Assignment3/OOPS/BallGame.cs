using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{

    public class BallGame
    {
        public class Color
        {
            private int _red, _green, _blue, _alpha;

            public Color(int red, int green, int blue, int alpha)
            {
                _red = ValidateColorValue(red);
                _green = ValidateColorValue(green);
                _blue = ValidateColorValue(blue);
                _alpha = ValidateColorValue(alpha);
            }

            public Color(int red, int green, int blue) : this(red, green, blue, 255) { }

            public int Red
            {
                get { return _red; }
                set { _red = ValidateColorValue(value); }
            }

            public int Green
            {
                get { return _green; }
                set { _green = ValidateColorValue(value); }
            }

            public int Blue
            {
                get { return _blue; }
                set { _blue = ValidateColorValue(value); }
            }

            public int Alpha
            {
                get { return _alpha; }
                set { _alpha = ValidateColorValue(value); }
            }

            public int GetGrayscale()
            {
                return (_red + _green + _blue) / 3;
            }

            private int ValidateColorValue(int value)
            {
                if (value < 0) return 0;
                if (value > 255) return 255;
                return value;
            }
        }

        public class Ball
        {
            private int _size;
            private Color _color;
            private int _throwCount;
            private bool _isPopped;

            public Ball(int size, Color color)
            {
                _size = size > 0 ? size : 1;
                _color = color;
                _throwCount = 0;
                _isPopped = false;
            }

            public void Pop()
            {
                _size = 0;
                _isPopped = true;
            }

            public void Throw()
            {
                if (!_isPopped)
                {
                    _throwCount++;
                }
            }

            public int GetThrowCount()
            {
                return _throwCount;
            }
        }

        public static void Game()
        {
            Color redColor = new Color(255, 0, 0);
            Color blueColor = new Color(0, 0, 255, 200);

            Ball ball1 = new Ball(10, redColor);
            Ball ball2 = new Ball(15, blueColor);

            ball1.Throw();
            ball1.Throw();
            ball2.Throw();

            ball1.Pop();
            ball1.Throw();

            Console.WriteLine($"Ball 1 throw count: {ball1.GetThrowCount()}");
            Console.WriteLine($"Ball 2 throw count: {ball2.GetThrowCount()}");

            Console.WriteLine($"Red Color Grayscale Value: {redColor.GetGrayscale()}");
            Console.WriteLine($"Blue Color Grayscale Value: {blueColor.GetGrayscale()}");
        }
    }
}
