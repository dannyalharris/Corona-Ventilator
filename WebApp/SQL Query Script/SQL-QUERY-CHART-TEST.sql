USE [Corona-Ventilator-Database]
GO
DECLARE @Counter INT 
SET @Counter=1
WHILE (1=1)
BEGIN
    INSERT INTO Patient(Timestamp, O2Level) Values ('2021-10-10 10:10:21', @Counter)
    PRINT 'The counter value is = ' + CONVERT(VARCHAR,@Counter)
    SET @Counter  = @Counter  + 1
    WAITFOR DELAY '00:00:01';
END