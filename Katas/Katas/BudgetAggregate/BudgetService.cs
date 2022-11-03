namespace Katas.BudgetAggregate;

public class BudgetService
{
    private readonly IBudgetRepository _budgetRepository;

    public BudgetService(IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }

    public decimal Query(DateTime start, DateTime end)
    {
        if (end < start)
        {
            return 0m;
        }

        var budgets = _budgetRepository.GetAll().Where(x => start <= x.GetDateTime(x.Days) && end >= x.GetDateTime(1)).ToList();
        var budgetOfStart = budgets.FirstOrDefault(x => x.YearMonthEqual(start), Budget.Empty(start));
        var budgetOfEnd = budgets.FirstOrDefault(x => x.YearMonthEqual(end), Budget.Empty(end));

        return budgets.Sum(x => x.Amount)
               - budgetOfStart.AmountPerDay * (start.Day - 1)
               - budgetOfEnd.AmountPerDay * (budgetOfEnd.Days - end.Day);
    }
}