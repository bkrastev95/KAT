﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.36264
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KAT.Services.DriverWebServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Driver", Namespace="http://schemas.datacontract.org/2004/07/KAT.Web.Models")]
    [System.SerializableAttribute()]
    public partial class Driver : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SecondNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SecondName {
            get {
                return this.SecondNameField;
            }
            set {
                if ((object.ReferenceEquals(this.SecondNameField, value) != true)) {
                    this.SecondNameField = value;
                    this.RaisePropertyChanged("SecondName");
                }
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DriverWebServiceReference.IDriverWebService")]
    public interface IDriverWebService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDriverWebService/GetDriver", ReplyAction="http://tempuri.org/IDriverWebService/GetDriverResponse")]
        KAT.Services.DriverWebServiceReference.Driver GetDriver(long value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDriverWebService/GetDriver", ReplyAction="http://tempuri.org/IDriverWebService/GetDriverResponse")]
        System.Threading.Tasks.Task<KAT.Services.DriverWebServiceReference.Driver> GetDriverAsync(long value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDriverWebService/InsertDriver", ReplyAction="http://tempuri.org/IDriverWebService/InsertDriverResponse")]
        long InsertDriver(KAT.Services.DriverWebServiceReference.Driver driver);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDriverWebService/InsertDriver", ReplyAction="http://tempuri.org/IDriverWebService/InsertDriverResponse")]
        System.Threading.Tasks.Task<long> InsertDriverAsync(KAT.Services.DriverWebServiceReference.Driver driver);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDriverWebServiceChannel : KAT.Services.DriverWebServiceReference.IDriverWebService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DriverWebServiceClient : System.ServiceModel.ClientBase<KAT.Services.DriverWebServiceReference.IDriverWebService>, KAT.Services.DriverWebServiceReference.IDriverWebService {
        
        public DriverWebServiceClient() {
        }
        
        public DriverWebServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DriverWebServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DriverWebServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DriverWebServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public KAT.Services.DriverWebServiceReference.Driver GetDriver(long value) {
            return base.Channel.GetDriver(value);
        }
        
        public System.Threading.Tasks.Task<KAT.Services.DriverWebServiceReference.Driver> GetDriverAsync(long value) {
            return base.Channel.GetDriverAsync(value);
        }
        
        public long InsertDriver(KAT.Services.DriverWebServiceReference.Driver driver) {
            return base.Channel.InsertDriver(driver);
        }
        
        public System.Threading.Tasks.Task<long> InsertDriverAsync(KAT.Services.DriverWebServiceReference.Driver driver) {
            return base.Channel.InsertDriverAsync(driver);
        }
    }
}
