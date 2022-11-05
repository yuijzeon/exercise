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
        private readonly List<List<Slot>> _floors = new();

        private readonly Dictionary<int, Slot> _mapping = new()
        {
            [0] = Slot.Space,
            [1] = Slot.Staircase,
            [2] = Slot.Space
        };

        public CarPark(int[,] carPark)
        {
            for (var i = 0; i < carPark.GetLength(0); i++)
            {
                var floor = new List<Slot>();

                for (var j = 0; j < carPark.GetLength(1); j++)
                {
                    if (carPark[i, j] == 2)
                    {
                        CarPosition = new Position(i, j);
                    }

                    floor.Add(_mapping[carPark[i, j]]);
                }

                _floors.Add(floor);
            }

            _floors[^1][^1] = Slot.Exit;
        }

        private Position CarPosition { get; } = new();
        private List<Slot> CurrentFloor => _floors[CarPosition.Floor];
        private Slot CurrentSlot => CurrentFloor[CarPosition.Index];
        private bool IsGroundFloor => CarPosition.Floor == _floors.Count - 1;

        public string[] GoExit()
        {
            while (CurrentSlot != Slot.Exit)
            {
                if (CurrentSlot == Slot.Staircase)
                {
                    MoveDownstairs();
                }
                else
                {
                    MoveSameFloor();
                }
            }

            return _drivingPath.ToArray();
        }

        private void MoveSameFloor()
        {
            var step = (IsGroundFloor
                ? CurrentFloor.IndexOf(Slot.Exit)
                : CurrentFloor.IndexOf(Slot.Staircase)) - CarPosition.Index;

            CarPosition.AddIndex(step);

            _drivingPath.Add(step < 0
                ? "L" + -step
                : "R" + step);
        }

        private void MoveDownstairs()
        {
            var downStep = 0;

            while (CurrentSlot == Slot.Staircase)
            {
                downStep++;
                CarPosition.Downstairs();
            }

            _drivingPath.Add("D" + downStep);
        }

        internal enum Slot
        {
            Space,
            Staircase,
            Exit
        }

        internal class Position
        {
            public Position()
            { }

            public Position(int floor, int index)
            {
                Floor = floor;
                Index = index;
            }

            public int Floor { get; set; }
            public int Index { get; set; }

            public void AddIndex(int step)
            {
                Index += step;
            }

            public void Downstairs()
            {
                Floor += 1;
            }
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