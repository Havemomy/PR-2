using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineApp {
    class LineDatabase {
        private Random _random = new Random();
        private int RandomInt { get => _random.Next(-99, 99);}

        public List<Line> Lines { get; private set; }

        public void Initialize() {
            Lines = new List<Line>() {
                new Line(RandomInt, RandomInt, RandomInt, RandomInt),
                new Line(RandomInt, RandomInt, RandomInt, RandomInt),
                new Line(RandomInt, RandomInt, RandomInt, RandomInt),
                new Line(RandomInt, RandomInt, RandomInt, RandomInt),
                new Line(RandomInt, RandomInt, RandomInt, RandomInt),
                new Line(RandomInt, RandomInt, RandomInt, RandomInt),
                new Line(RandomInt, RandomInt, RandomInt, RandomInt),
                new Line(RandomInt, RandomInt, RandomInt, RandomInt),
                new Line(RandomInt, RandomInt, RandomInt, RandomInt)
            };
        }
    }
}
