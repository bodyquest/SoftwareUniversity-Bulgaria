
CREATE VIEW v_PublicPaymentInfo AS
SELECT 
	 CustomerID
	,FirstName
	,LastName
	,LEFT(PaymentNumber, 6) + '************' AS [Payment Number]
	--CONCAT(LEFT(PaymentNumber, 6), REPLICATE('*', LEN(PaymentNumber) - 6)) AS PaymentNumber
	FROM Customers

SELECT * FROM v_PublicPaymentInfo

----------------------------------

SELECT CHARINDEX('is', 'This is a very long string', 4)

----------------------------------

SELECT STUFF('This is a bad idea', 11, 0, 'very ' )

----------------------------------

SELECT FORMAT (67.23, 'C', 'bg-BG')
SELECT FORMAT (CAST('2019-09-05' AS date), 'D', 'de-DE')
SELECT FORMAT (CAST('2019-09-05' AS date), N'dd.MM.yyyy г.', 'bg-BG')

----------------------------------

SELECT TRANSLATE (N'проба', N'абвгдезиклмнопрстуфхцю', 'abvgdeziklmnoprstufhc')

----------------------------------

SELECT Id, X1, Y1, X2, Y2,
	SQRT(SQUARE(X1-X2) + SQUARE(Y1-Y2))
	AS Length
  FROM Lines

----------------------------------

SELECT ROUND(1.9, 0)  --round to 2.0

----------------------------------

SELECT
  [Name]
  ,Quantity 
  ,BoxCapacity
  ,CEILING
	  (CEILING
	    (CAST(Quantity AS float) /BoxCapacity)/ PalletCapacity)
        AS [Number of Pallets]
   FROM Products 

----------------------------------

SELECT DATEPART(WEEK, '2019-09-06')

----------------------------------

SELECT
  ProductName
  ,YEAR(OrderDate) AS [Year]
  ,MONTH(OrderDate) AS [Month]
  ,DAY(OrderDate) AS [Day]
  ,DATEPART(QUARTER, OrderDate) AS [Q]
FROM Orders

----------------------------------

SELECT DATEDIFF(SECOND, '1973-12-16T17:00:00', '2021-06-28T19:40:00')
-- 1 500 000 000 s Radi's Age at Seconds

----------------------------------

SELECT [Name]
  , ISNULL(CAST(EndDate As varchar), 'Not Finished')
FROM Projects

----------------------------------

