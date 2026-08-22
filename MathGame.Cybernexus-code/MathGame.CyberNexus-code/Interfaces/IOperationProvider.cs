public interface IOperationProvider
{
    string DisplayName {get;}
   Operation GetOperation();
}