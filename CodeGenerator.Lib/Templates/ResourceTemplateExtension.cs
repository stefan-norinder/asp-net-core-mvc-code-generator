using CodeGenerator.Lib.Models;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.Templates
{
    partial class ResourceTemplate
    {
        public readonly string namespaceName;

        private static string[] staticKeys = new[] {
                                                "Create",
                                                "Create New",
                                                "Edit",
                                                "Delete",
                                                "Save",
                                                "Home",
                                                "List",
                                                "Back to List",
                                                "ErrorHeader",
                                                "ErrorDescription",
                                                "Are you sure you want to delete this?"
                                            };

        public ResourceTemplate(string namespaceName, IEnumerable<Class> classes)
        {
            this.namespaceName = namespaceName;
            Model = GetReourceKeys(classes);
        }

        private static List<string> GetReourceKeys(IEnumerable<Class> classes)
        {
            var list = new List<string>(staticKeys);
            foreach (var @class in classes.Distinct())
            {
                if (!list.Contains(@class.Name)) list.Add(@class.Name);
                foreach (var prop in @class.Properties)
                {
                    if (!list.Contains(prop.Name)) list.Add(prop.Name);
                }
            }
            return list;
        }

        public IEnumerable<string> Model { get; }
    }
}
