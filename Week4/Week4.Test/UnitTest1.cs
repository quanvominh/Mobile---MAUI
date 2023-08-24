using Week4.ViewModels;

namespace Week4.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var vm = new MainPageViewModel();
        vm.TestCommand.Execute(null);
        Assert.Equal(vm.Cats?.Count, 0);
    }
}

