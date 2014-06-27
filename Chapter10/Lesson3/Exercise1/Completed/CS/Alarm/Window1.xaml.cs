using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Management;

namespace Alarm
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ManagementEventWatcher watcher = null;

        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Event Receiver is a user-defined class.
            EventReceiver receiver = new EventReceiver();

            // Here, we create the watcher and register the callback with it in one shot.
            watcher = GetWatcher(new EventArrivedEventHandler(receiver.OnEventArrived));

            // Watcher starts to listen to the Management Events.
            watcher.Start();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            watcher.Stop();
        }

        public static ManagementEventWatcher GetWatcher(EventArrivedEventHandler handler)
        {
            // Create event query to be notified within 1 second of a change in a service
            WqlEventQuery query = new WqlEventQuery("__InstanceModificationEvent",
                new TimeSpan(0, 0, 1), "TargetInstance isa 'Win32_LocalTime' AND TargetInstance.Second = 0");

            // Initialize an event watcher and subscribe to events that match this query
            ManagementEventWatcher watcher = new ManagementEventWatcher(query);

            // Attach the EventArrived property to EventArrivedEventHandler method with the      
            // required handler to allow watcher object communicate to the application.
            watcher.EventArrived += new EventArrivedEventHandler(handler);
            return watcher;
        }

        // Handle the event and display the ManagementBaseObject properties.
        class EventReceiver
        {
            public void OnEventArrived(object sender, EventArrivedEventArgs e)
            {
                ManagementBaseObject evt = e.NewEvent;

                // Display information from the event
                string time = String.Format("{0:#}{1:00}",
                    ((ManagementBaseObject)evt["TargetInstance"])["Hour"] + ":",
                    ((ManagementBaseObject)evt["TargetInstance"])["Minute"]);

                MessageBox.Show(time, "Current time");
            }
        }
    }
}

