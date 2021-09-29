namespace BasicApplication.Domain.Enumerations
{
    public enum YesNo
    {
        Yes,
        No
    }

    public enum Status
    {
        Active,
        Inactive
    }

    public enum Result
    {
        Error,
        Success
    }

    public enum MenuType
    {
        MainMenu,
        SubMenu,
        Forms, 
        Reports
    }

    public enum DBResponse
    {
        Created,
        Deleted,
        Updated,
        ErrorCreating,
        ErrorDeleting,
        ErrorUpdating,
        ErrorRetreiving
    }
}
