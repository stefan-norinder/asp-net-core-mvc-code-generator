﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
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
    
    #line 1 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class StartupTemplate : StartupTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            
            #line 6 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(CodeGeneratorHelper.GetTemplateHeaderText()));
            
            #line default
            #line hidden
            this.Write(@" 

using AutoMapper;
using Localization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ");
            
            #line 20 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(namespaceName));
            
            #line default
            #line hidden
            this.Write(".Logic.DataAccess;\r\nusing ");
            
            #line 21 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(namespaceName));
            
            #line default
            #line hidden
            this.Write(".Logic.Http;\r\nusing ");
            
            #line 22 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(namespaceName));
            
            #line default
            #line hidden
            this.Write(".Logic.Model;\r\nusing ");
            
            #line 23 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(namespaceName));
            
            #line default
            #line hidden
            this.Write(".Logic.Services;\r\nusing ");
            
            #line 24 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(namespaceName));
            
            #line default
            #line hidden
            this.Write(".Logic.Settings;\r\nusing ");
            
            #line 25 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(namespaceName));
            
            #line default
            #line hidden
            this.Write(".Web.ViewModel;\r\nusing System.Collections.Generic;\r\nusing System.Globalization;\r\n" +
                    "using System.Net;\r\nusing System.Threading.Tasks;\r\nusing System;\r\nusing System.IO" +
                    ";\r\nusing Microsoft.CodeAnalysis;\r\n\r\nnamespace ");
            
            #line 34 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(namespaceName));
            
            #line default
            #line hidden
            this.Write(@".Web
{
    public class Startup
    {       
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
");
            
            #line 49 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
 foreach(var item in Model) { 
            
            #line default
            #line hidden
            this.Write("            #region register ");
            
            #line 50 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("\r\n            services.AddTransient<I");
            
            #line 51 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("Service, ");
            
            #line 51 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("Service>();\r\n            services.AddTransient<I");
            
            #line 52 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("HttpService, ");
            
            #line 52 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("HttpService>();\r\n            services.AddTransient<I");
            
            #line 53 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("DataAccess, ");
            
            #line 53 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("DataAccess>();\r\n            services.AddSingleton<SqlStringBuilder<");
            
            #line 54 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write(">>();\r\n            #endregion\r\n\r\n");
            
            #line 57 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("            services.AddSingleton<LocService>();\r\n            services.AddTransie" +
                    "nt<IHttpClient, Logic.Http.HttpClient>();\r\n            services.Configure<Authen" +
                    "ticationSettings>(Configuration.GetSection(\"Authentication\"));\r\n            serv" +
                    "ices.Configure<ApplicationSettings>(Configuration.GetSection(\"Application\"));\r\n " +
                    "           services.AddTransient<ISqlDataAccess, SqlDataAccess>();\r\n            " +
                    "\r\n            services.AddHttpClient();\r\n            services.AddSingleton(GetMa" +
                    "pper());\r\n            ConfigureLocalization(services);\r\n            services.Add" +
                    "Localization(x => x.ResourcesPath = \"Resources\");\r\n            CustomServiceConf" +
                    "iguration(services);\r\n            services.AddControllersWithViews()\r\n          " +
                    "      .AddViewLocalization();\r\n        }\r\n\r\n        public void Configure(IAppli" +
                    "cationBuilder app, IWebHostEnvironment env)\r\n        {\r\n            app.UseHttps" +
                    "Redirection();\r\n            app.UseStaticFiles();\r\n            app.UseRouting();" +
                    "\r\n            app.UseRequestLocalization();\r\n            ConfigureExceptionHandl" +
                    "er(app);\r\n            CustomConfiguration(app, env);   \r\n            RegisterMid" +
                    "dleware(app);\r\n\r\n            app.UseEndpoints(endpoints =>\r\n            {\r\n     " +
                    "           endpoints.MapControllerRoute(\r\n                    name: \"default\",\r\n" +
                    "                    pattern: \"{controller=Home}/{action=Index}/{id?}\");\r\n       " +
                    "     });\r\n        }\r\n\r\n        protected virtual void CustomServiceConfiguration" +
                    "(IServiceCollection services)\r\n        {\r\n            //override for custom beha" +
                    "viour\r\n        }\r\n\r\n        protected virtual void CustomConfiguration(IApplicat" +
                    "ionBuilder app, IWebHostEnvironment env)\r\n        {\r\n            //override for " +
                    "custom behaviour\r\n        }\r\n\r\n        protected virtual void RegisterMiddleware" +
                    "(IApplicationBuilder app)\r\n        {\r\n            app.UseMiddleware<CleanUp>();\r" +
                    "\n            app.UseMiddleware<RedirectNotFound>();\r\n            app.UseMiddlewa" +
                    "re<RedirectTablelang>();\r\n        }\r\n        \r\n         protected void Configure" +
                    "Localization(IServiceCollection services)\r\n        {\r\n            var supportedC" +
                    "ultures = GetSupportedLanguages();\r\n\r\n            services.Configure((Action<Req" +
                    "uestLocalizationOptions>)(options =>\r\n            {\r\n                options.Def" +
                    "aultRequestCulture = GetDefaultCulture();\r\n                options.SupportedCult" +
                    "ures = supportedCultures;\r\n                options.SupportedUICultures = support" +
                    "edCultures;\r\n                options.RequestCultureProviders = new List<IRequest" +
                    "CultureProvider>\r\n                {\r\n                  new QueryStringRequestCul" +
                    "tureProvider(),\r\n                  new CookieRequestCultureProvider()\r\n         " +
                    "       };\r\n            }));\r\n        }\r\n\r\n        protected virtual RequestCultu" +
                    "re GetDefaultCulture() => new RequestCulture(\"en-gb\");\r\n\r\n        protected virt" +
                    "ual IList<CultureInfo> GetSupportedLanguages()\r\n        {\r\n            return ne" +
                    "w List<CultureInfo> {\r\n                new CultureInfo(\"en-gb\")\r\n            };\r" +
                    "\n        }\r\n\r\n        protected virtual void ConfigureExceptionHandler(IApplicat" +
                    "ionBuilder app)\r\n        {\r\n            app.UseExceptionHandler(builder =>\r\n    " +
                    "        {\r\n                builder.Run(async context =>\r\n                {\r\n    " +
                    "                var e = context.Features.Get<IExceptionHandlerFeature>();\r\n     " +
                    "               if (e == null) return;\r\n                    context.Response.Stat" +
                    "usCode = (int)HttpStatusCode.InternalServerError;\r\n                    context.R" +
                    "esponse.ContentType = \"text/html\";\r\n                    var factory = builder.Ap" +
                    "plicationServices.GetService<ILoggerFactory>();\r\n                    var logger " +
                    "= factory.CreateLogger(\"ExceptionLogger\");\r\n                    logger.LogError(" +
                    "e.Error, e.Error.Message);\r\n                    context.Response.Redirect(\"/erro" +
                    "r\");\r\n                });\r\n            });\r\n        }\r\n\r\n        public virtual " +
                    "IMapper GetMapper()\r\n        {\r\n            var mapperConfig = new MapperConfigu" +
                    "ration(mc =>\r\n            {\r\n                mc.AddProfile(new MappingConfigurat" +
                    "ion());\r\n            });\r\n\r\n            return mapperConfig.CreateMapper();\r\n   " +
                    "     }\r\n    }\r\n\r\n    public class MappingConfiguration : Profile\r\n    {\r\n       " +
                    " public MappingConfiguration()\r\n        {\r\n        \r\n");
            
            #line 168 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
 foreach(var item in Model) { 
            
            #line default
            #line hidden
            this.Write("                CreateMap<");
            
            #line 169 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 169 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("ViewModel>();\r\n\r\n                CreateMap<");
            
            #line 171 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("ViewModel, ");
            
            #line 171 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write(">();\r\n        \r\n");
            
            #line 173 "C:\Users\StefanAdmin\code2\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\StartupTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("    \r\n        }\r\n    }\r\n\r\n    #region middleware\r\n\r\n    public class RedirectNotF" +
                    "ound\r\n    {\r\n        private readonly RequestDelegate next;\r\n        private rea" +
                    "donly ApplicationSettings applicationSettings;\r\n\r\n        public RedirectNotFoun" +
                    "d(RequestDelegate next, IOptions<ApplicationSettings> options)\r\n        {\r\n     " +
                    "       this.next = next;\r\n            applicationSettings = options.Value;\r\n    " +
                    "    }\r\n\r\n        public async Task InvokeAsync(HttpContext context)\r\n        {\r\n" +
                    "            await next.Invoke(context);\r\n\r\n            if (context.Response.Stat" +
                    "usCode == 404 && !context.Response.HasStarted)\r\n            {\r\n                c" +
                    "ontext.Response.Redirect($\"/notfound?page={context.Request.Path}\");\r\n           " +
                    " }\r\n        }\r\n    }\r\n\r\n    public class RedirectTablelang\r\n    {\r\n        priva" +
                    "te readonly RequestDelegate next;\r\n        private readonly ApplicationSettings " +
                    "applicationSettings;\r\n\r\n        public RedirectTablelang(RequestDelegate next, I" +
                    "Options<ApplicationSettings> options)\r\n        {\r\n            this.next = next;\r" +
                    "\n            applicationSettings = options.Value;\r\n        }\r\n\r\n        public a" +
                    "sync Task InvokeAsync(HttpContext context)\r\n        {\r\n            const string " +
                    "resourceBase = \"/resources\";\r\n            var applicationName = applicationSetti" +
                    "ngs.Name;\r\n            var path = context.Request.Path;\r\n            var tableLa" +
                    "ngPath = $\"{applicationName}{resourceBase}\";\r\n            if (path.Value.EndsWit" +
                    "h(resourceBase, StringComparison.InvariantCultureIgnoreCase) &&\r\n               " +
                    " !path.Value.Equals(tableLangPath, StringComparison.InvariantCultureIgnoreCase) " +
                    "&&\r\n                !path.Value.Equals(resourceBase, StringComparison.InvariantC" +
                    "ultureIgnoreCase))\r\n            {\r\n                context.Response.StatusCode =" +
                    " 302;\r\n                context.Response.Headers[\"Location\"] = tableLangPath;\r\n  " +
                    "              return;\r\n            }\r\n            await next.Invoke(context);\r\n " +
                    "       }\r\n    }\r\n        public class CleanUp\r\n    {\r\n        private readonly R" +
                    "equestDelegate next;\r\n        protected readonly ApplicationSettings application" +
                    "Settings;\r\n\r\n        public CleanUp(RequestDelegate next, IOptions<ApplicationSe" +
                    "ttings> options)\r\n        {\r\n            this.next = next;\r\n            applicat" +
                    "ionSettings = options.Value;\r\n        }\r\n\r\n        public async Task InvokeAsync" +
                    "(HttpContext context)\r\n        {\r\n            if (context.Request.Path.Value.End" +
                    "sWith(\"clean-up\", StringComparison.InvariantCultureIgnoreCase))\r\n            {\r\n" +
                    "                await ProcessCleanUp();\r\n                context.Response.Status" +
                    "Code = StatusCodes.Status200OK;\r\n                await context.Response.WriteAsy" +
                    "nc(\"Clean-up ok.\");\r\n            }\r\n            else\r\n            {\r\n           " +
                    "     await next.Invoke(context);\r\n            }\r\n        }\r\n\r\n        public vir" +
                    "tual async Task ProcessCleanUp()\r\n        {\r\n            string path = Path.Comb" +
                    "ine(AppContext.BaseDirectory, \"logs\");\r\n\r\n            var directory = new Direct" +
                    "oryInfo(path);\r\n\r\n            foreach (var file in directory.GetFiles())\r\n      " +
                    "      {\r\n                if (file.LastAccessTime < DateTime.Today.AddDays(-appli" +
                    "cationSettings.KeepLogsInDays))\r\n                {\r\n                    await Ta" +
                    "sk.Run(() => file.Delete());\r\n                }\r\n            }\r\n        }\r\n    }" +
                    "\r\n\r\n    #endregion\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
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
