use pubs 

-- 1. Create a stored procedure that will take the author firstname and print all the books pulished by him with the publisher's name
create proc AuthorBookDetails_procedure(@aname varchar(20))
as
begin
	select a.au_fname as "Author's Name", t.title as "Book_Title", p.pub_name as "Publisher's Name" from authors a
	join titleauthor ta on a.au_id = ta.au_id 
	join titles t on t.title_id = ta.title_id 
	join publishers p on p.pub_id = t.pub_id where a.au_fname = @aname
end
Select * from authors
Select * from titleauthor

exec AuthorBookDetails_procedure "Ann"

drop proc AuthorBookDetails_procedure

-- 2. Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.

create proc EmployeeSoldDetails_proc(@ename varchar(20))
as
begin
	select e.fname "Employee's Name", t.title "Book_Title", t.price "Unit_rice", s.qty "Quantity", (t.price * s.qty) "Total_Cost" 
	from employee e join titles t on t.pub_id = e.pub_id 
	join sales s on s.title_id = t.title_id 
	where e.fname = @ename  
end

select * from employee
select * from titles

exec EmployeeSoldDetails_proc "Muller"

drop proc EmployeeSoldDetails_proc

-- 3. Create a query that will print all names from authors and employees

select concat(fname, ' ', lname) as Emplyee_Author_Names from employee
union 
select concat(au_fname, ' ', au_lname) from authors

-- 4. Create a  query that will float the data from sales, titles, publisher and authors table to print 
-- title name, Publisher's name, author's full name with quantity ordered and price for the order for all orders,
-- print first 5 orders after sorting them based on the price of order

-- using CTE

with OrderCTE(Title, Publiser_Name, Author_Name, Quantity, Unit_Price, Total_Price)
as

(select t.title, p.pub_name, concat(a.au_fname, ' ', a.au_lname), s.qty, t.price, (t.price * s.qty) 
from titles t 
join publishers p on t.pub_id = p.pub_id 
join titleauthor ta on ta.title_id = t.title_id 
join authors a on a.au_id = ta.au_id
join sales s on s.title_id = t.title_id)

select top 5 * from OrderCTE order by Total_Price desc

