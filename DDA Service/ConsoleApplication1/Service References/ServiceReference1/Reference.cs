﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication1.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DispatcherObject", Namespace="http://schemas.datacontract.org/2004/07/System.Windows.Threading")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.DependencyObject))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.Freezable))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.Animatable))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.GeneralTransform))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.Transform))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.ImageSource))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.Brush))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.TileBrush))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.ImageBrush))]
    public partial class DispatcherObject : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DependencyObject", Namespace="http://schemas.datacontract.org/2004/07/System.Windows")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.Freezable))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.Animatable))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.GeneralTransform))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.Transform))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.ImageSource))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.Brush))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.TileBrush))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.ImageBrush))]
    public partial class DependencyObject : ConsoleApplication1.ServiceReference1.DispatcherObject {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Freezable", Namespace="http://schemas.datacontract.org/2004/07/System.Windows")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.Animatable))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.GeneralTransform))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.Transform))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.ImageSource))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.Brush))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.TileBrush))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.ImageBrush))]
    public partial class Freezable : ConsoleApplication1.ServiceReference1.DependencyObject {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Animatable", Namespace="http://schemas.datacontract.org/2004/07/System.Windows.Media.Animation")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.GeneralTransform))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.Transform))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.ImageSource))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.Brush))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.TileBrush))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.ImageBrush))]
    public partial class Animatable : ConsoleApplication1.ServiceReference1.Freezable {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GeneralTransform", Namespace="http://schemas.datacontract.org/2004/07/System.Windows.Media")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.Transform))]
    public partial class GeneralTransform : ConsoleApplication1.ServiceReference1.Animatable {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Transform", Namespace="http://schemas.datacontract.org/2004/07/System.Windows.Media")]
    [System.SerializableAttribute()]
    public partial class Transform : ConsoleApplication1.ServiceReference1.GeneralTransform {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ImageSource", Namespace="http://schemas.datacontract.org/2004/07/System.Windows.Media")]
    [System.SerializableAttribute()]
    public partial class ImageSource : ConsoleApplication1.ServiceReference1.Animatable {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Brush", Namespace="http://schemas.datacontract.org/2004/07/System.Windows.Media")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.TileBrush))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.ImageBrush))]
    public partial class Brush : ConsoleApplication1.ServiceReference1.Animatable {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double OpacityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsoleApplication1.ServiceReference1.Transform RelativeTransformField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsoleApplication1.ServiceReference1.Transform TransformField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Opacity {
            get {
                return this.OpacityField;
            }
            set {
                if ((this.OpacityField.Equals(value) != true)) {
                    this.OpacityField = value;
                    this.RaisePropertyChanged("Opacity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsoleApplication1.ServiceReference1.Transform RelativeTransform {
            get {
                return this.RelativeTransformField;
            }
            set {
                if ((object.ReferenceEquals(this.RelativeTransformField, value) != true)) {
                    this.RelativeTransformField = value;
                    this.RaisePropertyChanged("RelativeTransform");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsoleApplication1.ServiceReference1.Transform Transform {
            get {
                return this.TransformField;
            }
            set {
                if ((object.ReferenceEquals(this.TransformField, value) != true)) {
                    this.TransformField = value;
                    this.RaisePropertyChanged("Transform");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TileBrush", Namespace="http://schemas.datacontract.org/2004/07/System.Windows.Media")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsoleApplication1.ServiceReference1.ImageBrush))]
    public partial class TileBrush : ConsoleApplication1.ServiceReference1.Brush {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsoleApplication1.ServiceReference1.AlignmentX AlignmentXField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsoleApplication1.ServiceReference1.AlignmentY AlignmentYField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsoleApplication1.ServiceReference1.Stretch StretchField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsoleApplication1.ServiceReference1.TileMode TileModeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsoleApplication1.ServiceReference1.Rect ViewboxField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsoleApplication1.ServiceReference1.BrushMappingMode ViewboxUnitsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsoleApplication1.ServiceReference1.Rect ViewportField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsoleApplication1.ServiceReference1.BrushMappingMode ViewportUnitsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsoleApplication1.ServiceReference1.AlignmentX AlignmentX {
            get {
                return this.AlignmentXField;
            }
            set {
                if ((this.AlignmentXField.Equals(value) != true)) {
                    this.AlignmentXField = value;
                    this.RaisePropertyChanged("AlignmentX");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsoleApplication1.ServiceReference1.AlignmentY AlignmentY {
            get {
                return this.AlignmentYField;
            }
            set {
                if ((this.AlignmentYField.Equals(value) != true)) {
                    this.AlignmentYField = value;
                    this.RaisePropertyChanged("AlignmentY");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsoleApplication1.ServiceReference1.Stretch Stretch {
            get {
                return this.StretchField;
            }
            set {
                if ((this.StretchField.Equals(value) != true)) {
                    this.StretchField = value;
                    this.RaisePropertyChanged("Stretch");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsoleApplication1.ServiceReference1.TileMode TileMode {
            get {
                return this.TileModeField;
            }
            set {
                if ((this.TileModeField.Equals(value) != true)) {
                    this.TileModeField = value;
                    this.RaisePropertyChanged("TileMode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsoleApplication1.ServiceReference1.Rect Viewbox {
            get {
                return this.ViewboxField;
            }
            set {
                if ((this.ViewboxField.Equals(value) != true)) {
                    this.ViewboxField = value;
                    this.RaisePropertyChanged("Viewbox");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsoleApplication1.ServiceReference1.BrushMappingMode ViewboxUnits {
            get {
                return this.ViewboxUnitsField;
            }
            set {
                if ((this.ViewboxUnitsField.Equals(value) != true)) {
                    this.ViewboxUnitsField = value;
                    this.RaisePropertyChanged("ViewboxUnits");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsoleApplication1.ServiceReference1.Rect Viewport {
            get {
                return this.ViewportField;
            }
            set {
                if ((this.ViewportField.Equals(value) != true)) {
                    this.ViewportField = value;
                    this.RaisePropertyChanged("Viewport");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsoleApplication1.ServiceReference1.BrushMappingMode ViewportUnits {
            get {
                return this.ViewportUnitsField;
            }
            set {
                if ((this.ViewportUnitsField.Equals(value) != true)) {
                    this.ViewportUnitsField = value;
                    this.RaisePropertyChanged("ViewportUnits");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ImageBrush", Namespace="http://schemas.datacontract.org/2004/07/System.Windows.Media")]
    [System.SerializableAttribute()]
    public partial class ImageBrush : ConsoleApplication1.ServiceReference1.TileBrush {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsoleApplication1.ServiceReference1.ImageSource ImageSourceField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsoleApplication1.ServiceReference1.ImageSource ImageSource {
            get {
                return this.ImageSourceField;
            }
            set {
                if ((object.ReferenceEquals(this.ImageSourceField, value) != true)) {
                    this.ImageSourceField = value;
                    this.RaisePropertyChanged("ImageSource");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Rect", Namespace="http://schemas.datacontract.org/2004/07/System.Windows")]
    [System.SerializableAttribute()]
    public partial struct Rect : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private double _heightField;
        
        private double _widthField;
        
        private double _xField;
        
        private double _yField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public double _height {
            get {
                return this._heightField;
            }
            set {
                if ((this._heightField.Equals(value) != true)) {
                    this._heightField = value;
                    this.RaisePropertyChanged("_height");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public double _width {
            get {
                return this._widthField;
            }
            set {
                if ((this._widthField.Equals(value) != true)) {
                    this._widthField = value;
                    this.RaisePropertyChanged("_width");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public double _x {
            get {
                return this._xField;
            }
            set {
                if ((this._xField.Equals(value) != true)) {
                    this._xField = value;
                    this.RaisePropertyChanged("_x");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public double _y {
            get {
                return this._yField;
            }
            set {
                if ((this._yField.Equals(value) != true)) {
                    this._yField = value;
                    this.RaisePropertyChanged("_y");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AlignmentX", Namespace="http://schemas.datacontract.org/2004/07/System.Windows.Media")]
    public enum AlignmentX : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Left = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Center = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Right = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AlignmentY", Namespace="http://schemas.datacontract.org/2004/07/System.Windows.Media")]
    public enum AlignmentY : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Top = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Center = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Bottom = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Stretch", Namespace="http://schemas.datacontract.org/2004/07/System.Windows.Media")]
    public enum Stretch : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        None = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Fill = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Uniform = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UniformToFill = 3,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TileMode", Namespace="http://schemas.datacontract.org/2004/07/System.Windows.Media")]
    public enum TileMode : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        None = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Tile = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FlipX = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FlipY = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FlipXY = 3,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BrushMappingMode", Namespace="http://schemas.datacontract.org/2004/07/System.Windows.Media")]
    public enum BrushMappingMode : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Absolute = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RelativeToBoundingBox = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService", CallbackContract=typeof(ConsoleApplication1.ServiceReference1.IServiceCallback))]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ConnectTest", ReplyAction="http://tempuri.org/IService/ConnectTestResponse")]
        bool ConnectTest();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ConnectTest", ReplyAction="http://tempuri.org/IService/ConnectTestResponse")]
        System.Threading.Tasks.Task<bool> ConnectTestAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddMember", ReplyAction="http://tempuri.org/IService/AddMemberResponse")]
        bool AddMember(string email, string pw, string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddMember", ReplyAction="http://tempuri.org/IService/AddMemberResponse")]
        System.Threading.Tasks.Task<bool> AddMemberAsync(string email, string pw, string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Connect", ReplyAction="http://tempuri.org/IService/ConnectResponse")]
        void Connect(int mid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Connect", ReplyAction="http://tempuri.org/IService/ConnectResponse")]
        System.Threading.Tasks.Task ConnectAsync(int mid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Login", ReplyAction="http://tempuri.org/IService/LoginResponse")]
        int Login(string email, string pw);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Login", ReplyAction="http://tempuri.org/IService/LoginResponse")]
        System.Threading.Tasks.Task<int> LoginAsync(string email, string pw);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/LoginOverlap", ReplyAction="http://tempuri.org/IService/LoginOverlapResponse")]
        bool LoginOverlap(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/LoginOverlap", ReplyAction="http://tempuri.org/IService/LoginOverlapResponse")]
        System.Threading.Tasks.Task<bool> LoginOverlapAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/LogOut", ReplyAction="http://tempuri.org/IService/LogOutResponse")]
        bool LogOut(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/LogOut", ReplyAction="http://tempuri.org/IService/LogOutResponse")]
        System.Threading.Tasks.Task<bool> LogOutAsync(string email);
        
         
        
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceCallback {
          
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/UserEnter")]
        void UserEnter(string name);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/UserLeave")]
        void UserLeave(string name);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/Finished")]
        void Finished(bool result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : ConsoleApplication1.ServiceReference1.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.DuplexClientBase<ConsoleApplication1.ServiceReference1.IService>, ConsoleApplication1.ServiceReference1.IService {
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public bool ConnectTest() {
            return base.Channel.ConnectTest();
        }
        
        public System.Threading.Tasks.Task<bool> ConnectTestAsync() {
            return base.Channel.ConnectTestAsync();
        }
        
        public bool AddMember(string email, string pw, string name) {
            return base.Channel.AddMember(email, pw, name);
        }
        
        public System.Threading.Tasks.Task<bool> AddMemberAsync(string email, string pw, string name) {
            return base.Channel.AddMemberAsync(email, pw, name);
        }
        
        public void Connect(int mid) {
            base.Channel.Connect(mid);
        }
        
        public System.Threading.Tasks.Task ConnectAsync(int mid) {
            return base.Channel.ConnectAsync(mid);
        }
        
        public int Login(string email, string pw) {
            return base.Channel.Login(email, pw);
        }
        
        public System.Threading.Tasks.Task<int> LoginAsync(string email, string pw) {
            return base.Channel.LoginAsync(email, pw);
        }
        
        public bool LoginOverlap(string email) {
            return base.Channel.LoginOverlap(email);
        }
        
        public System.Threading.Tasks.Task<bool> LoginOverlapAsync(string email) {
            return base.Channel.LoginOverlapAsync(email);
        }
        
        public bool LogOut(string email) {
            return base.Channel.LogOut(email);
        }
        
        public System.Threading.Tasks.Task<bool> LogOutAsync(string email) {
            return base.Channel.LogOutAsync(email);
        }        
       
    }
}
