﻿using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Runtime.Remoting;
using ActivityUnitTests;
using Dev2.Activities;
using Dev2.Common;
using Dev2.Diagnostics;
using Dev2.Runtime.ServiceModel.Data;
using Dev2.TO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

// ReSharper disable InconsistentNaming
namespace Dev2.Tests.Activities.ActivityTests
{

    [TestClass]
    public class SqlBulkInsertActivityTests : BaseActivityUnitTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfSqlBulkInsertActivity_Construct")]
        public void DsfSqlBulkInsertActivity_Construct_Paramterless_InputMappingsNotNull()
        {
            //------------Setup for test--------------------------
            //------------Execute Test---------------------------
            var dsfSqlBulkInsertActivity = new DsfSqlBulkInsertActivity();
            //------------Assert Results-------------------------
            Assert.IsNotNull(dsfSqlBulkInsertActivity);
            Assert.AreEqual("SQL Bulk Insert", dsfSqlBulkInsertActivity.DisplayName);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfSqlBulkInsertActivity_SqlBulkInserter")]
        public void DsfSqlBulkInsertActivity_SqlBulkInserter_NotSet_ReturnsConcreateType()
        {
            //------------Setup for test--------------------------
            var dsfSqlBulkInsertActivity = new DsfSqlBulkInsertActivity();
            //------------Execute Test---------------------------
            var sqlBulkInserter = dsfSqlBulkInsertActivity.SqlBulkInserter;
            //------------Assert Results-------------------------
            Assert.IsInstanceOfType(sqlBulkInserter,typeof(ISqlBulkInserter));
            Assert.IsInstanceOfType(sqlBulkInserter,typeof(SqlBulkInserter));
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfSqlBulkInsertActivity_SqlBulkInserter")]
        public void DsfSqlBulkInsertActivity_SqlBulkInserter_WhenSet_ReturnsSetValue()
        {
            //------------Setup for test--------------------------
            var dsfSqlBulkInsertActivity = new DsfSqlBulkInsertActivity();
            dsfSqlBulkInsertActivity.SqlBulkInserter = new Mock<ISqlBulkInserter>().Object;
            //------------Execute Test---------------------------
            var sqlBulkInserter = dsfSqlBulkInsertActivity.SqlBulkInserter;
            //------------Assert Results-------------------------
            Assert.IsInstanceOfType(sqlBulkInserter,typeof(ISqlBulkInserter));
            Assert.IsNotInstanceOfType(sqlBulkInserter,typeof(SqlBulkInserter));
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfSqlBulkInsertActivity_Execute")]
        public void DsfSqlBulkInsertActivity_Execute_WithNoInputMappings_EmptyDataTableToInsert()
        {
            //------------Setup for test--------------------------
            DataTable returnedDataTable = null;
            var mockSqlBulkInserter = new Mock<ISqlBulkInserter>();
            mockSqlBulkInserter.Setup(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()))
                .Callback<SqlBulkCopy, DataTable>((sqlBulkCopy, dataTable) => returnedDataTable = dataTable);
            SetupArguments("<root><recset1><field1/></recset1></root>", "<root><recset1><field1/></recset1></root>",mockSqlBulkInserter.Object,null,"[[result]]");
            //------------Execute Test---------------------------
            ExecuteProcess();
            //------------Assert Results-------------------------
            mockSqlBulkInserter.Verify(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()),Times.Once());
            Assert.IsNull(returnedDataTable);            
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfSqlBulkInsertActivity_Execute")]
        public void DsfSqlBulkInsertActivity_Execute_OptionsNotSet_HasSqlBulkCopyWithOptionsWithDefaultValues()
        {
            //------------Setup for test--------------------------
            var mockSqlBulkInserter = new Mock<ISqlBulkInserter>();
            SqlBulkCopy returnedSqlBulkCopy = null;
            mockSqlBulkInserter = mockSqlBulkInserter.SetupAllProperties();
            mockSqlBulkInserter.Setup(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>())).Callback<SqlBulkCopy, DataTable>((sqlBulkCopy, dataTable) => returnedSqlBulkCopy = sqlBulkCopy); ;
            SetupArguments("<root><recset1><field1/></recset1></root>", "<root><recset1><field1/></recset1></root>", mockSqlBulkInserter.Object, null, "[[result]]");
            //------------Execute Test---------------------------
            ExecuteProcess();
            //------------Assert Results-------------------------
            mockSqlBulkInserter.Verify(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()), Times.Once());
            Assert.IsNotNull(mockSqlBulkInserter.Object.CurrentOptions);  
            Assert.IsFalse(mockSqlBulkInserter.Object.CurrentOptions.HasFlag(SqlBulkCopyOptions.CheckConstraints));  
            Assert.IsFalse(mockSqlBulkInserter.Object.CurrentOptions.HasFlag(SqlBulkCopyOptions.FireTriggers));  
            Assert.IsFalse(mockSqlBulkInserter.Object.CurrentOptions.HasFlag(SqlBulkCopyOptions.KeepIdentity));  
            Assert.IsFalse(mockSqlBulkInserter.Object.CurrentOptions.HasFlag(SqlBulkCopyOptions.TableLock));  
            Assert.IsFalse(mockSqlBulkInserter.Object.CurrentOptions.HasFlag(SqlBulkCopyOptions.UseInternalTransaction));  
            Assert.IsFalse(mockSqlBulkInserter.Object.CurrentOptions.HasFlag(SqlBulkCopyOptions.KeepNulls));
            Assert.AreEqual(30, returnedSqlBulkCopy.BulkCopyTimeout);
            Assert.AreEqual(0, returnedSqlBulkCopy.BatchSize);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfSqlBulkInsertActivity_Execute")]
        public void DsfSqlBulkInsertActivity_Execute_OptionsSet_HasSqlBulkCopyWithOptionsWithValues()
        {
            //------------Setup for test--------------------------
            var mockSqlBulkInserter = new Mock<ISqlBulkInserter>();
            SqlBulkCopy returnedSqlBulkCopy = null;
            mockSqlBulkInserter = mockSqlBulkInserter.SetupAllProperties();
            mockSqlBulkInserter.Setup(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>())).Callback<SqlBulkCopy, DataTable>((sqlBulkCopy, dataTable) => returnedSqlBulkCopy = sqlBulkCopy);;
            TestStartNode = new FlowStep
            {
                Action = new DsfSqlBulkInsertActivity
                {
                    InputMappings = null, 
                    CheckConstraints = true,
                    FireTriggers = true,
                    KeepIdentity = true,
                    UseInternalTransaction = true,
                    KeepTableLock = true,
                    SqlBulkInserter = mockSqlBulkInserter.Object,
                    Result = "[[result]]"
                }
            };

            CurrentDl = "<root><recset1><field1/></recset1></root>";
            TestData = "<root><recset1><field1/></recset1></root>";
            //------------Execute Test---------------------------
            ExecuteProcess();
            //------------Assert Results-------------------------
            mockSqlBulkInserter.Verify(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()), Times.Once());
            Assert.IsNotNull(mockSqlBulkInserter.Object.CurrentOptions);  
            Assert.IsNotNull(returnedSqlBulkCopy);  
            Assert.IsTrue(mockSqlBulkInserter.Object.CurrentOptions.HasFlag(SqlBulkCopyOptions.CheckConstraints));
            Assert.IsTrue(mockSqlBulkInserter.Object.CurrentOptions.HasFlag(SqlBulkCopyOptions.FireTriggers));
            Assert.IsTrue(mockSqlBulkInserter.Object.CurrentOptions.HasFlag(SqlBulkCopyOptions.KeepIdentity));
            Assert.IsTrue(mockSqlBulkInserter.Object.CurrentOptions.HasFlag(SqlBulkCopyOptions.TableLock));
            Assert.IsTrue(mockSqlBulkInserter.Object.CurrentOptions.HasFlag(SqlBulkCopyOptions.UseInternalTransaction));
            Assert.IsFalse(mockSqlBulkInserter.Object.CurrentOptions.HasFlag(SqlBulkCopyOptions.KeepNulls));
            Assert.AreEqual(30, returnedSqlBulkCopy.BulkCopyTimeout);
            Assert.AreEqual(0, returnedSqlBulkCopy.BatchSize);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfSqlBulkInsertActivity_Execute")]
        public void DsfSqlBulkInsertActivity_Execute_OptionsSetMixed_HasSqlBulkCopyWithOptionsWithValues()
        {
            //------------Setup for test--------------------------
            var mockSqlBulkInserter = new Mock<ISqlBulkInserter>();
            SqlBulkCopy returnedSqlBulkCopy = null;
            mockSqlBulkInserter = mockSqlBulkInserter.SetupAllProperties();
            mockSqlBulkInserter.Setup(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>())).Callback<SqlBulkCopy, DataTable>((sqlBulkCopy, dataTable) => returnedSqlBulkCopy = sqlBulkCopy); ;
            TestStartNode = new FlowStep
            {
                Action = new DsfSqlBulkInsertActivity
                {
                    InputMappings = null, 
                    CheckConstraints = true,
                    FireTriggers = false,
                    KeepIdentity = true,
                    UseInternalTransaction = true,
                    KeepTableLock = false,
                    BatchSize = 10,
                    Timeout = 120,
                    SqlBulkInserter = mockSqlBulkInserter.Object,
                    Result = "[[result]]"
                }
            };

            CurrentDl = "<root><recset1><field1/></recset1></root>";
            TestData = "<root><recset1><field1/></recset1></root>";
            //------------Execute Test---------------------------
            ExecuteProcess();
            //------------Assert Results-------------------------
            mockSqlBulkInserter.Verify(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()), Times.Once());
            Assert.IsNotNull(mockSqlBulkInserter.Object.CurrentOptions);  
            Assert.IsTrue(mockSqlBulkInserter.Object.CurrentOptions.HasFlag(SqlBulkCopyOptions.CheckConstraints));
            Assert.IsFalse(mockSqlBulkInserter.Object.CurrentOptions.HasFlag(SqlBulkCopyOptions.FireTriggers));
            Assert.IsTrue(mockSqlBulkInserter.Object.CurrentOptions.HasFlag(SqlBulkCopyOptions.KeepIdentity));
            Assert.IsFalse(mockSqlBulkInserter.Object.CurrentOptions.HasFlag(SqlBulkCopyOptions.TableLock));
            Assert.IsTrue(mockSqlBulkInserter.Object.CurrentOptions.HasFlag(SqlBulkCopyOptions.UseInternalTransaction));
            Assert.IsFalse(mockSqlBulkInserter.Object.CurrentOptions.HasFlag(SqlBulkCopyOptions.KeepNulls));
            Assert.AreEqual(120, returnedSqlBulkCopy.BulkCopyTimeout);
            Assert.AreEqual(10, returnedSqlBulkCopy.BatchSize); 
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfSqlBulkInsertActivity_Execute")]
        public void DsfSqlBulkInsertActivity_Execute_WithInputMappings_HasDataTableToInsert()
        {
            //------------Setup for test--------------------------
            DataTable returnedDataTable = null;
            var mockSqlBulkInserter = new Mock<ISqlBulkInserter>();
            mockSqlBulkInserter.Setup(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()))
                .Callback<SqlBulkCopy, DataTable>((sqlBulkCopy, dataTable) => returnedDataTable = dataTable);
            var dataColumnMappings = new List<DataColumnMapping>
            {
                new DataColumnMapping
                {
                    InputColumn = "2",
                    OutputColumn = new DbColumn { ColumnName = "TestCol",
                    DataType = typeof(Int32),
                    MaxLength = 100 }
                }
            };
            SetupArguments("<root><recset1><field1/></recset1></root>", "<root><recset1><field1/></recset1></root>",mockSqlBulkInserter.Object,dataColumnMappings, "[[result]]");
            //------------Execute Test---------------------------
            ExecuteProcess();
            //------------Assert Results-------------------------
            mockSqlBulkInserter.Verify(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()),Times.Once());
            Assert.IsNotNull(returnedDataTable);
            Assert.AreEqual(1,returnedDataTable.Columns.Count);
            Assert.AreEqual("TestCol", returnedDataTable.Columns[0].ColumnName);
            Assert.AreEqual(typeof(Int32), returnedDataTable.Columns[0].DataType);
            Assert.AreEqual(-1, returnedDataTable.Columns[0].MaxLength); // Max Length Only applies to strings            
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfSqlBulkInsertActivity_Execute")]
        public void DsfSqlBulkInsertActivity_Execute_WithInputMappingsStringMapping_HasDataTableToInsertWithStringColumnHavingMaxLength()
        {
            //------------Setup for test--------------------------
            DataTable returnedDataTable = null;
            var mockSqlBulkInserter = new Mock<ISqlBulkInserter>();
            mockSqlBulkInserter.Setup(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()))
                .Callback<SqlBulkCopy, DataTable>((sqlBulkCopy, dataTable) => returnedDataTable = dataTable);
            var dataColumnMappings = new List<DataColumnMapping>
            {
                new DataColumnMapping
                {
                    InputColumn = "tests",
                    OutputColumn = new DbColumn { ColumnName = "TestCol",
                    DataType = typeof(String),
                    MaxLength = 100 }
                }
            };
            SetupArguments("<root><recset1><field1/></recset1></root>", "<root><recset1><field1/></recset1></root>",mockSqlBulkInserter.Object,dataColumnMappings, "[[result]]");
            //------------Execute Test---------------------------
            ExecuteProcess();
            //------------Assert Results-------------------------
            mockSqlBulkInserter.Verify(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()),Times.Once());
            Assert.IsNotNull(returnedDataTable);
            Assert.AreEqual(1,returnedDataTable.Columns.Count);
            Assert.AreEqual("TestCol", returnedDataTable.Columns[0].ColumnName);
            Assert.AreEqual(typeof(String), returnedDataTable.Columns[0].DataType);
            Assert.AreEqual(100, returnedDataTable.Columns[0].MaxLength); // Max Length Only applies to strings            
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfSqlBulkInsertActivity_Execute")]
        public void DsfSqlBulkInsertActivity_Execute_WithMultipleInputMappings_HasDataTableWithMultipleColumns()
        {
            //------------Setup for test--------------------------
            DataTable returnedDataTable = null;
            var mockSqlBulkInserter = new Mock<ISqlBulkInserter>();
            mockSqlBulkInserter.Setup(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()))
                .Callback<SqlBulkCopy, DataTable>((sqlBulkCopy, dataTable) => returnedDataTable = dataTable);
            var dataColumnMappings = new List<DataColumnMapping>
            {
                new DataColumnMapping
                {
                    InputColumn = "tests",
                    OutputColumn = new DbColumn { ColumnName = "TestCol",
                    DataType = typeof(String),
                    MaxLength = 100 }
                }, new DataColumnMapping
                {
                    InputColumn = "2",
                    OutputColumn = new DbColumn { ColumnName = "TestCol2",
                    DataType = typeof(Int32),
                    MaxLength = 100 }
                }, new DataColumnMapping
                {
                    InputColumn = "3",
                    OutputColumn = new DbColumn { ColumnName = "TestCol3",
                    DataType = typeof(char),
                    MaxLength = 100 }
                }, new DataColumnMapping
                {
                    InputColumn = "23",
                    OutputColumn = new DbColumn { ColumnName = "TestCol4",
                    DataType = typeof(decimal),
                    MaxLength = 100 }
                }
            };
            SetupArguments("<root><recset1><field1/></recset1></root>", "<root><recset1><field1/></recset1></root>",mockSqlBulkInserter.Object,dataColumnMappings, "[[result]]");
            //------------Execute Test---------------------------
            ExecuteProcess();
            //------------Assert Results-------------------------
            mockSqlBulkInserter.Verify(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()),Times.Once());
            Assert.IsNotNull(returnedDataTable);
            Assert.AreEqual(4,returnedDataTable.Columns.Count);
            
            Assert.AreEqual("TestCol", returnedDataTable.Columns[0].ColumnName);
            Assert.AreEqual(typeof(String), returnedDataTable.Columns[0].DataType);
            Assert.AreEqual(100, returnedDataTable.Columns[0].MaxLength); // Max Length Only applies to strings            

            Assert.AreEqual("TestCol2", returnedDataTable.Columns[1].ColumnName);
            Assert.AreEqual(typeof(Int32), returnedDataTable.Columns[1].DataType);
            Assert.AreEqual(-1, returnedDataTable.Columns[1].MaxLength); // Max Length Only applies to strings            

            Assert.AreEqual("TestCol3", returnedDataTable.Columns[2].ColumnName);
            Assert.AreEqual(typeof(char), returnedDataTable.Columns[2].DataType);
            Assert.AreEqual(-1, returnedDataTable.Columns[2].MaxLength); // Max Length Only applies to strings            

            Assert.AreEqual("TestCol4", returnedDataTable.Columns[3].ColumnName);
            Assert.AreEqual(typeof(decimal), returnedDataTable.Columns[3].DataType);
            Assert.AreEqual(-1, returnedDataTable.Columns[3].MaxLength); // Max Length Only applies to strings            


        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfSqlBulkInsertActivity_Execute")]
        public void DsfSqlBulkInsertActivity_Execute_WithInputMappingsAndDataFromDataListAppend_HasDataTableWithData()
        {
            //------------Setup for test--------------------------
            DataTable returnedDataTable = null;
            var mockSqlBulkInserter = new Mock<ISqlBulkInserter>();
            mockSqlBulkInserter.Setup(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()))
                .Callback<SqlBulkCopy, DataTable>((sqlBulkCopy, dataTable) => returnedDataTable = dataTable);
            var dataColumnMappings = new List<DataColumnMapping>
            {
                new DataColumnMapping
                {
                    InputColumn = "[[recset1().field1]]",
                    OutputColumn = new DbColumn {ColumnName = "TestCol",
                    DataType = typeof(String),
                    MaxLength = 100},
                }, new DataColumnMapping
                {
                    InputColumn = "[[recset1().field2]]",
                    OutputColumn = new DbColumn { ColumnName = "TestCol2",
                    DataType = typeof(Int32),
                    MaxLength = 100 }
                }, new DataColumnMapping
                {
                    InputColumn = "[[recset1().field3]]",
                    OutputColumn = new DbColumn { ColumnName = "TestCol3",
                    DataType = typeof(char),
                    MaxLength = 100 }
                }, new DataColumnMapping
                {
                    InputColumn = "[[recset1().field4]]",
                    OutputColumn = new DbColumn { ColumnName = "TestCol4",
                    DataType = typeof(decimal),
                    MaxLength = 100 }
                }
            };
            SetupArguments("<root><recset1><field1>Bob</field1><field2>2</field2><field3>C</field3><field4>21.2</field4></recset1></root>", "<root><recset1><field1/><field2/><field3/><field4/></recset1></root>", mockSqlBulkInserter.Object, dataColumnMappings, "[[result]]");
            //------------Execute Test---------------------------
            ExecuteProcess();
            //------------Assert Results-------------------------
            mockSqlBulkInserter.Verify(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()), Times.Once());
            Assert.IsNotNull(returnedDataTable);
            Assert.AreEqual(4, returnedDataTable.Columns.Count);
            Assert.AreEqual(1,returnedDataTable.Rows.Count);
            Assert.AreEqual("Bob", returnedDataTable.Rows[0]["TestCol"]);
            Assert.AreEqual(2, returnedDataTable.Rows[0]["TestCol2"]);
            Assert.AreEqual('C', returnedDataTable.Rows[0]["TestCol3"]);
            Assert.AreEqual(21.2m, returnedDataTable.Rows[0]["TestCol4"]);

        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfSqlBulkInsertActivity_Execute")]
        public void DsfSqlBulkInsertActivity_Execute_WithInputMappingsAndDataFromDataListStar_HasDataTableWithData()
        {
            //------------Setup for test--------------------------
            DataTable returnedDataTable = null;
            var mockSqlBulkInserter = new Mock<ISqlBulkInserter>();
            mockSqlBulkInserter.Setup(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()))
                .Callback<SqlBulkCopy, DataTable>((sqlBulkCopy, dataTable) => returnedDataTable = dataTable);
            var dataColumnMappings = new List<DataColumnMapping>
            {
                new DataColumnMapping
                {
                    InputColumn = "[[recset1(*).field1]]",
                    OutputColumn = new DbColumn {ColumnName = "TestCol",
                    DataType = typeof(String),
                    MaxLength = 100},
                }, new DataColumnMapping
                {
                    InputColumn = "[[recset1(*).field2]]",
                    OutputColumn = new DbColumn { ColumnName = "TestCol2",
                    DataType = typeof(Int32),
                    MaxLength = 100 }
                }, new DataColumnMapping
                {
                    InputColumn = "[[recset1(*).field3]]",
                    OutputColumn = new DbColumn { ColumnName = "TestCol3",
                    DataType = typeof(char),
                    MaxLength = 100 }
                }, new DataColumnMapping
                {
                    InputColumn = "[[recset1(*).field4]]",
                    OutputColumn = new DbColumn { ColumnName = "TestCol4",
                    DataType = typeof(decimal),
                    MaxLength = 100 }
                }
            };
            SetupArguments("<root><recset1><field1>Bob</field1><field2>2</field2><field3>C</field3><field4>21.2</field4></recset1><recset1><field1>Jane</field1><field2>3</field2><field3>G</field3><field4>26.4</field4></recset1><recset1><field1>Jill</field1><field2>1999</field2><field3>Z</field3><field4>60</field4></recset1></root>", "<root><recset1><field1/><field2/><field3/><field4/></recset1></root>", mockSqlBulkInserter.Object, dataColumnMappings, "[[result]]");
            //------------Execute Test---------------------------
            ExecuteProcess();
            //------------Assert Results-------------------------
            mockSqlBulkInserter.Verify(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()), Times.Once());
            Assert.IsNotNull(returnedDataTable);
            Assert.AreEqual(4, returnedDataTable.Columns.Count);
            Assert.AreEqual(3,returnedDataTable.Rows.Count);
            
            Assert.AreEqual("Bob", returnedDataTable.Rows[0]["TestCol"]);
            Assert.AreEqual(2, returnedDataTable.Rows[0]["TestCol2"]);
            Assert.AreEqual('C', returnedDataTable.Rows[0]["TestCol3"]);
            Assert.AreEqual(21.2m, returnedDataTable.Rows[0]["TestCol4"]);

            Assert.AreEqual("Jane", returnedDataTable.Rows[1]["TestCol"]);
            Assert.AreEqual(3, returnedDataTable.Rows[1]["TestCol2"]);
            Assert.AreEqual('G', returnedDataTable.Rows[1]["TestCol3"]);
            Assert.AreEqual(26.4m, returnedDataTable.Rows[1]["TestCol4"]);

            Assert.AreEqual("Jill", returnedDataTable.Rows[2]["TestCol"]);
            Assert.AreEqual(1999, returnedDataTable.Rows[2]["TestCol2"]);
            Assert.AreEqual('Z', returnedDataTable.Rows[2]["TestCol3"]);
            Assert.AreEqual(60m, returnedDataTable.Rows[2]["TestCol4"]);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfSqlBulkInsertActivity_Execute")]
        public void DsfSqlBulkInsertActivity_Execute_WithInputMappingsAndDataFromDataListAppendMulitpleRows_HasDataTableWithDataOnlyLastRowFromDataList()
        {
            //------------Setup for test--------------------------
            DataTable returnedDataTable = null;
            var mockSqlBulkInserter = new Mock<ISqlBulkInserter>();
            mockSqlBulkInserter.Setup(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()))
                .Callback<SqlBulkCopy, DataTable>((sqlBulkCopy, dataTable) => returnedDataTable = dataTable);
            var dataColumnMappings = new List<DataColumnMapping>
            {
                new DataColumnMapping
                {
                    InputColumn = "[[recset1().field1]]",
                    OutputColumn = new DbColumn {ColumnName = "TestCol",
                    DataType = typeof(String),
                    MaxLength = 100},
                }, new DataColumnMapping
                {
                    InputColumn = "[[recset1().field2]]",
                    OutputColumn = new DbColumn { ColumnName = "TestCol2",
                    DataType = typeof(Int32),
                    MaxLength = 100 }
                }, new DataColumnMapping
                {
                    InputColumn = "[[recset1().field3]]",
                    OutputColumn = new DbColumn { ColumnName = "TestCol3",
                    DataType = typeof(char),
                    MaxLength = 100 }
                }, new DataColumnMapping
                {
                    InputColumn = "[[recset1().field4]]",
                    OutputColumn = new DbColumn { ColumnName = "TestCol4",
                    DataType = typeof(decimal),
                    MaxLength = 100 }
                }
            };
            SetupArguments("<root><recset1><field1>Bob</field1><field2>2</field2><field3>C</field3><field4>21.2</field4></recset1><recset1><field1>Jane</field1><field2>3</field2><field3>G</field3><field4>26.4</field4></recset1><recset1><field1>Jill</field1><field2>1999</field2><field3>Z</field3><field4>60</field4></recset1></root>", "<root><recset1><field1/><field2/><field3/><field4/></recset1></root>", mockSqlBulkInserter.Object, dataColumnMappings, "[[result]]");
            //------------Execute Test---------------------------
            ExecuteProcess();
            //------------Assert Results-------------------------
            mockSqlBulkInserter.Verify(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()), Times.Once());
            Assert.IsNotNull(returnedDataTable);
            Assert.AreEqual(4, returnedDataTable.Columns.Count);
            Assert.AreEqual(1,returnedDataTable.Rows.Count);

            Assert.AreEqual("Jill", returnedDataTable.Rows[0]["TestCol"]);
            Assert.AreEqual(1999, returnedDataTable.Rows[0]["TestCol2"]);
            Assert.AreEqual('Z', returnedDataTable.Rows[0]["TestCol3"]);
            Assert.AreEqual(60m, returnedDataTable.Rows[0]["TestCol4"]);
        }



        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfSqlBulkInsertActivity_Execute")]
        public void DsfSqlBulkInsertActivity_Execute_WithInputMappingsAndDataFromDataListStarWithOneScalar_HasDataTableWithData()
        {
            //------------Setup for test--------------------------
            DataTable returnedDataTable = null;
            var mockSqlBulkInserter = new Mock<ISqlBulkInserter>();
            mockSqlBulkInserter.Setup(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()))
                .Callback<SqlBulkCopy, DataTable>((sqlBulkCopy, dataTable) => returnedDataTable = dataTable);
            var dataColumnMappings = new List<DataColumnMapping>
            {
                new DataColumnMapping
                {
                    InputColumn = "[[recset1(*).field1]]",
                    OutputColumn = new DbColumn {ColumnName = "TestCol",
                    DataType = typeof(String),
                    MaxLength = 100},
                }, new DataColumnMapping
                {
                    InputColumn = "[[recset1(*).field2]]",
                    OutputColumn = new DbColumn { ColumnName = "TestCol2",
                    DataType = typeof(Int32),
                    MaxLength = 100 }
                }
                , new DataColumnMapping
                {
                    InputColumn = "[[val]]",
                    OutputColumn = new DbColumn { ColumnName = "Val",
                    DataType = typeof(String),
                    MaxLength = 100 }
                },new DataColumnMapping
                {
                    InputColumn = "[[recset1(*).field3]]",
                    OutputColumn = new DbColumn { ColumnName = "TestCol3",
                    DataType = typeof(char),
                    MaxLength = 100 }
                }, new DataColumnMapping
                {
                    InputColumn = "[[recset1(*).field4]]",
                    OutputColumn = new DbColumn { ColumnName = "TestCol4",
                    DataType = typeof(decimal),
                    MaxLength = 100 }
                }
            };
            SetupArguments("<root><recset1><field1>Bob</field1><field2>2</field2><field3>C</field3><field4>21.2</field4></recset1><recset1><field1>Jane</field1><field2>3</field2><field3>G</field3><field4>26.4</field4></recset1><recset1><field1>Jill</field1><field2>1999</field2><field3>Z</field3><field4>60</field4></recset1><val>Hello</val></root>", "<root><recset1><field1/><field2/><field3/><field4/></recset1><val/></root>", mockSqlBulkInserter.Object, dataColumnMappings, "[[result]]");
            //------------Execute Test---------------------------
            ExecuteProcess();
            //------------Assert Results-------------------------
            mockSqlBulkInserter.Verify(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()), Times.Once());
            Assert.IsNotNull(returnedDataTable);
            Assert.AreEqual(5, returnedDataTable.Columns.Count);
            Assert.AreEqual(3, returnedDataTable.Rows.Count);

            Assert.AreEqual("Bob", returnedDataTable.Rows[0]["TestCol"]);
            Assert.AreEqual(2, returnedDataTable.Rows[0]["TestCol2"]);
            Assert.AreEqual('C', returnedDataTable.Rows[0]["TestCol3"]);
            Assert.AreEqual(21.2m, returnedDataTable.Rows[0]["TestCol4"]);
            Assert.AreEqual("Hello", returnedDataTable.Rows[0]["Val"]);

            Assert.AreEqual("Jane", returnedDataTable.Rows[1]["TestCol"]);
            Assert.AreEqual(3, returnedDataTable.Rows[1]["TestCol2"]);
            Assert.AreEqual('G', returnedDataTable.Rows[1]["TestCol3"]);
            Assert.AreEqual(26.4m, returnedDataTable.Rows[1]["TestCol4"]);
            Assert.AreEqual("Hello", returnedDataTable.Rows[1]["Val"]);

            Assert.AreEqual("Jill", returnedDataTable.Rows[2]["TestCol"]);
            Assert.AreEqual(1999, returnedDataTable.Rows[2]["TestCol2"]);
            Assert.AreEqual('Z', returnedDataTable.Rows[2]["TestCol3"]);
            Assert.AreEqual(60m, returnedDataTable.Rows[2]["TestCol4"]);
            Assert.AreEqual("Hello", returnedDataTable.Rows[2]["Val"]);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfSqlBulkInsertActivity_Execute")]
        public void DsfSqlBulkInsertActivity_Execute_WithInputMappingsAndDataFromDataListStarWithOneScalarAndAppend_HasDataTableWithData()
        {
            //------------Setup for test--------------------------
            DataTable returnedDataTable = null;
            var mockSqlBulkInserter = new Mock<ISqlBulkInserter>();
            mockSqlBulkInserter.Setup(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()))
                .Callback<SqlBulkCopy, DataTable>((sqlBulkCopy, dataTable) => returnedDataTable = dataTable);
            var dataColumnMappings = new List<DataColumnMapping>
            {
                new DataColumnMapping
                {
                    InputColumn = "[[recset1(*).field1]]",
                    OutputColumn = new DbColumn {ColumnName = "TestCol",
                    DataType = typeof(String),
                    MaxLength = 100},
                }, new DataColumnMapping
                {
                    InputColumn = "[[recset1().field2]]",
                    OutputColumn = new DbColumn { ColumnName = "TestCol2",
                    DataType = typeof(Int32),
                    MaxLength = 100 }
                }
                , new DataColumnMapping
                {
                    InputColumn = "[[val]]",
                    OutputColumn = new DbColumn { ColumnName = "Val",
                    DataType = typeof(String),
                    MaxLength = 100 }
                },new DataColumnMapping
                {
                    InputColumn = "[[recset1(*).field3]]",
                    OutputColumn = new DbColumn { ColumnName = "TestCol3",
                    DataType = typeof(char),
                    MaxLength = 100 }
                }, new DataColumnMapping
                {
                    InputColumn = "[[recset1(*).field4]]",
                    OutputColumn = new DbColumn { ColumnName = "TestCol4",
                    DataType = typeof(decimal),
                    MaxLength = 100 }
                }
            };
            SetupArguments("<root><recset1><field1>Bob</field1><field2>2</field2><field3>C</field3><field4>21.2</field4></recset1><recset1><field1>Jane</field1><field2>3</field2><field3>G</field3><field4>26.4</field4></recset1><recset1><field1>Jill</field1><field2>1999</field2><field3>Z</field3><field4>60</field4></recset1><val>Hello</val></root>", "<root><recset1><field1/><field2/><field3/><field4/></recset1><val/></root>", mockSqlBulkInserter.Object, dataColumnMappings, "[[result]]");
            //------------Execute Test---------------------------
            ExecuteProcess();
            //------------Assert Results-------------------------
            mockSqlBulkInserter.Verify(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()), Times.Once());
            Assert.IsNotNull(returnedDataTable);
            Assert.AreEqual(5, returnedDataTable.Columns.Count);
            Assert.AreEqual(3, returnedDataTable.Rows.Count);

            Assert.AreEqual("Bob", returnedDataTable.Rows[0]["TestCol"]);
            Assert.AreEqual(1999, returnedDataTable.Rows[0]["TestCol2"]);
            Assert.AreEqual('C', returnedDataTable.Rows[0]["TestCol3"]);
            Assert.AreEqual(21.2m, returnedDataTable.Rows[0]["TestCol4"]);
            Assert.AreEqual("Hello", returnedDataTable.Rows[0]["Val"]);

            Assert.AreEqual("Jane", returnedDataTable.Rows[1]["TestCol"]);
            Assert.AreEqual(1999, returnedDataTable.Rows[1]["TestCol2"]);
            Assert.AreEqual('G', returnedDataTable.Rows[1]["TestCol3"]);
            Assert.AreEqual(26.4m, returnedDataTable.Rows[1]["TestCol4"]);
            Assert.AreEqual("Hello", returnedDataTable.Rows[1]["Val"]);

            Assert.AreEqual("Jill", returnedDataTable.Rows[2]["TestCol"]);
            Assert.AreEqual(1999, returnedDataTable.Rows[2]["TestCol2"]);
            Assert.AreEqual('Z', returnedDataTable.Rows[2]["TestCol3"]);
            Assert.AreEqual(60m, returnedDataTable.Rows[2]["TestCol4"]);
            Assert.AreEqual("Hello", returnedDataTable.Rows[2]["Val"]);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfSqlBulkInsertActivity_Execute")]
        public void DsfSqlBulkInsertActivity_Execute_WithInputMappingsAndDataFromDataListStarWithOneScalarAndAppendMixedRecsets_HasDataTableWithData()
        {
            //------------Setup for test--------------------------
            DataTable returnedDataTable = null;
            var mockSqlBulkInserter = new Mock<ISqlBulkInserter>();
            mockSqlBulkInserter.Setup(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()))
                .Callback<SqlBulkCopy, DataTable>((sqlBulkCopy, dataTable) => returnedDataTable = dataTable);
            var dataColumnMappings = DataColumnMappingsMixedMappings();
            SetupArguments("<root><recset1><field1>Bob</field1><field2>2</field2><field3>C</field3><field4>21.2</field4></recset1><recset1><field1>Jane</field1><field2>3</field2><field3>G</field3><field4>26.4</field4></recset1><recset1><field1>Jill</field1><field2>1999</field2><field3>Z</field3><field4>60</field4></recset1><rec><f1>JJU</f1><f2>89</f2></rec><rec><f1>KKK</f1><f2>67</f2></rec><val>Hello</val></root>", "<root><recset1><field1/><field2/><field3/><field4/></recset1><rec><f1/><f2/></rec><val/></root>", mockSqlBulkInserter.Object, dataColumnMappings, "[[result]]");
            //------------Execute Test---------------------------
            ExecuteProcess();
            //------------Assert Results-------------------------
            mockSqlBulkInserter.Verify(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()), Times.Once());
            Assert.IsNotNull(returnedDataTable);
            Assert.AreEqual(7, returnedDataTable.Columns.Count);
            Assert.AreEqual(3, returnedDataTable.Rows.Count);

            Assert.AreEqual("Bob", returnedDataTable.Rows[0]["TestCol"]);
            Assert.AreEqual(1999, returnedDataTable.Rows[0]["TestCol2"]);
            Assert.AreEqual('C', returnedDataTable.Rows[0]["TestCol3"]);
            Assert.AreEqual(21.2m, returnedDataTable.Rows[0]["TestCol4"]);
            Assert.AreEqual("Hello", returnedDataTable.Rows[0]["Val"]);
            Assert.AreEqual("JJU", returnedDataTable.Rows[0]["Col1"]);
            Assert.AreEqual(67, returnedDataTable.Rows[0]["Col2"]);

            Assert.AreEqual("Jane", returnedDataTable.Rows[1]["TestCol"]);
            Assert.AreEqual(1999, returnedDataTable.Rows[1]["TestCol2"]);
            Assert.AreEqual('G', returnedDataTable.Rows[1]["TestCol3"]);
            Assert.AreEqual(26.4m, returnedDataTable.Rows[1]["TestCol4"]);
            Assert.AreEqual("Hello", returnedDataTable.Rows[1]["Val"]);
            Assert.AreEqual("KKK", returnedDataTable.Rows[1]["Col1"]);
            Assert.AreEqual(67, returnedDataTable.Rows[1]["Col2"]);

            Assert.AreEqual("Jill", returnedDataTable.Rows[2]["TestCol"]);
            Assert.AreEqual(1999, returnedDataTable.Rows[2]["TestCol2"]);
            Assert.AreEqual('Z', returnedDataTable.Rows[2]["TestCol3"]);
            Assert.AreEqual(60m, returnedDataTable.Rows[2]["TestCol4"]);
            Assert.AreEqual("Hello", returnedDataTable.Rows[2]["Val"]);
            Assert.AreEqual("KKK", returnedDataTable.Rows[2]["Col1"]);
            Assert.AreEqual(67, returnedDataTable.Rows[2]["Col2"]);
        }


        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfSqlBulkInsertActivity_Execute")]
        public void DsfSqlBulkInsertActivity_Execute_WithInputMappingsAndDataFromDataListStarWithOneScalarAndAppendMixedRecsets_HasDebug()
        {
            //------------Setup for test--------------------------
            var mockSqlBulkInserter = new Mock<ISqlBulkInserter>();
            mockSqlBulkInserter.Setup(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()));
            var dataColumnMappings = DataColumnMappingsMixedMappings();
            const string dataListWithData = "<root><recset1><field1>Bob</field1><field2>2</field2><field3>C</field3><field4>21.2</field4></recset1><recset1><field1>Jane</field1><field2>3</field2><field3>G</field3><field4>26.4</field4></recset1><recset1><field1>Jill</field1><field2>1999</field2><field3>Z</field3><field4>60</field4></recset1><rec><f1>JJU</f1><f2>89</f2></rec><rec><f1>KKK</f1><f2>67</f2></rec><val>Hello</val></root>";
            const string dataListShape = "<root><recset1><field1/><field2/><field3/><field4/></recset1><rec><f1/><f2/></rec><val/></root>";
            SetupArguments(dataListWithData, dataListShape, mockSqlBulkInserter.Object, dataColumnMappings, "[[result]]");
            var act = new DsfSqlBulkInsertActivity
            {
                SqlBulkInserter = mockSqlBulkInserter.Object,
                InputMappings = dataColumnMappings,
                Result = "[[result]]"
            };
            List<DebugItem> inRes;
            List<DebugItem> outRes;
            //------------Execute Test---------------------------
            var result = CheckActivityDebugInputOutput(act, dataListShape,dataListWithData, out inRes, out outRes);
            //------------Assert Results-------------------------
            mockSqlBulkInserter.Verify(inserter => inserter.Insert(It.IsAny<SqlBulkCopy>(), It.IsAny<DataTable>()), Times.Once());
            Assert.AreEqual(7, inRes.Count);
            var debugInputs = inRes[0].FetchResultsList();

            Assert.AreEqual(12,debugInputs.Count);
            Assert.AreEqual("1",debugInputs[0].Value);
            Assert.AreEqual(DebugItemResultType.Label,debugInputs[0].Type);

            Assert.AreEqual("Insert Into",debugInputs[1].Value);
            Assert.AreEqual(DebugItemResultType.Label, debugInputs[1].Type);

            Assert.AreEqual("TestCol System.String(100)", debugInputs[2].Value);
            Assert.AreEqual(DebugItemResultType.Variable, debugInputs[2].Type);

            Assert.AreEqual("[[recset1(1).field1]]", debugInputs[3].Value);
            Assert.AreEqual(DebugItemResultType.Variable, debugInputs[3].Type);
            Assert.AreEqual(GlobalConstants.EqualsExpression, debugInputs[4].Value);
            Assert.AreEqual(DebugItemResultType.Label, debugInputs[4].Type);
            Assert.AreEqual("Bob", debugInputs[5].Value);
            Assert.AreEqual(DebugItemResultType.Value, debugInputs[5].Type);

            Assert.AreEqual("[[recset1(2).field1]]", debugInputs[6].Value);
            Assert.AreEqual(DebugItemResultType.Variable, debugInputs[6].Type);
            Assert.AreEqual(GlobalConstants.EqualsExpression, debugInputs[7].Value);
            Assert.AreEqual(DebugItemResultType.Label, debugInputs[7].Type);
            Assert.AreEqual("Jane", debugInputs[8].Value);
            Assert.AreEqual(DebugItemResultType.Value, debugInputs[8].Type); 
            
            Assert.AreEqual("[[recset1(3).field1]]", debugInputs[9].Value);
            Assert.AreEqual(DebugItemResultType.Variable, debugInputs[9].Type);
            Assert.AreEqual(GlobalConstants.EqualsExpression, debugInputs[10].Value);
            Assert.AreEqual(DebugItemResultType.Label, debugInputs[10].Type);
            Assert.AreEqual("Jill", debugInputs[11].Value);
            Assert.AreEqual(DebugItemResultType.Value, debugInputs[11].Type);

            debugInputs = inRes[1].FetchResultsList();

            DataListRemoval(result.DataListID);
        }

        static List<DataColumnMapping> DataColumnMappingsMixedMappings()
        {
            var dataColumnMappings = new List<DataColumnMapping>
            {
                new DataColumnMapping
                {
                    InputColumn = "[[recset1(*).field1]]",
                    OutputColumn = new DbColumn
                    {
                        ColumnName = "TestCol",
                        DataType = typeof(String),
                        MaxLength = 100
                    },
                },
                new DataColumnMapping
                {
                    InputColumn = "[[recset1().field2]]",
                    OutputColumn = new DbColumn
                    {
                        ColumnName = "TestCol2",
                        DataType = typeof(Int32),
                        MaxLength = 100
                    }
                }
                , new DataColumnMapping
                {
                    InputColumn = "[[rec().f2]]",
                    OutputColumn = new DbColumn
                    {
                        ColumnName = "Col2",
                        DataType = typeof(Int32),
                        MaxLength = 100
                    }
                }
                , new DataColumnMapping
                {
                    InputColumn = "[[val]]",
                    OutputColumn = new DbColumn
                    {
                        ColumnName = "Val",
                        DataType = typeof(String),
                        MaxLength = 100
                    }
                }
                , new DataColumnMapping
                {
                    InputColumn = "[[rec(*).f1]]",
                    OutputColumn = new DbColumn
                    {
                        ColumnName = "Col1",
                        DataType = typeof(string),
                        MaxLength = 100
                    }
                },
                new DataColumnMapping
                {
                    InputColumn = "[[recset1(*).field3]]",
                    OutputColumn = new DbColumn
                    {
                        ColumnName = "TestCol3",
                        DataType = typeof(char),
                        MaxLength = 100
                    }
                },
                new DataColumnMapping
                {
                    InputColumn = "[[recset1(*).field4]]",
                    OutputColumn = new DbColumn
                    {
                        ColumnName = "TestCol4",
                        DataType = typeof(decimal),
                        MaxLength = 100
                    }
                }
            };
            return dataColumnMappings;
        }

        #region Private Test Methods

        private void SetupArguments(string currentDL, string testData,ISqlBulkInserter sqlBulkInserter, IList<DataColumnMapping> inputMappings, string resultString)
        {
            TestStartNode = new FlowStep
            {
                Action = new DsfSqlBulkInsertActivity
                {
                    InputMappings = inputMappings, 
                    SqlBulkInserter = sqlBulkInserter,
                    Result = resultString
                }
            };

            CurrentDl = testData;
            TestData = currentDL;
        }

        #endregion Private Test Methods
    }
}