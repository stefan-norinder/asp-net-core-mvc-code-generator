﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace CodeGenerator.Lib.Templates
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class StartupTemplate : StartupTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            
            #line 6 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(CodeGeneratorHelper.GetTemplateHeaderText()));
            
            #line default
            #line hidden
            this.Write(" \r\n\r\nusing AutoMapper;\r\nusing ");
            
            #line 9 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(namespaceName));
            
            #line default
            #line hidden
            this.Write(".Logic.DataAccess;\r\nusing ");
            
            #line 10 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(namespaceName));
            
            #line default
            #line hidden
            this.Write(".Logic.Model;\r\nusing ");
            
            #line 11 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(namespaceName));
            
            #line default
            #line hidden
            this.Write(".Logic.Services;\r\nusing ");
            
            #line 12 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(namespaceName));
            
            #line default
            #line hidden
            this.Write(@".Web.ViewModel;
using Localization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;

namespace ");
            
            #line 22 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(namespaceName));
            
            #line default
            #line hidden
            this.Write(@".Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
");
            
            #line 36 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
 foreach(var item in Model) { 
            
            #line default
            #line hidden
            this.Write("            services.AddTransient<I");
            
            #line 37 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("Service, ");
            
            #line 37 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("Service>();\r\n            services.AddTransient<I");
            
            #line 38 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("DataAccess, ");
            
            #line 38 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("DataAccess>();\r\n            services.AddSingleton<SqlStringBuilder<");
            
            #line 39 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write(">>();\r\n            services.AddSingleton<LocService>();\r\n");
            
            #line 41 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("            services.AddTransient<ISqlDataAccess, SqlDataAccess>();\r\n\r\n          " +
                    "   var mapperConfig = new MapperConfiguration(mc =>\r\n            {\r\n            " +
                    "    mc.AddProfile(new MappingConfiguration());\r\n            });\r\n\r\n            I" +
                    "Mapper mapper = mapperConfig.CreateMapper();\r\n            services.AddSingleton(" +
                    "mapper);\r\n\r\n            services.AddLocalization(x => x.ResourcesPath = \"Resourc" +
                    "es\");\r\n            \r\n            services.AddControllersWithViews()\r\n           " +
                    "     .AddViewLocalization();\r\n        }\r\n\r\n        // This method gets called by" +
                    " the runtime. Use this method to configure the HTTP request pipeline.\r\n        p" +
                    "ublic void Configure(IApplicationBuilder app, IWebHostEnvironment env)\r\n        " +
                    "{\r\n            if (env.IsDevelopment())\r\n            {\r\n                app.UseD" +
                    "eveloperExceptionPage();\r\n            }\r\n            else\r\n            {\r\n      " +
                    "          app.UseExceptionHandler(\"/Home/Error\");\r\n                app.UseHsts()" +
                    ";\r\n            }\r\n            app.UseHttpsRedirection();\r\n            app.UseSta" +
                    "ticFiles();\r\n\r\n            app.UseRouting();\r\n\r\n            var supportedCulture" +
                    "s = new[] {\r\n                new CultureInfo(\"en-US\"),\r\n                // add m" +
                    "ore culture info options\r\n            };\r\n            var requestLocalizationOpt" +
                    "ions = new RequestLocalizationOptions\r\n            {\r\n                DefaultReq" +
                    "uestCulture = new RequestCulture(\"en-US\"),\r\n                SupportedCultures = " +
                    "supportedCultures,\r\n                SupportedUICultures = supportedCultures\r\n   " +
                    "         };\r\n            app.UseRequestLocalization(requestLocalizationOptions);" +
                    "\r\n\r\n            app.UseEndpoints(endpoints =>\r\n            {\r\n                en" +
                    "dpoints.MapControllerRoute(\r\n                    name: \"default\",\r\n             " +
                    "       pattern: \"{controller=Home}/{action=Index}/{id?}\");\r\n            });\r\n   " +
                    "     }\r\n    }\r\n        public class MappingConfiguration : Profile\r\n        {\r\n " +
                    "           public MappingConfiguration()\r\n            {\r\n        \r\n");
            
            #line 100 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
 foreach(var item in Model) { 
            
            #line default
            #line hidden
            this.Write("                CreateMap<");
            
            #line 101 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 101 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("ViewModel>();\r\n\r\n                CreateMap<");
            
            #line 103 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("ViewModel, ");
            
            #line 103 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write(">();\r\n        \r\n");
            
            #line 105 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("    \r\n            }\r\n        }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public class StartupTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
