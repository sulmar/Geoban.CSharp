using Stateless;
using Stateless.Graph;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geoban.CC.Models
{
    public class Request : Base
    {
        public int Id { get; set; }
        public DateTime ApplicationDate { get; set; }
        public CreditCardType Type { get; set; }
        public decimal Limit { get; set; }

        public RequestStatus Status
        {
            get
            {
                return machine.State;
            }
        }

        public decimal? Cost { get; set; }

        private StateMachine<RequestStatus, Trigger> machine;

        public Request(int id, CreditCardType creditCardType, decimal limit)
        {
            machine = new StateMachine<RequestStatus, Trigger>(RequestStatus.New);

            machine.Configure(RequestStatus.New)
                .Permit(Trigger.Coffee, RequestStatus.InProgress);

            machine.Configure(RequestStatus.InProgress)
                .Permit(Trigger.Accept, RequestStatus.Accepted)
                .Permit(Trigger.Cancel, RequestStatus.Decline)
                .PermitReentry(Trigger.Coffee);

            var graph = UmlDotGraph.Format(machine.GetInfo());

            Trace.WriteLine(graph);
            // http://www.webgraphviz.com/

            this.ApplicationDate = DateTime.Now;

            this.Id = id;
            this.Type = creditCardType;
            this.Limit = limit;
        }

        public void DoWork()
        {
            machine.Fire(Trigger.Coffee);
        }

        public void Accept()
        {
            machine.Fire(Trigger.Accept);
        }

        public bool CanAccept
        {
            get
            {
                return machine.CanFire(Trigger.Accept);
            }

        }

        public void Decline()
        {
            machine.Fire(Trigger.Cancel);
        }

        public bool CanDecline
        {
            get
            {
                return machine.CanFire(Trigger.Cancel);
            }
        }


    }

    public enum Trigger
    {
        Coffee,
        Accept,
        Cancel
    }

    public enum RequestStatus
    {
        New,
        InProgress,
        Accepted,
        Decline
    }

    public enum CreditCardType
    {
        Visa,
        MasterCard
    }
}
