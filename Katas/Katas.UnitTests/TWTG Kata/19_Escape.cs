namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static string[] Escape(int[,] carPark)
    {
        return new CarPark(carPark).GoExit();
    }

    public class CarPark
    {
        private readonly List<string> _drivingPath = new();
        private readonly List<Floor> _floors = new();

        public CarPark(int[,] carPark)
        {
            for (var i = 0; i < carPark.GetLength(0); i++)
            {
                var floor = new Floor();

                for (var j = 0; j < carPark.GetLength(1); j++)
                {
                    if (carPark[i, j] == 2)
                    {
                        Locate = (i, j);
                    }

                    floor.Add(carPark[i, j]);
                }

                _floors.Add(floor);
            }
        }

        private (int Floor, int Index) Locate { get; set; }
        private Floor CurrentFloor => _floors[Locate.Floor];
        private Slot CurrentSlot => CurrentFloor[Locate.Index];
        private bool IsGroundFloor => Locate.Floor == _floors.Count - 1;
        private bool IsExit => IsGroundFloor && Locate.Index == CurrentFloor.Count - 1;

        public string[] GoExit()
        {
            while (!IsExit)
            {
                var step = IsGroundFloor
                    ? CurrentFloor.Count - Locate.Index - 1
                    : CurrentFloor.IndexOf(Slot.Staircase) - Locate.Index;

                if (step != 0)
                {
                    MoveSameFloor(step);
                }
                else
                {
                    MoveDownstairs();
                }
            }

            return _drivingPath.ToArray();
        }

        private void MoveSameFloor(int step)
        {
            _drivingPath.Add(step < 0
                ? "L" + -step
                : "R" + step);

            Locate = (Locate.Floor, Locate.Index + step);
        }

        private void MoveDownstairs()
        {
            var downStep = 0;

            while (CurrentSlot == Slot.Staircase)
            {
                downStep++;
                Locate = (Locate.Floor + 1, Locate.Index);
            }

            if (downStep != 0)
            {
                _drivingPath.Add("D" + downStep);
            }
        }

        internal class Floor : List<Slot>
        {
            private readonly Dictionary<int, Slot> _mapping = new()
            {
                [0] = Slot.Space,
                [1] = Slot.Staircase,
                [2] = Slot.Space
            };

            public void Add(int i)
            {
                Add(_mapping[i]);
            }
        }

        internal enum Slot
        {
            Space,
            Staircase
        }
    }
}

[TestFixture]
public partial class KataTests
{
    [Test, TestCaseSource(nameof(Kata19Cases))]
    public string[] Escape(int[,] carPark) => Kata.Escape(carPark);

    private static IEnumerable<TestCaseData> Kata19Cases
    {
        get
        {
            yield return new TestCaseData(new[,] { { 1, 0, 0, 0, 2 }, { 0, 0, 0, 0, 0 } })
                .Returns(new[] { "L4", "D1", "R4" });

            yield return new TestCaseData(new[,]
            {
                { 2, 0, 0, 1, 0 },
                { 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 0 }
            }).Returns(new[] { "R3", "D2", "R1" });

            yield return new TestCaseData(new[,]
            {
                { 0, 2, 0, 0, 1 },
                { 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 0 }
            }).Returns(new[] { "R3", "D3" });

            yield return new TestCaseData(new[,]
            {
                { 1, 0, 0, 0, 2 },
                { 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            }).Returns(new[] { "L4", "D1", "R4", "D1", "L4", "D1", "R4" });

            yield return new TestCaseData(new[,]
            {
                { 0, 0, 0, 0, 2 }
            }).Returns(Array.Empty<object>());
        }
    }
}