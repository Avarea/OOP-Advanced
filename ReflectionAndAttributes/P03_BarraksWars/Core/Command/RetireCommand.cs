using System;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Command
{
    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data, IRepository repository) : base(data)
        {
            this.Repository = repository;
        }

        protected IRepository Repository
        {
            get { return this.repository; }
            set { this.repository = value; }
        }

        public override string Execute()
        {
            try
            {
                this.Repository.RemoveUnit(Data[1]);
                return $"{Data[1]} retired!";
            }
            catch (Exception e)
            {
               throw new ArgumentException("No such units in repository.", e);
            }
        }
    }
}
