namespace Shared.Test;
public interface ITestData<T> where T : class
{ //figure out how to best give needed data for object creation, tuple? object? custom class? 
    //requre C# 11
    //public abstract static T CreateTestObject();
}
