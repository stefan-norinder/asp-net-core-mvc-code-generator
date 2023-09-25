namespace CodeGenerator.Lib.Services
{
    public class IdentifierTypeService
    {

        public IdentifierTypeService(string identifierType)
        {
            IdentifierType = identifierType;
        }

        public string IdentifierType { get; }
    }

    public static class IdentifierTypes
    {
        public static string Integer = "Integer";
        public static string Guid = "Guid";
    }

}