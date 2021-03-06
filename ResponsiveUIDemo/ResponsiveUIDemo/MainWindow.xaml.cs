﻿using System;
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
using System.Threading;
using System.Windows.Threading;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ResponsiveUIDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //  For the Progress Reporting Pattern, we need an object
        //  of type IProgress<T> to use for our marshalling onto the UI thread
        //  Create a progress object IProgress<T> (TAP - Task-based Asynchronous Pattern)
        IProgress<ProgressChangedEventArgs> progress;
        public MainWindow()
        {
            InitializeComponent();

            //  As part of the Progress Reporting Pattern, we need an instance of our
            //  Progress<T> object which implements the IProgress<T> interface
            //  Initialize a Progress<T> object to handle the marshalling functionality
            progress = new Progress<ProgressChangedEventArgs >();

            //  Add a hander to the ProgressChanged event
            ((Progress<ProgressChangedEventArgs >)progress).ProgressChanged += IProgress_Changed;
        }

        /// <summary>
        /// Used for all three demos
        /// </summary>
        public void SomeLongRunningProcess()
        {
            // Simulating a long running function
            Thread.Sleep(20);
        }

        /// <summary>
        /// Used for all three demos
        /// </summary>
        public void SomeOtherLongRunningProcess()
        {
            // Simulating a long running function
            Thread.Sleep(20);
        }

        #region Threadpool Functionality
        private void cmdDispatcher_Click(object sender, RoutedEventArgs e)
        {
            //  This method is executed on the UI thread...I can touch the UI here
            progressBar1.Value = 0;
            //  request a thread from the pool to execute Dispatcher_Thread method
            ThreadPool.QueueUserWorkItem(Dispatcher_Thread);
        }

        private void Dispatcher_Thread(object stateInfo)
        {
            for (int i = 0; i < 100; i++)
            {
                SomeLongRunningProcess();
                SomeOtherLongRunningProcess();

                //  No thouchie!  Must use dispatcher to alter UI 
                //  Passing in an anonymous function to update the UI
                progressBar1.Dispatcher.Invoke(DispatcherPriority.Normal,
                    new Action(() => progressBar1.Value = i + 1));
            }
        }
        #endregion
        #region Background Worker Functionality
        /// <summary>
        /// Background work using the BackgroundWorker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdBackGroundWorker_Click(object sender, RoutedEventArgs e)
        {
            progressBar1.Value = 0;
            //  Create the background worker object
            BackgroundWorker bg = new BackgroundWorker();

            //  Tell it you will be reporting progress
            bg.WorkerReportsProgress = true;

            //  Set the handler for the progress Changed events that fire
            bg.ProgressChanged += new ProgressChangedEventHandler(bg_ProgressChanged);

            //  Set the method to do the work....I just use a lambda here
            bg.DoWork += new DoWorkEventHandler(
                (obj, args) =>
                {
                    //  Do whatever here...just DONT touch the UI
                    for (int i = 0; i < 100; i++)
                    {
                        SomeLongRunningProcess();
                        SomeOtherLongRunningProcess();
                        bg.ReportProgress(i + 1);
                    }
                });

            //  Run it
            bg.RunWorkerAsync();
        }
        /// <summary>
        /// Handles the progress changed events from the BackgroundWorker object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //  This event handler method is automatically marshalled onto the
            //  UI thread so I can touch the UI here without fear.
            progressBar1.Value = e.ProgressPercentage;
        }
        #endregion
        #region Progress Reporting Pattern Functionality (TAP)
        private void cmdTAPMethod_Click(object sender, RoutedEventArgs e)
        {
            //  Either create a Task<> or Use ThreadPool.QueueUserWorkitem()
            progressBar1.Value = 0;
            Task t = Task.Run(() =>
            {
                for (int i = 1; i <= 100; i++)
                {
                    SomeLongRunningProcess();
                    SomeOtherLongRunningProcess();
                    progress.Report(new ProgressChangedEventArgs(i, null));
                }
            });

        }
        void IProgress_Changed(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        #endregion
    }
}
