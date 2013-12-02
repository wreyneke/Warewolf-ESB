﻿using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Dev2.Studio.UI.Tests.UIMaps.DecisionWizardUIMapClasses
{
    using System.Drawing;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;


    public partial class DecisionWizardUIMap : UIMapBase
    {
        /// <summary>
        /// ClickCancel
        /// </summary>
        public void ClickCancel()
        {
            Mouse.Click(StudioWindow.GetChildren()[0].GetChildren()[0], new Point(760, 484));
        }

        /// <summary>
        /// ClickOK
        /// </summary>
        public void ClickDone()
        {
            var wizard = StudioWindow.GetChildren()[0].GetChildren()[0];
            Mouse.Click(wizard, new Point(650, 484));
        }

        /// <summary>
        /// ClickCancel
        /// </summary>
        public void HitDoneWithKeyboard()
        {
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.AllThreads;
            UITestControl decisionDialog = StudioWindow.GetChildren()[0].GetChildren()[0];
            decisionDialog.WaitForControlEnabled();
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.UIThreadOnly;
            // Click middle of the image to set focus
            Mouse.Click(decisionDialog, new Point(decisionDialog.BoundingRectangle.X + decisionDialog.Width / 2, decisionDialog.BoundingRectangle.Y + decisionDialog.Height / 2));
            SendKeys.SendWait("{TAB}");
            Playback.Wait(200);
            SendKeys.SendWait("{ENTER}");
        }

        /// <summary>
        /// Select nth menu item
        /// </summary>
        public void SelectMenuItem(int n)
        {
            for(int i = 0; i < n; i++)
            {
                SendKeys.SendWait("{DOWN}");
            }
        }

        /// <summary>
        /// Send n tabs
        /// </summary>
        public void SendTabs(int n)
        {
            for(int i = 0; i < n; i++)
            {
                Playback.Wait(50);
                SendKeys.SendWait("{TAB}");
            }
        }

        /// <summary>
        /// Gets the first intellisense result
        /// </summary>
        public void GetFirstIntellisense(string startWith, bool deleteText = false, Point relativeToWizard = default(Point))
        {
            var wizard = StudioWindow.GetChildren()[0].GetChildren()[0];

            //prompt intellisense
            SendKeys.SendWait(startWith);

            //wait for intellisense to drop down
            Playback.Wait(500);

            if (relativeToWizard != default(Point) )
            {
                // nasty fixed sizing, but no other real choice to test what  I need to ;(
                Mouse.Click(new Point(wizard.Left + relativeToWizard.X, wizard.Top + relativeToWizard.Y));
            }
            else
            {
                Keyboard.SendKeys(wizard, "{DOWN}");
                Playback.Wait(250);
                Keyboard.SendKeys(wizard, "{ENTER}");     
            }

            if (deleteText)
            {
                SendKeys.SendWait("^a");
                Playback.Wait(150);
                SendKeys.SendWait("^x");
                Playback.Wait(150);
            }
        }
    }
}
