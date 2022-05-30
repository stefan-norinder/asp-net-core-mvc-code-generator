using CodeGenerator.Lib.Models;
using System.Collections.Generic;

namespace CodeGenerator.Lib.Templates
{
    partial class HomeViewTemplate
    {
        public readonly string namespaceName;

        public HomeViewTemplate(string namespaceName, IEnumerable<Class> @class)
        {
            this.namespaceName = namespaceName;
            Model = @class;
        }

        public IEnumerable<Class> Model { get; }
    }
}
