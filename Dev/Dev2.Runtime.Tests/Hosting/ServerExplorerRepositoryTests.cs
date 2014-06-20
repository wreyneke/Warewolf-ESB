﻿using Dev2.Common.Wrappers.Interfaces;
using Dev2.Data.ServiceModel;
using Dev2.Explorer;
using Dev2.Interfaces;
using Dev2.Runtime.Hosting;
using Dev2.Runtime.Interfaces;
using Dev2.Runtime.ServiceModel.Data;
using Dev2.Services.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// ReSharper disable InconsistentNaming

namespace Dev2.Tests.Runtime.Hosting
{
    [TestClass]
    public class ServerExplorerRepositoryTests
    {
        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_Constructor")]
        public void ServerExplorerRepository_Constructor_ExpectValid()
        {
            //------------Setup for test--------------------------

            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var catalogue = new Mock<IResourceCatalog>();
            // ReSharper disable ObjectCreationAsStatement
            var sync = new Mock<IExplorerRepositorySync>();
            var repo = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            Assert.AreEqual(repo.Directory, dir.Object);
            Assert.AreEqual(repo.ResourceCatalogue, catalogue.Object);

            // ReSharper restore ObjectCreationAsStatement

        }
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_Constructor")]
        public void ServerExplorerRepository_Constructor_AssertCatalogueNull_ExpectException()
        {
            //------------Setup for test--------------------------

            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();

            // ReSharper disable ObjectCreationAsStatement
            var sync = new Mock<IExplorerRepositorySync>();
            new ServerExplorerRepository(null, factory.Object, dir.Object, sync.Object);
            // ReSharper restore ObjectCreationAsStatement

        }
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_Constructor")]
        public void ServerExplorerRepository_Constructor_AssertfactoryNull_ExpectException()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var dir = new Mock<IDirectory>();

            // ReSharper disable ObjectCreationAsStatement
            var sync = new Mock<IExplorerRepositorySync>();
            new ServerExplorerRepository(catalogue.Object, null, dir.Object, sync.Object);
            // ReSharper restore ObjectCreationAsStatement

        }
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_Constructor")]
        public void ServerExplorerRepository_Constructor_AssertDirectoryNull_ExpectException()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();


            // ReSharper disable ObjectCreationAsStatement
            var sync = new Mock<IExplorerRepositorySync>();
            new ServerExplorerRepository(catalogue.Object, factory.Object, null, sync.Object);
            // ReSharper restore ObjectCreationAsStatement

        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_Load")]
        public void ServerExplorerRepository_Load_AssertRootLevelIsFolder_ExpectFolder()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var explorerItem = new ServerExplorerItem(
                "d", Guid.NewGuid(),
                ResourceType.Folder,
                new List<IExplorerItem>
                    {
                        new ServerExplorerItem("Services", Guid.NewGuid(), ResourceType.Folder,
                                               new List<IExplorerItem>(), Permissions.Administrator, "bob"),
                        new ServerExplorerItem("Bobs", Guid.NewGuid(), ResourceType.Folder, new List<IExplorerItem>(),
                                               Permissions.Administrator, "bob")

                    }
                , Permissions.Administrator, "bob"
                );
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);
            //------------Execute Test---------------------------
            var root = serverExplorerRepository.Load(Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual(root.ResourceType, ResourceType.Folder);
            Assert.AreEqual(2, root.Children.Count);
            Assert.AreEqual(root.Children.First().DisplayName, "Services");
            Assert.AreEqual(root.Children[1].DisplayName, "Bobs");
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_Load")]
        public void ServerExplorerRepository_LoadFiltered_AssertRootLevelIsFolder_ExpectFolder()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var explorerItem = new ServerExplorerItem(
                "d", Guid.NewGuid(),
                ResourceType.Folder,
                new List<IExplorerItem>
                    {
                        new ServerExplorerItem("Services", Guid.NewGuid(), ResourceType.Folder,
                                               new List<IExplorerItem>(), Permissions.Contribute, "bob"),
                        new ServerExplorerItem("Bobs", Guid.NewGuid(), ResourceType.Folder, new List<IExplorerItem>(),
                                               Permissions.Contribute, "bob")

                    }
                , Permissions.Contribute, "bob"
                );
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            factory.Setup(a => a.CreateRootExplorerItem(ResourceType.Folder, It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);
            //------------Execute Test---------------------------
            var root = serverExplorerRepository.Load(ResourceType.Folder, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual(root.ResourceType, ResourceType.Folder);
            Assert.AreEqual(root.Permissions, Permissions.Contribute);
            factory.Verify(a => a.CreateRootExplorerItem(ResourceType.Folder, It.IsAny<string>(), It.IsAny<Guid>()));
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_Load")]
        public void ServerExplorerRepository_Load_FilteredTypeAndPath_AssertRootLevelIsFolder_ExpectFolder()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var explorerItem = new ServerExplorerItem(
                "d", Guid.NewGuid(),
                ResourceType.Folder,
                new List<IExplorerItem>
                    {
                        new ServerExplorerItem("Services", Guid.NewGuid(), ResourceType.Folder,
                                               new List<IExplorerItem>(), Permissions.Administrator, "bob"),
                        new ServerExplorerItem("Bobs", Guid.NewGuid(), ResourceType.Folder, new List<IExplorerItem>(),
                                               Permissions.Administrator, "bob")

                    }
                , Permissions.Administrator, "bob"
                );
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            factory.Setup(a => a.CreateRootExplorerItem(ResourceType.Folder, It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);
            //------------Execute Test---------------------------
            var root = serverExplorerRepository.Load(ResourceType.Folder, "monkey");
            //------------Assert Results-------------------------
            Assert.AreEqual(root.ResourceType, ResourceType.Folder);
            factory.Verify(a => a.CreateRootExplorerItem(ResourceType.Folder, It.IsAny<string>(), It.IsAny<Guid>()));
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_RenameItem")]
        public void ServerExplorerRepository_RenameItem_AssertFolderFails_ExpectErrorMessage()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var explorerItem = new ServerExplorerItem(
                "d", Guid.NewGuid(),
                ResourceType.Folder,
                new List<IExplorerItem>()
                , Permissions.Administrator, "bob"
                );
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.RenameItem(explorerItem, "bob", Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual(result.Message, "Requested folder does not exist on server. Folder: bob");
            Assert.AreEqual(result.Status, ExecStatus.NoMatch);
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_RenameItem")]
        public void ServerExplorerRepository_RenameItem_AssertItemCallCorrectMethods_ExpectErrorMessage()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();
            var res = new Mock<IResource>();
            var explorerItem = new ServerExplorerItem(
                "dave", guid,
                ResourceType.DbSource,
                new List<IExplorerItem>()
                , Permissions.Administrator, "bob"
                );
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);
            catalogue.Setup(a => a.GetResource(It.IsAny<Guid>(), guid, null)).Returns(res.Object);

            catalogue.Setup(a => a.RenameResource(It.IsAny<Guid>(), guid, "dave")).Returns(new ResourceCatalogResult { Message = "moo", Status = ExecStatus.AccessViolation }).Verifiable();
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.RenameItem(explorerItem, "dave", Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual(result.Message, "moo");
            Assert.AreEqual(result.Status, ExecStatus.AccessViolation);
            catalogue.Verify(a => a.RenameResource(It.IsAny<Guid>(), guid, "dave"));
            catalogue.Verify(a => a.GetResourceList(It.IsAny<Guid>()));
        }
        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_RenameItem")]
        public void ServerExplorerRepository_RenameItem_DuplicateExists_AssertItemCallCorrectMethods_ExpectErrorMessage()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();
            var res = new Mock<IResource>();
            res.Setup(a => a.ResourceName).Returns("dave");
            res.Setup(a => a.ResourcePath).Returns("bob");
            var explorerItem = new ServerExplorerItem(
                "dave", guid,
                ResourceType.DbSource,
                new List<IExplorerItem>()
                , Permissions.Administrator, "bob"
                );
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);
            catalogue.Setup(a => a.GetResource(It.IsAny<Guid>(), guid, null)).Returns(res.Object);

            catalogue.Setup(a => a.RenameResource(It.IsAny<Guid>(), guid, "dave")).Returns(new ResourceCatalogResult { Message = "moo", Status = ExecStatus.AccessViolation }).Verifiable();
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.RenameItem(explorerItem, "dave", Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual("There is an item that exists with the same name and path", result.Message);
            Assert.AreEqual(result.Status, ExecStatus.Fail);

        }


        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_DeleteItem")]
        public void ServerExplorerRepository_DeleteItem_AssertItemCallCorrectMethods_ExpectErrorMessage()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();

            var explorerItem = new ServerExplorerItem(
                "dave", guid,
                ResourceType.DbSource,
                new List<IExplorerItem>()
                , Permissions.Administrator, "bob"
                );
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);
            catalogue.Setup(a => a.DeleteResource(It.IsAny<Guid>(), "dave", "DbSource", null)).Returns(new ResourceCatalogResult { Message = "bob", Status = ExecStatus.DuplicateMatch });
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.DeleteItem(explorerItem, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual(result.Message, "bob");
            Assert.AreEqual(result.Status, ExecStatus.DuplicateMatch);
            catalogue.Verify(a => a.DeleteResource(It.IsAny<Guid>(), "dave", "DbSource", null));
        }
        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_DeleteItem")]
        public void ServerExplorerRepository_DeleteItemFolder_AssertItemCallCorrectMethods_ExpectErrorMessage()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();

            var explorerItem = new ServerExplorerItem(
                "dave", guid,
                ResourceType.Folder,
                new List<IExplorerItem>()
                , Permissions.Administrator, "bob"
                );
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.DeleteItem(explorerItem, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual(result.Message, "Requested folder does not exist on server. Folder: bob");
            Assert.AreEqual(result.Status, ExecStatus.Fail);

        }
        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_RenameFolder")]
        public void ServerExplorerRepository_RenameFolder_AssertResourcesAreRenames_FolderRenamedCatalogueSaved()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();
            var res = new Mock<IResource>();
            var explorerItem = new ServerExplorerItem(
                "dave", guid,
                ResourceType.DbSource,
                new List<IExplorerItem>()
                , Permissions.Administrator, "monkey\\dave"
                );
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);

            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(true);
            dir.Setup(a => a.Move(It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });
            catalogue.Setup(a => a.SaveResource(It.IsAny<Guid>(), res.Object, null)).Verifiable();
            res.Setup(a => a.ResourcePath).Returns("monkey\\dave");
            //------------Execute Test---------------------------
            var result = serverExplorerRepository.RenameFolder("monkey", "moocowimpi", Guid.NewGuid());

            //------------Assert Results-------------------------
            Assert.AreEqual(result.Message, "");
            Assert.AreEqual(result.Status, ExecStatus.Success);
            dir.Verify(a => a.Move(It.IsAny<string>(), It.IsAny<string>()));
            catalogue.Verify(a => a.RenameCategory(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }


        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_RenameFolder")]
        public void ServerExplorerRepository_RenameFolder_AssertResourcesAreRenames_EmptyFolderRenamed()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();
            var res = new Mock<IResource>();
            var explorerItem = new ServerExplorerItem(
                "dave", guid,
                ResourceType.DbSource,
                new List<IExplorerItem>()
                , Permissions.Administrator, "bob"
                );
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);

            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(true);
            dir.Setup(a => a.Move(It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });
            catalogue.Setup(a => a.SaveResource(It.IsAny<Guid>(), res.Object, null)).Verifiable();
            res.Setup(a => a.ResourcePath).Returns("monkey2");
            //------------Execute Test---------------------------
            var result = serverExplorerRepository.RenameFolder("monkey", "moocowimpi", Guid.NewGuid());

            //------------Assert Results-------------------------
            Assert.AreEqual(result.Message, "");
            Assert.AreEqual(result.Status, ExecStatus.Success);
            dir.Verify(a => a.Move(It.IsAny<string>(), It.IsAny<string>()));
            catalogue.Verify(a => a.RenameCategory(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_RenameItem")]
        public void ServerExplorerRepository_RenameFolder_FolderDoesNotexist_ExpectFailureMessage()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(false);
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);


            //------------Execute Test---------------------------
            var result = serverExplorerRepository.RenameFolder("monkey", "moocowimpi", Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual(result.Message, "Requested folder does not exist on server. Folder: monkey");
            Assert.AreEqual(result.Status, ExecStatus.NoMatch);

        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_RenameItem")]
        public void ServerExplorerRepository_RenameFolder_FilesystemError_ExpectFailureMessage()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var guid = Guid.NewGuid();

            var explorerItem = new ServerExplorerItem(
                "dave", guid,
                ResourceType.DbSource,
                new List<IExplorerItem>()
                , Permissions.Administrator, "bob"
                );
            factory.Setup(a => a.CreateRootExplorerItem(It.IsAny<string>(), It.IsAny<Guid>())).Returns(explorerItem);

            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(true);
            dir.Setup(a => a.Move(It.IsAny<string>(), It.IsAny<string>())).Throws(new FieldAccessException("bob has an error")).Verifiable();

            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);


            //------------Execute Test---------------------------
            var result = serverExplorerRepository.RenameFolder("monkey", "moocowimpi", Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual(result.Message, "bob has an error");
            Assert.AreEqual(result.Status, ExecStatus.AccessViolation);

        }


        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_RenameItem")]
        public void ServerExplorerRepository_CreateItem_FolderExists_ExpectFailureMessage()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(true);
            var sync = new Mock<IExplorerRepositorySync>();
            sync.Setup(m => m.AddItemMessage(It.IsAny<IExplorerItem>())).Verifiable();
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            var item = new ServerExplorerItem("a", Guid.NewGuid(), ResourceType.Folder, null, Permissions.DeployFrom,
                                              "/bob/dave");

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.AddItem(item, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual(result.Message, "Requested folder already exists on server.");
            Assert.AreEqual(result.Status, ExecStatus.Fail);
            sync.Verify(m => m.AddItemMessage(It.IsAny<IExplorerItem>()), Times.Never());
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_RenameItem")]
        public void ServerExplorerRepository_CreateItem_InvalidItemType_ExpectErrorResult()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(false);
            var sync = new Mock<IExplorerRepositorySync>();
            sync.Setup(m => m.AddItemMessage(It.IsAny<IExplorerItem>())).Verifiable();
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            var item = new ServerExplorerItem("a", Guid.NewGuid(), ResourceType.ReservedService, null, Permissions.DeployFrom,
                                              "/bob/dave");

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.AddItem(item, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual(result.Message, "Only user resources can be added from this repository");
            Assert.AreEqual(result.Status, ExecStatus.Fail);
            sync.Verify(m => m.AddItemMessage(It.IsAny<IExplorerItem>()), Times.Never());
        }


        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_RenameItem")]
        public void ServerExplorerRepository_CreateItem_ValidFolder_ExpectCreatedFolder()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var sync = new Mock<IExplorerRepositorySync>();
            sync.Setup(m => m.AddItemMessage(It.IsAny<IExplorerItem>())).Verifiable();
            var dir = new Mock<IDirectory>();
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(false);
            dir.Setup(a => a.CreateIfNotExists(It.IsAny<string>()));
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            var item = new ServerExplorerItem("a", Guid.NewGuid(), ResourceType.Folder, null, Permissions.DeployFrom,
                                              "/bob/dave");

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.AddItem(item, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual(result.Message, "");
            Assert.AreEqual(result.Status, ExecStatus.Success);
            dir.Verify(a => a.Exists(It.IsAny<string>()));
            dir.Verify(a => a.CreateIfNotExists(It.IsAny<string>()));
            sync.Verify(m => m.AddItemMessage(It.IsAny<IExplorerItem>()), Times.Once());
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_RenameItem")]
        public void ServerExplorerRepository_CreateItem_FileSystemException_ExpectErrorMessageFromException()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(false);
            dir.Setup(a => a.CreateIfNotExists(It.IsAny<string>())).Throws(new FileNotFoundException("bobe"));
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            var item = new ServerExplorerItem("a", Guid.NewGuid(), ResourceType.Folder, null, Permissions.DeployFrom,
                                              "/bob/dave");

            //------------Execute Test---------------------------
            var result = serverExplorerRepository.AddItem(item, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual(result.Message, "bobe");
            Assert.AreEqual(result.Status, ExecStatus.Fail);
            dir.Verify(a => a.Exists(It.IsAny<string>()));
            dir.Verify(a => a.CreateIfNotExists(It.IsAny<string>()));

        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_DeleteFolder")]
        public void ServerExplorerRepository_DeleteFolder_NestedItems_ExpectFailureMessage()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var res = new Mock<IResource>();
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(true);
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });
            //------------Execute Test---------------------------
            res.Setup(a => a.ResourcePath).Returns("bob");
            var result = serverExplorerRepository.DeleteFolder("bob", false, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual(result.Message, "Requested folder contains existing valid resources " + "bob");
            Assert.AreEqual(result.Status, ExecStatus.Fail);

        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_DeleteFolder")]
        public void ServerExplorerRepository_DeleteFolder_NonExistent_ExpectFailureMessage()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var res = new Mock<IResource>();
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(false);
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            //------------Execute Test---------------------------
            res.Setup(a => a.ResourcePath).Returns("bob");
            var result = serverExplorerRepository.DeleteFolder("bob", false, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual(result.Message, "Requested folder does not exist on server. Folder: " + "bob");
            Assert.AreEqual(result.Status, ExecStatus.Fail);

        }
        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_DeleteFolder")]
        public void ServerExplorerRepository_DeleteFolder_Root_ExpectFailureMessage()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var res = new Mock<IResource>();
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(true);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            //------------Execute Test---------------------------
            res.Setup(a => a.ResourcePath).Returns("bob");
            var result = serverExplorerRepository.DeleteFolder("  ", false, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual(result.Message, "You may not delete the root path");
            Assert.AreEqual(result.Status, ExecStatus.Fail);

        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_DeleteFolder")]
        public void ServerExplorerRepository_DeleteFolder_NestedItemsRecursive_ExpectDeletion()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var res = new Mock<IResource>();
            var guid = Guid.NewGuid();
            res.Setup(a => a.ResourceName).Returns("mona");
            res.Setup(a => a.ResourcePath).Returns("bob");
            res.Setup(a => a.ResourceID).Returns(guid);
            res.Setup(a => a.ResourceType).Returns(ResourceType.EmailSource);
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(true);
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });
            catalogue.Setup(a => a.DeleteResource(It.IsAny<Guid>(), "mona", ResourceType.EmailSource.ToString(), null)).Returns(new ResourceCatalogResult { Status = ExecStatus.Success, Message = "" }).Verifiable();
            //------------Execute Test---------------------------
            res.Setup(a => a.ResourcePath).Returns("bob");
            var result = serverExplorerRepository.DeleteFolder("bob", true, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual(result.Message, "");
            Assert.AreEqual(result.Status, ExecStatus.Success);
            catalogue.Verify(a => a.DeleteResource(It.IsAny<Guid>(), "mona", ResourceType.EmailSource.ToString(), null));
            dir.Verify(a => a.Delete(It.IsAny<string>(), true));

        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_DeleteFolder")]
        public void ServerExplorerRepository_DeleteFolder_NestedItemsRecursiveFilesystemError_ExpectError()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var res = new Mock<IResource>();
            var guid = Guid.NewGuid();
            res.Setup(a => a.ResourceName).Returns("mona");
            res.Setup(a => a.ResourcePath).Returns("bob");
            res.Setup(a => a.ResourceID).Returns(guid);
            res.Setup(a => a.ResourceType).Returns(ResourceType.EmailSource);
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(true);
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });
            catalogue.Setup(a => a.DeleteResource(It.IsAny<Guid>(), "mona", ResourceType.EmailSource.ToString(), null)).Returns(new ResourceCatalogResult { Status = ExecStatus.Success, Message = "" }).Verifiable();
            dir.Setup(a => a.Delete(It.IsAny<string>(), true)).Throws(new FieldAccessException("moon"));
            //------------Execute Test---------------------------
            res.Setup(a => a.ResourcePath).Returns("bob");
            var result = serverExplorerRepository.DeleteFolder("bob", true, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual(result.Message, "moon");
            Assert.AreEqual(result.Status, ExecStatus.Fail);
            catalogue.Verify(a => a.DeleteResource(It.IsAny<Guid>(), "mona", ResourceType.EmailSource.ToString(), null));
            dir.Verify(a => a.Delete(It.IsAny<string>(), true));

        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_DeleteFolder")]
        public void ServerExplorerRepository_DeleteFolder_NestedItemsRecursiveNestedFails_ExpectFailue()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var res = new Mock<IResource>();
            var guid = Guid.NewGuid();
            res.Setup(a => a.ResourceName).Returns("mona");
            res.Setup(a => a.ResourcePath).Returns("bob");
            res.Setup(a => a.ResourceID).Returns(guid);
            res.Setup(a => a.ResourceType).Returns(ResourceType.EmailSource);
            dir.Setup(a => a.Exists(It.IsAny<string>())).Returns(true);
            var sync = new Mock<IExplorerRepositorySync>();
            var serverExplorerRepository = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            catalogue.Setup(a => a.GetResourceList(It.IsAny<Guid>())).Returns(new List<IResource> { res.Object });
            catalogue.Setup(a => a.DeleteResource(It.IsAny<Guid>(), "mona", ResourceType.EmailSource.ToString(), null)).Returns(new ResourceCatalogResult { Status = ExecStatus.Fail, Message = "fanta" }).Verifiable();
            //------------Execute Test---------------------------
            res.Setup(a => a.ResourcePath).Returns("bob");
            var result = serverExplorerRepository.DeleteFolder("bob", true, Guid.NewGuid());
            //------------Assert Results-------------------------
            Assert.AreEqual(result.Message, "Failed to delete child items");
            Assert.AreEqual(result.Status, ExecStatus.Fail);
            catalogue.Verify(a => a.DeleteResource(It.IsAny<Guid>(), "mona", ResourceType.EmailSource.ToString(), null));
            dir.Verify(a => a.Delete(It.IsAny<string>(), true), Times.Never());

        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [ExpectedException(typeof(ArgumentNullException))]
        [TestCategory("ServerExplorerRepository_MessageSubscription")]
        public void ServerExplorerRepository_MessageSubscription_ParamIsNull_ThrowsException()
        {
            //------------Setup for test--------------------------
            var catalogue = new Mock<IResourceCatalog>();
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var sync = new Mock<IExplorerRepositorySync>();
            var repo = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            //------------Execute Test---------------------------
            repo.MessageSubscription(null);
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_AddItem")]
        public void ServerExplorerRepository_AddItem_VerifyNullThrowsException()
        {
            //------------Setup for test--------------------------

            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var catalogue = new Mock<IResourceCatalog>();
            // ReSharper disable ObjectCreationAsStatement
            var sync = new Mock<IExplorerRepositorySync>();
            var repo = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            var res = repo.AddItem(null, Guid.NewGuid());
            Assert.AreEqual(res.Status, ExecStatus.Fail);
            Assert.AreEqual(res.Message, "Item to add was null");
            // ReSharper restore ObjectCreationAsStatement

        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_RenameItem")]
        public void ServerExplorerRepository_RenameItem_VerifyNullThrowsException()
        {
            //------------Setup for test--------------------------
            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var catalogue = new Mock<IResourceCatalog>();
            // ReSharper disable ObjectCreationAsStatement
            var sync = new Mock<IExplorerRepositorySync>();
            var repo = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            var res = repo.RenameItem(null, "bob", Guid.NewGuid());
            Assert.AreEqual(res.Status, ExecStatus.Fail);
            Assert.AreEqual(res.Message, "Item to rename was null");
            // ReSharper restore ObjectCreationAsStatement

        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerExplorerRepository_DeleteItem")]
        public void ServerExplorerRepository_AddItem_VerifyDeleteThrowsException()
        {
            //------------Setup for test--------------------------

            var factory = new Mock<IExplorerItemFactory>();
            var dir = new Mock<IDirectory>();
            var catalogue = new Mock<IResourceCatalog>();
            // ReSharper disable ObjectCreationAsStatement
            var sync = new Mock<IExplorerRepositorySync>();
            var repo = new ServerExplorerRepository(catalogue.Object, factory.Object, dir.Object, sync.Object);
            var res = repo.DeleteItem(null, Guid.NewGuid());
            Assert.AreEqual(res.Status, ExecStatus.Fail);
            Assert.AreEqual(res.Message, "Item to delete was null");
            // ReSharper restore ObjectCreationAsStatement

        }
    }
}



