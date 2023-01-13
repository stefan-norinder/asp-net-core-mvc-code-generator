namespace CodeGenerator.Lib.Templates
{
    partial class NLogDevelopmentConfigTemplate
    {
        public NLogDevelopmentConfigTemplate(string server, string datasource)
        {
            _server = server;
            Datasource = datasource;
        }
        private string _server;
        public string Server { get { return _server.Replace(@"\\", @"\"); } }
        public string Datasource { get; }
    }
}
