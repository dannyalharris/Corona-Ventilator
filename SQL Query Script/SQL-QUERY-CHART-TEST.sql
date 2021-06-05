USE [Corona-Ventilator-Database]
GO
DECLARE @Counter INT 
SET @Counter=1
WHILE ( @Counter <= 10000)
BEGIN
    INSERT INTO Patient(Timestamp, O2Level) Values ('20100301', @Counter)
    PRINT 'The counter value is = ' + CONVERT(VARCHAR,@Counter)
    SET @Counter  = @Counter  + 1
    WAITFOR DELAY '00:00:01';
END