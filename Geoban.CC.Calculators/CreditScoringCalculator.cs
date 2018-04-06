using Geoban.CC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geoban.CC.Calculators
{
    public interface IDecisionStrategy
    {
        bool CanGive(Request request);
    }

    public interface ICostStrategy
    {
        decimal GetCost(Request request);
    }

    public class PositiveDecisionStrategy : IDecisionStrategy
    {
        public bool CanGive(Request request)
        {
            return true;
        }
    }

    public class LimitDecisionStrategy : IDecisionStrategy
    {
        private readonly decimal limit;

        public LimitDecisionStrategy(decimal limit)
        {
            this.limit = limit;
        }

        public bool CanGive(Request request)
        {
            return request.Limit < limit;
        }
    }

    public class HappyDayOfWeekDecisionStrategy : IDecisionStrategy
    {
        private readonly DayOfWeek dayOfWeek;

        public HappyDayOfWeekDecisionStrategy(DayOfWeek dayOfWeek)
        {
            this.dayOfWeek = dayOfWeek;
        }

        public bool CanGive(Request request)
        {
            return request.ApplicationDate.DayOfWeek == dayOfWeek;
        }
    }

    public class PercentageCostStrategy : ICostStrategy
    {
        private readonly decimal percentage;

        public PercentageCostStrategy(decimal percentage)
        {
            this.percentage = percentage;
        }

        public decimal GetCost(Request request)
        {
            return request.Limit * percentage;
        }
    }

    public class FixedCostStrategy : ICostStrategy
    {
        private readonly decimal cost;

        public FixedCostStrategy(decimal cost)
        {
            this.cost = cost;
        }

        public decimal GetCost(Request request)
        {
            return cost;
        }
    }


    public class CreditScoringCalculator
    {
        private readonly IDecisionStrategy decisionStrategy;
        private readonly ICostStrategy costStrategy;

        public CreditScoringCalculator(
            IDecisionStrategy decisionStrategy,
            ICostStrategy costStrategy)
        {

            if (decisionStrategy == null)
                throw new ArgumentNullException("decisionStrategy");

            if (costStrategy == null)
                throw new ArgumentNullException("costStrategy");


            this.decisionStrategy = decisionStrategy;
            this.costStrategy = costStrategy;
        }

        public void Calculate(Request request)
        {
            request.DoWork();

            if (decisionStrategy.CanGive(request))
            {
                request.Accept();

                request.Cost = costStrategy.GetCost(request);

                Debug.WriteLine(request.Cost);
            }
            else
            {
                request.Decline();
            }
        }
    }


    public interface ICreditScoringCalculator
    {
        bool CanGive(Request request);

        decimal GetCost(Request request);
    }


    public class LowCostCreditScoringCalculator : ICreditScoringCalculator
    {
        private readonly decimal limit;
        private readonly decimal percentage;

        public LowCostCreditScoringCalculator(decimal limit, decimal percentage)
        {
            this.limit = limit;
            this.percentage = percentage;
        }

        public bool CanGive(Request request)
        {
            return request.Limit < limit;
        }

        public decimal GetCost(Request request)
        {
            return request.Limit * percentage;
        }
    }


    public class HappyDayOfWeekCreditScoringCalculator : ICreditScoringCalculator
    {
        private readonly DayOfWeek dayOfWeek;
        private readonly decimal cost;

        public HappyDayOfWeekCreditScoringCalculator(DayOfWeek dayOfWeek, decimal cost)
        {
            this.dayOfWeek = dayOfWeek;
            this.cost = cost;
        }

        public bool CanGive(Request request)
        {
            return request.ApplicationDate.DayOfWeek == dayOfWeek;
        }

        public decimal GetCost(Request request)
        {
            return cost;
        }
    }

}
