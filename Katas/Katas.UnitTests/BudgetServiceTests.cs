using Katas.BudgetAggregate;
using NSubstitute.Core;

namespace Katas.UnitTests;

public class BudgetServiceTests
{
    private IBudgetRepository _budgetRepository = null!;
    private BudgetService _budgetService = null!;

    [SetUp]
    public void SetUp()
    {
        _budgetRepository = Substitute.For<IBudgetRepository>();
        _budgetService = new BudgetService(_budgetRepository);

        GivenBudgets(new List<Budget>
        {
            CreateBudget("202206", 30000),
            CreateBudget("202209", 30),
            CreateBudget("202210", 310000),
            CreateBudget("202211", 3000),
            CreateBudget("202212", 31),
        });
    }

    [Test]
    public void one_month()
    {
        var amount = _budgetService.Query(new DateTime(2022, 10, 1), new DateTime(2022, 10, 31));
        Assert.That(amount, Is.EqualTo(310000));
    }

    [Test]
    public void one_day()
    {
        var amount = _budgetService.Query(new DateTime(2022, 10, 1), new DateTime(2022, 10, 1));
        Assert.That(amount, Is.EqualTo(10000));
    }

    [Test]
    public void cross_days()
    {
        var amount = _budgetService.Query(new DateTime(2022, 10, 1), new DateTime(2022, 10, 6));
        Assert.That(amount, Is.EqualTo(60000));
    }

    [Test]
    public void cross_months()
    {
        var amount = _budgetService.Query(new DateTime(2022, 10, 30), new DateTime(2022, 11, 5));
        Assert.That(amount, Is.EqualTo(20000 + 500));
    }

    [Test]
    public void cross_three_months()
    {
        var amount = _budgetService.Query(new DateTime(2022, 10, 30), new DateTime(2022, 12, 1));
        Assert.That(amount, Is.EqualTo(20000 + 3000 + 1));
    }

    [Test]
    public void cross_four_months()
    {
        var amount = _budgetService.Query(new DateTime(2022, 9, 1), new DateTime(2022, 12, 31));
        Assert.That(amount, Is.EqualTo(30 + 310000 + 3000 + 31));
    }

    [Test]
    public void illegal_date()
    {
        var amount = _budgetService.Query(new DateTime(2022, 10, 30), new DateTime(2022, 1, 5));
        Assert.That(amount, Is.EqualTo(0));
    }

    [Test]
    public void some_month_no_data()
    {
        var amount = _budgetService.Query(new DateTime(2022, 5, 1), new DateTime(2022, 9, 1));
        Assert.That(amount, Is.EqualTo(30000 + 1));
    }

    [Test]
    public void db_no_data()
    {
        var amount = _budgetService.Query(new DateTime(2000, 10, 30), new DateTime(2000, 11, 5));
        Assert.That(amount, Is.EqualTo(0));
    }

    private static Budget CreateBudget(string yearMonth, int amount)
    {
        return new Budget
        {
            YearMonth = yearMonth,
            Amount = amount
        };
    }

    private ConfiguredCall GivenBudgets(List<Budget> returnThis)
    {
        return _budgetRepository.GetAll().Returns(returnThis);
    }
}