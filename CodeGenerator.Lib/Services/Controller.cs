using CodeGenerator.Lib.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.Services
{
    public interface IController
    {
        void Run(CodeGeneratorTypes type);    
    }

    public class Controller : IController
    {
        private readonly ICodeGeneratorServiceFactory factory;

        public Controller()
        {
        }

        public Controller(ICodeGeneratorServiceFactory factory)
        {
            this.factory = factory;
        }

        public void Run(CodeGeneratorTypes types)
        {
            
        }
    }
}
