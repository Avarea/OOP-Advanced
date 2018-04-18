using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Command
{
    public abstract class Command : IExecutable
    {
        private string[] data;

        public Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data
        {
            get { return this.data;}
            set { this.data = value; }
        }

        public abstract string Execute();

    }
}
