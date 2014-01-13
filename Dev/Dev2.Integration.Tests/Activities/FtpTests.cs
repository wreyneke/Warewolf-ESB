﻿using Dev2.PathOperations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming
namespace Dev2.Integration.Tests.Activities
{
    /// <summary>
    /// Summary description for FtpTests
    /// </summary>
    [TestClass]
    public class FtpTests
    {
        #region ListDirectory Tests
        [TestMethod]
        public void ListDirectoryWithNoUsername_InValidPath_Expected_Error()
        {
            IActivityIOPath path = ActivityIOFactory.CreatePathFromString(ParserStrings.PathOperations_FTP_NoAuth + "DontDelete2/", "", "");
            IActivityIOOperationsEndPoint FTPPro = ActivityIOFactory.CreateOperationEndPointFromIOPath(path);

            try
            {
                IList<IActivityIOPath> tmp = FTPPro.ListDirectory(path);
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.IsTrue(1 == 1);
            }

        }

        [TestMethod]
        public void ListDirectoryWithNoUsername_ValidPath_Expected_List()
        {
            IActivityIOPath path = ActivityIOFactory.CreatePathFromString(ParserStrings.PathOperations_FTP_NoAuth + "DontDelete/", "", "");
            IActivityIOOperationsEndPoint FTPPro = ActivityIOFactory.CreateOperationEndPointFromIOPath(path);
            IList<IActivityIOPath> tmp = FTPPro.ListDirectory(path);

            Assert.IsTrue(tmp.Count == 3);
        }

        [TestMethod]
        public void ListDirectoryWithValidUsername_ValidPath_Expected_List()
        {
            IActivityIOPath path = ActivityIOFactory.CreatePathFromString(ParserStrings.PathOperations_FTP_Auth + "DontDelete/", ParserStrings.PathOperations_Correct_Username, ParserStrings.PathOperations_Correct_Password);
            IActivityIOOperationsEndPoint FTPPro = ActivityIOFactory.CreateOperationEndPointFromIOPath(path);
            IList<IActivityIOPath> tmp = FTPPro.ListDirectory(path);

            Assert.IsTrue(tmp.Count == 3);
        }

        #endregion ListDirectory Tests
    }
}
