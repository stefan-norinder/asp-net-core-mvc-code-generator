using CodeGenerator.Lib.Models;
using System.Collections.Generic;

namespace CodeGenerator.Lib.Templates
{
    partial class StartupTemplate
    {
        public readonly string namespaceName;

        public StartupTemplate(string namespaceName, IEnumerable<Class> @class)
        {
            this.namespaceName = namespaceName;
            Model = @class;
        }

        public IEnumerable<Class> Model { get; }
    }
}
