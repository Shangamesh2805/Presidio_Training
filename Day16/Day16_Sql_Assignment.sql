use pubs

Select * from titles

Select  title from titles

--Print all the titles that have been published by 1389

Select title from titles where pub_id=1389

--Print the books that have price in rangeof 10 to 15
Select * from titles where price between 10 and 15

--Print those books that have no price
Select * from titles where price =0

--Print the book names that strat with 'The'
Select title from titles where title like 'The%'

--Print the book names that do not have 'v' in their name
Select title from titles where title not like '%v%'

--print the books sorted by the royalty

Select title_id,title,royalty, type from titles
order by royalty

--print the books sorted by publisher in descending then by types in asending then by price in descending

SELECT * from titles 
order by pub_id desc, type, price desc


--Print the average price of books in every type

select type,avg(price) Average_Price from titles 
group by type

--print all the types in uniques

select distinct(type)
from titles

-- Print the first 2 costliest books
Select Top 2 title,price 
from titles 
order by price desc

--Print books that are of type business and have price less than 20 which also have advance greater than 7000
Select * from titles 
where  type='business' and price<20 and advance>7000

--Select those publisher id and number of books which have price between 15 to 25 and 
--have 'It' in its name. Print only those which have count greater than 2. 
--Also sort the result in ascending order of count


select pub_id,count(*)as "Count of books" from titles
where price between 15 and 25 and
 title like '%It%'  
 group by pub_id
 having count(*) >2
 order by count(*)

 --Print the Authors who are from 'CA'
 Select * from authors  where
 state ='CA'

 -- Print the count of authors from every state
 Select state,Count(*) 'Author Count' from authors
 group by state
 order by Count(*)

Select * from authors

