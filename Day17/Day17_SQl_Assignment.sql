--1) Print the storeid and number of orders for the store
use pubs


select stores.stor_id,qty from stores join 
sales on sales.stor_id=stores.stor_id

select * from sales
select * from titles

--2) print the numebr of orders for every title
select title,qty Number_of_orders from titles join
sales on titles.title_id=sales.title_id

select * from publishers
--3) print the publisher name and book name

Select pub_name,title Book_name from publishers join 
Titles on publishers.pub_id=titles.pub_id

select * from authors
select * from  titleauthor

--4) Print the author full name for al the authors

select au_fname+' '+au_lname  as Authors_full_name from authors


--5) Print the price or every book with tax (price+price*12.36/100)

select title,price,price+(price*12.36/100) as Price_with_Tax from titles

select * from titles
select * from authors
select * from titleauthor


--6) Print the author name, title name
select au_fname+' '+au_lname  as Authors_full_name,title from authors 
join titleauthor on authors.au_id=titleauthor.au_id join titles on
titles.title_id=titleauthor.title_id

select * from titles
select * from publishers

--7) print the author name, title name and the publisher name

select au_fname+' '+au_lname  as Authors_full_name,title,pub_name from authors 
join titleauthor on authors.au_id=titleauthor.au_id join titles on
titles.title_id=titleauthor.title_id join publishers on
publishers.pub_id=titles.pub_id

--8) Print the average price of books pulished by every publicher

select distinct pub_id from titles

select avg(price) as Average_Price,pub_name Publisher_name from Titles
join publishers on 
publishers.pub_id=titles.pub_id
group by publishers.pub_name 

--9) print the books published by 'Marjorie'
select * from publishers
select * from Titles join publishers on titles.pub_id=publishers.pub_id 
where publishers.pub_name='Marjorie'

select * from sales
select * from titles
select * from publishers
--10) Print the order numbers of books published by 'New Moon Books'

select ord_num,Title,pub_name from sales join titles on sales.title_id=titles.title_id 
join publishers on publishers.pub_id=titles.pub_id where pub_name='New Moon Books'

--11) Print the number of orders for every publisher
select pub_name Publisher, count(ord_num) number_of_orders from Sales join titles on titles.title_id=sales.title_id
join publishers on publishers.pub_id=titles.pub_id group by pub_name

--12) print the order number , book name, quantity, price and the total price for all orders
select ord_num , Title, qty Quantity , Price,Sum(Price) 'Total Price of orders' from sales join Titles 
on sales.title_id=titles.title_id GROUP BY ord_num, Title, qty, Price

--13) print he total order quantity fro every book
select title, sum(qty) 'Oder Quantity' from sales join titles on titles.title_id=sales.title_id group by titles.title_id,titles.title

--14) print the total ordervalue for every book
select Title,ord_num Order_Number,(s.qty*t.price) as "Total Order Value" from sales s join titles t on t.title_id=s.title_id
group by s.ord_num,title,qty,price

