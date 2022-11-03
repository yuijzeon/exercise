namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static int RunnersMeetings(int[] startPosition, int[] speed)
    {
        var runners = startPosition.Zip(speed).Select(x => new Runner(x.First, x.Second)).ToArray();
        var meetings = new List<Meeting>();

        for (var i = 0; i < runners.Length; i++)
        {
            for (var j = i + 1; j < runners.Length; j++)
            {
                var meeting = runners[i].GetMeeting(runners[j]);

                if (meeting == null)
                {
                    continue;
                }

                try
                {
                    meetings.Single(x => x.Equals(meeting)).AddRunner(runners[i], runners[j]);
                }
                catch (Exception)
                {
                    meetings.Add(meeting);
                }
            }
        }

        return meetings.Count == 0
            ? -1
            : meetings.Max(x => x.Runners.Count);
    }

    public class Runner
    {
        public Runner(int startPosition, int speed)
        {
            StartPosition = startPosition;
            Speed = speed;
        }

        private int StartPosition { get; set; }
        private int Speed { get; set; }

        public Meeting? GetMeeting(Runner runner)
        {
            if (Speed - runner.Speed == 0 || MeetingTime(runner) < 0)
            {
                return null;
            }

            return new Meeting(MeetingTime(runner), MeetingPosition(runner), this, runner);
        }

        public bool Equals(Runner runner)
        {
            return StartPosition == runner.StartPosition && Speed == runner.Speed;
        }

        private decimal MeetingPosition(Runner another)
        {
            return StartPosition + Speed * MeetingTime(another);
        }

        private decimal MeetingTime(Runner another)
        {
            return (decimal)-(StartPosition - another.StartPosition) / (Speed - another.Speed);
        }
    }

    public class Meeting
    {
        public Meeting(decimal meetingTime, decimal meetingPosition, params Runner[] runners)
        {
            MeetingTime = meetingTime;
            MeetingPosition = meetingPosition;
            var list = new List<Runner>();
            list.AddRange(runners);
            Runners = list;
        }

        private decimal MeetingPosition { get; set; }

        private decimal MeetingTime { get; set; }

        public List<Runner> Runners { get; set; }

        public void AddRunner(params Runner[] runners)
        {
            foreach (var runner in runners)
            {
                if (!Runners.Any(x => x.Equals(runner)))
                {
                    Runners.Add(runner);
                }
            }
        }

        public bool Equals(Meeting another)
        {
            return MeetingPosition == another.MeetingPosition && MeetingTime == another.MeetingTime;
        }
    }
}

[TestFixture]
public partial class KataTests
{
    [TestCase(new[] { 1, 4, 2 }, new[] { 27, 18, 24 }, ExpectedResult = 3)]
    [TestCase(new[] { 1, 4, 2 }, new[] { 5, 6, 2 }, ExpectedResult = 2)]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 1, 1 }, ExpectedResult = -1)]
    [TestCase(new[] { 1, 1000 }, new[] { 23, 22 }, ExpectedResult = 2)]
    public int RunnersMeetings(int[] startPosition, int[] speed)
    {
        return Kata.RunnersMeetings(startPosition, speed);
    }
}