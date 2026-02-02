select * from products

select * from products 
where reorderlevel <15
select * from products 
where reorderlevel >=15 and reorderlevel <=20

select * from products 
where reorderlevel between 15 and 20

select * from products 
where reorderlevel =15 or  reorderlevel =20 or
 reorderlevel =22
 select * from products 
where reorderlevel in (15,20,22)
--select all tge products that are prices more than 20
select * from products where
unitprice>20

--select all the products that are supplied 
--by supplier with id - 12,27,8
select * from products where
supplierId in(12,27,8)

select ProductName, UnitPrice
from products

select ProductName Product_Name, UnitPrice Price_In_$
from products

select ProductName Product_Name, UnitPrice*UnitsInStock Amount_As_Stock
from products

select ProductName Product_Name, 
case 
when UnitsInStock = 0 then 00
else 
  UnitPrice*UnitsInStock
  end
  Amount_As_Stock
from products


select * from products 
order by unitprice

select * from products 
order by unitprice desc


select ProductName Product_Name, UnitPrice*UnitsInStock Amount_As_Stock
from products 
order by supplierId

select * from products 
order by supplierId desc, unitprice 


select top 10 ProductName Product_Name, UnitPrice*UnitsInStock Amount_As_Stock
from products 
order by supplierId

select ProductName Product_Name, UnitPrice*UnitsInStock Amount_As_Stock
from products 
order by supplierId
offset 70 rows fetch next 10 rows only

select *
from (select *, ROW_NUMBER() over (order by supplierId) as RowNum
from products) t
where RowNum >70 and RowNum<80


select * from orders
--print the orders sorted by the customerID
Select * from orders 
order by customerid
--Fetch the 3rd page of teh orders table
--(assuming each page has 10 records sorted by customerid)
select * from orders
order by customerID
offset 20 rows fetch next 10 rows only
-- Print the orders which have no shipRegion
select * from orders
where shipRegion is null
-- print the orders sorted by shipcountry 
--then by ship name
select * from orders order by shipCountry, ShipName
-- print the orders that are shipped 
--after 1996-07-11 00:00:00.000
select * from orders
where shippeddate > '1996-07-11 00:00:00.000'
--print the orders by 
--customers VINET,RICSU, ERNSH which have feight charge more than 15
select * from orders
where customerid in ('VINET','RICSU', 'ERNSH')


select  sum(unitprice) Sum_Of_UnitPrice
from products
select  round(avg(unitprice),2) Sum_Of_UnitPrice
from products

select round(28.8663,-2)

select * from products




select   categoryId,sum(unitprice) Sum_Of_UnitPrice
from products
group by categoryId

select orderid,sum(unitprice*quantity) total_amount
from [order details]
group by orderid

select orderid,sum(unitprice*quantity) total_amount
from [order details]
where productid != 3
group by orderid
having sum(unitprice*quantity)>1000
order by total_amount

select orderid,sum(unitprice*quantity) total_amount
from [order details]
where productid != 3
group by orderid
having sum(unitprice*quantity)>1000
order by 2
offset 200 rows fetch next 10 rows only