/****** Script for SelectTopNRows command from SSMS  ******/


ALTER PROCEDURE  dbo.GetWorkOrders
   @From DATETIME  
  ,@To   DATETIME  
AS
SELECT [WorkOrderId]
      ,WorkOrder.WorkOrderStatusId
	  ,ISNULL(WorkOrderStatus.Color,'WHITE')  AS Color
      ,[MainContat]
      ,[Phone]
      ,[Email]
      ,[Brand]
      ,[Model]
      ,[Year]
      ,[Description]
  FROM 
    WorkOrder
	LEFT  JOIN 
	    WorkOrderStatus 
		ON WorkOrder.WorkOrderStatusId = WorkOrderStatus.WorkOrderStatusId
GO

DECLARE @From DATETIME = GETDATE()
DECLARE @TO DATETIME = GETDATE()

EXEC  dbo.GetWorkOrders   @From , @To