﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rent.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100")]
        public int IrrByItemsPerPage {
            get {
                return ((int)(this["IrrByItemsPerPage"]));
            }
            set {
                this["IrrByItemsPerPage"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("400")]
        public int LessThanInUSD {
            get {
                return ((int)(this["LessThanInUSD"]));
            }
            set {
                this["LessThanInUSD"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("20")]
        public int IrrByItemsPerPageMin {
            get {
                return ((int)(this["IrrByItemsPerPageMin"]));
            }
            set {
                this["IrrByItemsPerPageMin"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public int PollingRandomSleepMin {
            get {
                return ((int)(this["PollingRandomSleepMin"]));
            }
            set {
                this["PollingRandomSleepMin"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("40")]
        public int PollingRandomSleepMax {
            get {
                return ((int)(this["PollingRandomSleepMax"]));
            }
            set {
                this["PollingRandomSleepMax"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UseProxy {
            get {
                return ((bool)(this["UseProxy"]));
            }
            set {
                this["UseProxy"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string MailTo {
            get {
                return ((string)(this["MailTo"]));
            }
            set {
                this["MailTo"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("агенство;агент;agent")]
        public string AdOwnerLoginNameFilter {
            get {
                return ((string)(this["AdOwnerLoginNameFilter"]));
            }
            set {
                this["AdOwnerLoginNameFilter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("агент по;агенство")]
        public string AdDescriptionFilter {
            get {
                return ((string)(this["AdDescriptionFilter"]));
            }
            set {
                this["AdDescriptionFilter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://d-hub.net/Progs/UpdateCheck")]
        public string UpdateSource {
            get {
                return ((string)(this["UpdateSource"]));
            }
            set {
                this["UpdateSource"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ProxyAddress {
            get {
                return ((string)(this["ProxyAddress"]));
            }
            set {
                this["ProxyAddress"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int ProxyPort {
            get {
                return ((int)(this["ProxyPort"]));
            }
            set {
                this["ProxyPort"] = value;
            }
        }
    }
}
