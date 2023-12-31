﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 11.0.50727.1
// 
namespace LabStatApp.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.StatisticsSoap")]
    public interface StatisticsSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetCurrentStats", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<LabStatApp.ServiceReference1.ArrayOfXElement> GetCurrentStatsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetGroupedCurrentStats", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<LabStatApp.ServiceReference1.GroupStat[]> GetGroupedCurrentStatsAsync();
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18033")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class GroupStat : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int groupIdField;
        
        private string groupNameField;
        
        private int offCountField;
        
        private int availableCountField;
        
        private int unavailableCountField;
        
        private int inUseCountField;
        
        private bool hasPublishedScheduleField;
        
        private int totalCountField;
        
        private string groupDescriptionField;
        
        private float percentInUseField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int groupId {
            get {
                return this.groupIdField;
            }
            set {
                this.groupIdField = value;
                this.RaisePropertyChanged("groupId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string groupName {
            get {
                return this.groupNameField;
            }
            set {
                this.groupNameField = value;
                this.RaisePropertyChanged("groupName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int offCount {
            get {
                return this.offCountField;
            }
            set {
                this.offCountField = value;
                this.RaisePropertyChanged("offCount");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int availableCount {
            get {
                return this.availableCountField;
            }
            set {
                this.availableCountField = value;
                this.RaisePropertyChanged("availableCount");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int unavailableCount {
            get {
                return this.unavailableCountField;
            }
            set {
                this.unavailableCountField = value;
                this.RaisePropertyChanged("unavailableCount");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int inUseCount {
            get {
                return this.inUseCountField;
            }
            set {
                this.inUseCountField = value;
                this.RaisePropertyChanged("inUseCount");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public bool hasPublishedSchedule {
            get {
                return this.hasPublishedScheduleField;
            }
            set {
                this.hasPublishedScheduleField = value;
                this.RaisePropertyChanged("hasPublishedSchedule");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int totalCount {
            get {
                return this.totalCountField;
            }
            set {
                this.totalCountField = value;
                this.RaisePropertyChanged("totalCount");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string groupDescription {
            get {
                return this.groupDescriptionField;
            }
            set {
                this.groupDescriptionField = value;
                this.RaisePropertyChanged("groupDescription");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public float percentInUse {
            get {
                return this.percentInUseField;
            }
            set {
                this.percentInUseField = value;
                this.RaisePropertyChanged("percentInUse");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface StatisticsSoapChannel : LabStatApp.ServiceReference1.StatisticsSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StatisticsSoapClient : System.ServiceModel.ClientBase<LabStatApp.ServiceReference1.StatisticsSoap>, LabStatApp.ServiceReference1.StatisticsSoap {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public StatisticsSoapClient() : 
                base(StatisticsSoapClient.GetDefaultBinding(), StatisticsSoapClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.StatisticsSoap.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public StatisticsSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(StatisticsSoapClient.GetBindingForEndpoint(endpointConfiguration), StatisticsSoapClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public StatisticsSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(StatisticsSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public StatisticsSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(StatisticsSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public StatisticsSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<LabStatApp.ServiceReference1.ArrayOfXElement> GetCurrentStatsAsync() {
            return base.Channel.GetCurrentStatsAsync();
        }
        
        public System.Threading.Tasks.Task<LabStatApp.ServiceReference1.GroupStat[]> GetGroupedCurrentStatsAsync() {
            return base.Channel.GetGroupedCurrentStatsAsync();
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.StatisticsSoap)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.StatisticsSoap)) {
                return new System.ServiceModel.EndpointAddress("http://clc2serv1.ad.siu.edu/labstats/webservices/statistics.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return StatisticsSoapClient.GetBindingForEndpoint(EndpointConfiguration.StatisticsSoap);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return StatisticsSoapClient.GetEndpointAddress(EndpointConfiguration.StatisticsSoap);
        }
        
        public enum EndpointConfiguration {
            
            StatisticsSoap,
        }
    }
    
    [System.Xml.Serialization.XmlSchemaProviderAttribute(null, IsAny=true)]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.ServiceReference.Platforms", "11.0.0.0")]
    public partial class ArrayOfXElement : object, System.Xml.Serialization.IXmlSerializable {
        
        private System.Collections.Generic.List<System.Xml.Linq.XElement> nodesList = new System.Collections.Generic.List<System.Xml.Linq.XElement>();
        
        public ArrayOfXElement() {
        }
        
        public virtual System.Collections.Generic.List<System.Xml.Linq.XElement> Nodes {
            get {
                return this.nodesList;
            }
        }
        
        public virtual System.Xml.Schema.XmlSchema GetSchema() {
            throw new System.NotImplementedException();
        }
        
        public virtual void WriteXml(System.Xml.XmlWriter writer) {
            System.Collections.Generic.IEnumerator<System.Xml.Linq.XElement> e = nodesList.GetEnumerator();
            for (
            ; e.MoveNext(); 
            ) {
                ((System.Xml.Serialization.IXmlSerializable)(e.Current)).WriteXml(writer);
            }
        }
        
        public virtual void ReadXml(System.Xml.XmlReader reader) {
            for (
            ; (reader.NodeType != System.Xml.XmlNodeType.EndElement); 
            ) {
                if ((reader.NodeType == System.Xml.XmlNodeType.Element)) {
                    System.Xml.Linq.XElement elem = new System.Xml.Linq.XElement("default");
                    ((System.Xml.Serialization.IXmlSerializable)(elem)).ReadXml(reader);
                    Nodes.Add(elem);
                }
                else {
                    reader.Skip();
                }
            }
        }
    }
}
