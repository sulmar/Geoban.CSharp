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
    public class Lamp
    {
        public LampState State
        {
            get
            {
                return machine.State;
            }
        }

        private StateMachine<LampState, SwitchTrigger> machine;


        public Lamp(Action onActionOff, Action onActionOn)
        {
            machine = new StateMachine<LampState, SwitchTrigger>(LampState.Off);

            //machine.Configure(LampState.Off)
            //    .Permit(SwitchTrigger.Start, LampState.On)
            //    .PermitReentry(SwitchTrigger.Stop)
            //    .OnEntry(onActionOff);  

            machine.Configure(LampState.Off)
                .Permit(SwitchTrigger.Start, LampState.On)
                .Permit(SwitchTrigger.Stop, LampState.Standby)
                .OnEntry(onActionOff);


            //machine.Configure(LampState.On)
            //    .Permit(SwitchTrigger.Stop, LampState.Off)
            //    .PermitReentry(SwitchTrigger.Start)
            //    .OnEntry(onActionOn);

            machine.Configure(LampState.On)
                .Permit(SwitchTrigger.Stop, LampState.Off)
                .Permit(SwitchTrigger.Start, LampState.Standby)
                .OnEntry(onActionOn, "Akcja 1");

            machine.Configure(LampState.Standby)
                .Permit(SwitchTrigger.Start, LampState.On)
                .Permit(SwitchTrigger.Stop, LampState.On);


            string graph = UmlDotGraph.Format(machine.GetInfo());

            machine.OnTransitioned(transition => Debug.WriteLine("{0} --- {1} ---> {2}", transition.Source, transition.Trigger, transition.Destination));

            Trace.WriteLine(graph);

         }

        public void SwitchOn()
        {
            machine.Fire(SwitchTrigger.Start);
        }

        public bool CanSwitchOn
        {
            get
            {
                return machine.CanFire(SwitchTrigger.Start);
            }
        }

        public void SwitchOff()
        {
            machine.Fire(SwitchTrigger.Stop);
        }


    }

    public enum LampState
    {
        On,
        Off,
        Standby
    }

    public enum SwitchTrigger
    {
        Start,
        Stop
    }
}
