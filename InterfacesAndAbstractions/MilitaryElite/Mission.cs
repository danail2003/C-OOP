namespace MilitaryElite
{
    public enum MissionState
    {
        inProgress,
        Finished
    }

    public class Mission
    {
        public Mission(string name, MissionState missionState)
        {
            this.Name = name;
            this.State = missionState;
        }

        public string Name { get; set; }

        public MissionState State { get; set; }

        public void CompleteMission()
        {
            this.State = MissionState.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.Name} State: {this.State}";
        }
    }
}
