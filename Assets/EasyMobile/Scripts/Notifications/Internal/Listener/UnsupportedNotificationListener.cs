using UnityEngine;
using System;
using System.Collections;

namespace EasyMobile.NotificationsInternal
{
    // Dummy listener used on unsupported platforms.
    internal class UnsupportedNotificationListener : INotificationListener
    {
        // Singleton: we only need one listener object.
        private static UnsupportedNotificationListener sInstance;

        /// <summary>
        /// Gets the listener.
        /// </summary>
        /// <returns>The listener.</returns>
        internal static UnsupportedNotificationListener GetListener()
        {
            if (sInstance == null)
            {
                sInstance = new UnsupportedNotificationListener();
            }
            return sInstance;
        }

        #region INotificationListener Implementation

        #pragma warning disable 0067
        public event Action<LocalNotification> LocalNotificationOpened;

        public event Action<RemoteNotification> RemoteNotificationOpened;
        #pragma warning restore 0067
        
        public string Name
        {
            get { return string.Empty; }
        }

        public NativeNotificationHandler NativeNotificationFromForegroundHandler
        { 
            get
            { 
                return (param) =>
                {
                }; 
            }
        }

        public NativeNotificationHandler NativeNotificationFromBackgroundHandler
        { 
            get
            { 
                return (param) =>
                {
                }; 
            }
        }

        #if EM_ONESIGNAL
        public OneSignal.NotificationReceived OnOneSignalNotificationReceived
        {
            get
            { 
                return (param) =>
                {
                }; 
            }
        }

        public OneSignal.NotificationOpened OnOneSignalNotificationOpened
        {
            get
            { 
                return (param) =>
                {
                };
            }
        }
        #endif

        #if EM_FIR_MESSAGING
        public Action<Firebase.Messaging.MessageReceivedEventArgs> OnFirebaseNotificationReceived
        {
            get
            {
                return (param) =>
                {
                };
            }
        }
        #endif

        #endregion // INotificationListener Implementation
    }
}
    
