﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetVulture.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.0.1.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string OutputDir {
            get {
                return ((string)(this["OutputDir"]));
            }
            set {
                this["OutputDir"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("60000")]
        public int Interval {
            get {
                return ((int)(this["Interval"]));
            }
            set {
                this["Interval"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AutoStartTimer {
            get {
                return ((bool)(this["AutoStartTimer"]));
            }
            set {
                this["AutoStartTimer"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AlertingEnabled {
            get {
                return ((bool)(this["AlertingEnabled"]));
            }
            set {
                this["AlertingEnabled"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection TargetAddresses {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["TargetAddresses"]));
            }
            set {
                this["TargetAddresses"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool EmailAlertingEnabled {
            get {
                return ((bool)(this["EmailAlertingEnabled"]));
            }
            set {
                this["EmailAlertingEnabled"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SmsAlertingEnabled {
            get {
                return ((bool)(this["SmsAlertingEnabled"]));
            }
            set {
                this["SmsAlertingEnabled"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" +
            "tring>015222687191</string>\r\n  <string>015771412853</string>\r\n</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection MobileNumbers {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["MobileNumbers"]));
            }
            set {
                this["MobileNumbers"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string GatewayUser {
            get {
                return ((string)(this["GatewayUser"]));
            }
            set {
                this["GatewayUser"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string GatewayPassword {
            get {
                return ((string)(this["GatewayPassword"]));
            }
            set {
                this["GatewayPassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("monitoring.bbs@gmail.com")]
        public string MailUser {
            get {
                return ((string)(this["MailUser"]));
            }
            set {
                this["MailUser"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Moni2015@")]
        public string MailPassword {
            get {
                return ((string)(this["MailPassword"]));
            }
            set {
                this["MailPassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("smtp.gmail.com")]
        public string MailServer {
            get {
                return ((string)(this["MailServer"]));
            }
            set {
                this["MailServer"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("587")]
        public int MailServerPort {
            get {
                return ((int)(this["MailServerPort"]));
            }
            set {
                this["MailServerPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string AutoloadCsvPath {
            get {
                return ((string)(this["AutoloadCsvPath"]));
            }
            set {
                this["AutoloadCsvPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AutoloadCsvEnabled {
            get {
                return ((bool)(this["AutoloadCsvEnabled"]));
            }
            set {
                this["AutoloadCsvEnabled"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string GatewayAccountRef {
            get {
                return ((string)(this["GatewayAccountRef"]));
            }
            set {
                this["GatewayAccountRef"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SendSummeryEnabled {
            get {
                return ((bool)(this["SendSummeryEnabled"]));
            }
            set {
                this["SendSummeryEnabled"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("03/16/2017 21:44:00")]
        public global::System.DateTime SendSummeryTime {
            get {
                return ((global::System.DateTime)(this["SendSummeryTime"]));
            }
            set {
                this["SendSummeryTime"] = value;
            }
        }
    }
}
