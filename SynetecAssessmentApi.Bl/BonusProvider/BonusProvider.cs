namespace SynetecAssessmentApi.Bl.BonusProvider
{
    public interface IBonusProvider
    {
        int CalculateBonusAllocation(int bonusPoolAmount, int salary, int totalSalary);
    }

    public class BonusProvider : IBonusProvider
    {
        public int CalculateBonusAllocation(int bonusPoolAmount, int salary, int totalSalary)
        {
            decimal bonusPercentage = (decimal) salary / totalSalary;
            int bonusAllocation = (int) (bonusPercentage * bonusPoolAmount);

            return bonusAllocation;
        }
    }
}
