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
                                                "Are you sure you want to delete this?",
                                                "Toggle language"
                                            };

        public ResourceTemplate(string namespaceName, IEnumerable<Class> classes)
        {
            this.namespaceName = namespaceName;
            Model = GetReourceKeys(classes);
        }

        private static List<string> GetReourceKeys(IEnumerable<Class> classes)
        {
            var list = new List<string>(staticKeys);
            foreach (var @class in classes)
            {
                list.Add(@class.Name);
                list.AddRange(@class.Properties.Where(x => x.Name != "Id").Select(x => x.Name).Distinct());
            }

            return list;
        }

        public IEnumerable<string> Model { get; }
    }
}
