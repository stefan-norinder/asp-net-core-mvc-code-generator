// ------------------------------------------------------------------------------
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
    
    #line 1 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\HttpClientTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class HttpClientTemplate : HttpClientTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            
            #line 6 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\HttpClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(CodeGeneratorHelper.GetTemplateHeaderText()));
            
            #line default
            #line hidden
            this.Write(" \r\n\r\nusing ");
            
            #line 8 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\HttpClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(namespaceName));
            
            #line default
            #line hidden
            this.Write(@".Logic.Setting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ");
            
            #line 19 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\HttpClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(namespaceName));
            
            #line default
            #line hidden
            this.Write(".Logic.Http\r\n{\r\n    public interface IHttpClient\r\n    {\r\n        Task<HttpRespons" +
                    "e> Get(Uri url);\r\n        Task<HttpResponse> Post(Uri url, string content);\r\n   " +
                    "     Task<HttpResponse> Put(Uri url, string content);\r\n        Task<HttpResponse" +
                    "> Delete(Uri url);\r\n    }\r\n\r\n    public class HttpClient : IHttpClient\r\n    {\r\n " +
                    "       protected readonly IHttpClientFactory clientFactory;\r\n        protected r" +
                    "eadonly ILogger<HttpClient> logger;\r\n        protected readonly AuthenticationSe" +
                    "ttings settings;\r\n\r\n        public HttpClient(IHttpClientFactory clientFactory,\r" +
                    "\n            ILogger<HttpClient> logger,\r\n            IOptions<AuthenticationSet" +
                    "tings> settings)\r\n        {\r\n            this.clientFactory = clientFactory;\r\n  " +
                    "          this.logger = logger;\r\n            this.settings = settings.Value;\r\n  " +
                    "      }\r\n\r\n        public async Task<HttpResponse> Get(Uri url)\r\n        {\r\n    " +
                    "        return await SendRequest(HttpMethod.Get, url);\r\n        }\r\n\r\n        pub" +
                    "lic async Task<HttpResponse> Post(Uri url, string content)\r\n        {\r\n         " +
                    "   return await SendRequest(HttpMethod.Post, url, content);\r\n        }\r\n\r\n      " +
                    "  public async Task<HttpResponse> Put(Uri url, string content)\r\n        {\r\n     " +
                    "       return await SendRequest(HttpMethod.Put, url, content);\r\n        }\r\n\r\n   " +
                    "     public async Task<HttpResponse> Delete(Uri url)\r\n        {\r\n            ret" +
                    "urn await SendRequest(HttpMethod.Delete, url);\r\n        }\r\n\r\n        #region pri" +
                    "vate\r\n\r\n        private async Task<HttpResponse> SendRequest(HttpMethod method, " +
                    "Uri url, string requestContent = \"\")\r\n        {\r\n            logger.LogDebug($\"S" +
                    "ending {method} request to {url}. Content: {requestContent}\");\r\n            var " +
                    "request = new HttpRequestMessage(method, url);\r\n            if (!string.IsNullOr" +
                    "Empty(requestContent)) request.Content = new StringContent(requestContent, Encod" +
                    "ing.UTF8, \"application/json\");\r\n            var response = await Send(request);\r" +
                    "\n            string responseContent = await GetContent(response);\r\n            l" +
                    "ogger.LogDebug($\"Response code {response.StatusCode}. Content: {responseContent}" +
                    "\");\r\n            return new HttpResponse(response.StatusCode, response.IsSuccess" +
                    "StatusCode, responseContent);\r\n        }\r\n\r\n\r\n        private async Task<HttpRes" +
                    "ponseMessage> Send(HttpRequestMessage request)\r\n        {\r\n            var clien" +
                    "t = clientFactory.CreateClient();\r\n            client.SetBearerTokenIfExists(set" +
                    "tings.BearerToken);\r\n            return await client.SendAsync(request);        " +
                    "\r\n        }\r\n\r\n        private static async Task<string> GetContent(HttpResponse" +
                    "Message response)\r\n        {\r\n            try\r\n            {\r\n                va" +
                    "r contenttype = response.Content.Headers.FirstOrDefault(h => h.Key.Equals(\"Conte" +
                    "nt-Type\"));\r\n\r\n                var rawencoding = contenttype.Value.First();\r\n\r\n " +
                    "               if (rawencoding.Contains(\"utf8\") || rawencoding.Contains(\"UTF-8\")" +
                    ")\r\n                {\r\n                    var bytes = await response.Content.Rea" +
                    "dAsByteArrayAsync();\r\n                    return Encoding.UTF8.GetString(bytes);" +
                    "\r\n                }\r\n                else\r\n                {\r\n                  " +
                    "  return await response.Content.ReadAsStringAsync();\r\n                }\r\n       " +
                    "     }\r\n            catch (Exception)\r\n            {\r\n                return awa" +
                    "it response.Content.ReadAsStringAsync();\r\n            }\r\n        }\r\n\r\n        #e" +
                    "ndregion\r\n    }\r\n\r\n    #region models \r\n\r\n    public class HttpResponse\r\n    {\r\n" +
                    "        public HttpResponse(HttpStatusCode statusCode, bool isSuccess) : this(st" +
                    "atusCode,  isSuccess, string.Empty)\r\n        { }\r\n\r\n        public HttpResponse(" +
                    "HttpStatusCode statusCode, bool isSuccess, string content)\r\n        {\r\n         " +
                    "   StatusCode = statusCode;\r\n            IsSuccess = isSuccess;\r\n            Con" +
                    "tent = content;\r\n        }\r\n\r\n        public string Content { get; private set; " +
                    "}\r\n        public HttpStatusCode StatusCode { get; private set; }\r\n        publi" +
                    "c bool IsSuccess { get; set; }\r\n\r\n        /// <throws>HttpRequestException</thro" +
                    "ws>\r\n        public void CheckStatus()\r\n        {\r\n            if (!IsSuccess)\r\n" +
                    "            {\r\n                throw new HttpRequestException($\"Request failed (" +
                    "{StatusCode}). {Content}\",null, StatusCode);\r\n            }\r\n        }\r\n    }\r\n\r" +
                    "\n    #endregion\r\n\r\n    #region Extensions \r\n    \r\n    public static class HttpCl" +
                    "ientExtensions\r\n    {\r\n        public static void SetBearerTokenIfExists(this Sy" +
                    "stem.Net.Http.HttpClient client, string bearerToken)\r\n        {\r\n            if " +
                    "(!string.IsNullOrEmpty(bearerToken)) client.DefaultRequestHeaders.Authorization " +
                    "= new AuthenticationHeaderValue(\"Bearer\", bearerToken);\r\n        }\r\n    }\r\n\r\n   " +
                    " #endregion\r\n}\r\n");
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
    public class HttpClientTemplateBase
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
