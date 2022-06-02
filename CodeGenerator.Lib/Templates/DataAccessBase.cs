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
    
    #line 1 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\DataAccessBase.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class DataAccessBase : DataAccessBaseBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"//---------------------------------------------------------------------------------------
// Warning! This is an auto generated file. Changes may be overwritten 
//---------------------------------------------------------------------------------------
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ");
            
            #line 14 "C:\Users\Stefan Adm\code\asp-net-core-mvc-code-generator\CodeGenerator.Lib\Templates\DataAccessBase.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(namespaceName));
            
            #line default
            #line hidden
            this.Write(".Logic.DataAccess\r\n{\r\n    public interface IDataAccess<T>\r\n    {\r\n        Task<T>" +
                    " Get(int id);\r\n        Task<IEnumerable<T>> GetAll();\r\n        Task Insert(T mod" +
                    "el);\r\n        Task Update(T model);\r\n        Task Delete(int id);\r\n        Task " +
                    "DeleteAll();\r\n    }\r\n\r\n    public class BaseDataAccess<T> : IDataAccess<T>\r\n    " +
                    "{\r\n        protected readonly ISqlDataAccess db;\r\n        private readonly SqlSt" +
                    "ringBuilder<T> sqlStringBuilder;\r\n\r\n        public BaseDataAccess(ISqlDataAccess" +
                    " db,\r\n            SqlStringBuilder<T> sqlStringBuilder)\r\n        {\r\n            " +
                    "this.db = db;\r\n            this.sqlStringBuilder = sqlStringBuilder;\r\n          " +
                    "  Table = typeof(T).Name;\r\n        }\r\n\r\n        protected string Table { get; }\r" +
                    "\n\r\n        public async virtual Task Insert(T model)\r\n        {            \r\n   " +
                    "         var sql = await HasIdentityColumn() ? sqlStringBuilder.GetInsertString(" +
                    "model) : sqlStringBuilder.GetInsertString(model, await GetNextId());\r\n\r\n        " +
                    "    await db.SaveData(sql, model);\r\n        }\r\n\r\n        public async virtual Ta" +
                    "sk Update(T model)\r\n        {\r\n            string sql = sqlStringBuilder.GetUpda" +
                    "teString(model);\r\n\r\n            await db.SaveData(sql, model);\r\n        }\r\n\r\n   " +
                    "     public virtual async Task<IEnumerable<T>> GetAll()\r\n        {\r\n            " +
                    "string sql = $\"SELECT * FROM {Table} \";\r\n            return await ExecuteSelectM" +
                    "any(sql);\r\n        }\r\n        \r\n        public virtual async Task<T> Get(int id)" +
                    "\r\n        {\r\n            string sql = $\"SELECT * FROM {Table} Where Id = @id\";\r\n" +
                    "            return await db.LoadSingularData<T, dynamic>(sql, new { Id = id });\r" +
                    "\n        }\r\n\r\n        public async Task DeleteAll()\r\n        {\r\n            stri" +
                    "ng sql = $\"DELETE FROM {Table} \";\r\n            await db.SaveData(sql, new { });\r" +
                    "\n        }\r\n\r\n        public async Task Delete(int id)\r\n        {\r\n            s" +
                    "tring sql = $\"DELETE FROM {Table} WHERE Id = @id\";\r\n            await db.SaveDat" +
                    "a(sql, new { Id = id });\r\n        }\r\n\r\n        protected async Task<T> ExecuteSe" +
                    "lectSingle(string sql, int id)\r\n        {\r\n            return await db.LoadSingu" +
                    "larData<T, dynamic>(sql, new { Id = id });\r\n        }\r\n\r\n        protected async" +
                    " Task<T> ExecuteSelectSingle(string sql)\r\n        {\r\n            return await db" +
                    ".LoadSingularData<T, dynamic>(sql, new { });\r\n        }\r\n\r\n        protected asy" +
                    "nc Task<List<T>> ExecuteSelectMany(string sql)\r\n        {\r\n            return aw" +
                    "ait db.LoadData<T, dynamic>(sql, new { });\r\n        }\r\n\r\n        #region private" +
                    "\r\n\r\n        private async Task<bool> HasIdentityColumn()\r\n        {\r\n           " +
                    " var sql = @$\"select b.name as IdentityColumn \r\n                        from sys" +
                    "objects a inner join syscolumns b on a.id = b.id \r\n                       where " +
                    "a.name = \'{Table}\' and    \r\n                            columnproperty(a.id, b.n" +
                    "ame, \'isIdentity\') = 1 and \r\n                            objectproperty(a.id, \'i" +
                    "sTable\') = 1\";\r\n            var result = await ExecuteSelectMany(sql);\r\n        " +
                    "    return result.Any();\r\n        }\r\n\r\n        private async Task<int> GetNextId" +
                    "()\r\n        {\r\n            var sql = @$\"select top 1 column_name\r\n              " +
                    "          from information_schema.columns\r\n                        where table_n" +
                    "ame = \'{Table}\'\r\n                        order by ordinal_position\";\r\n          " +
                    "  var firstColumnName = await db.LoadSingularData<string, dynamic>(sql, new { })" +
                    ";\r\n            if (firstColumnName.ToLower() != \"id\") return 0;\r\n\r\n            s" +
                    "ql = @$\"select top 1 id from {Table} order by 1 desc\";\r\n            var currentI" +
                    "d = await db.LoadSingularData<int, dynamic>(sql, new { });\r\n            return c" +
                    "urrentId + 1;\r\n        }\r\n\r\n        #endregion\r\n    }\r\n}\r\n");
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
    public class DataAccessBaseBase
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
